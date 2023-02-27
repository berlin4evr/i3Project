using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Net.Http;
using i3Visuals.DataObjects;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization;
using System.Web.UI.DataVisualization.Charting;
using System.Configuration;

namespace i3Visuals
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string URLa = "http://evwp0058:8090/rest/apps/residential_sample/searchers/residential_sample?q=%22transaction_type%22%20:%20%22" + refinance +"%22";
            //string URLb = "http://evwp0058:8090/rest/apps/residential_sample/searchers/residential_sample?q=%22transaction_type%22%20:%20%22" + purchase + "%22";
            //string URLc = "http://evwp0058:8090/rest/apps/residential_sample/searchers/residential_sample?q=%22transaction_type%22%20:%20%22" + other + "%22";

            //\\EVWP0058\pdf_data\DocSample14.pdf

            //Task T = new Task(ApiCall);
            //T.Start();
        }

        /// <summary>
        /// Button Search click activities
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected async void btnRefresh_Click(object sender, EventArgs e)
        {
            Documents documents = default(Documents);
            DataTable dt = default(DataTable);
            DataTable dtGrid = default(DataTable);
            DataTable dtChart = default(DataTable);
            HttpResponseMessage response = default;
            Common common = default(Common);

            try
            {
                documents = new Documents();
                dt = new DataTable();
                dtGrid = new DataTable();
                dtChart = new DataTable();
                response = new HttpResponseMessage();
                common = new Common();

                common.SearchText = txtSearch.Text.ToLower();
                common.QueryString = ConfigurationManager.AppSettings["API"];

                using (var client = new HttpClient())
                {
                    switch (common.SearchText)
                    {
                        case var s when common.SearchText.Contains("refinance"):
                            response = await client.GetAsync(common.QueryString + "refinance" + "%22");
                            break;

                        case var s when common.SearchText.Contains("purchase"):
                            response = await client.GetAsync(common.QueryString + "purchase" + "%22");
                            break;

                        case var s when common.SearchText.Contains("other"):
                            response = await client.GetAsync(common.QueryString + "other" + "%22");
                            break;

                        default:
                            GrdSearchResult.DataSource = null;
                            GrdSearchResult.DataBind();
                            chartData.DataSource = null;
                            chartData.DataBind();
                            txtSearch.Text = string.Empty;
                            lblCount.Text = "No Documents available! Search again!!";
                            break;
                    }
                    if (txtSearch.Text.Length != 0)
                    {
                        response.EnsureSuccessStatusCode();

                        using (HttpContent content = response.Content)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();

                            //Console.WriteLine(responseBody);

                            var articles = JsonConvert.DeserializeObject(responseBody);

                            var ser = JsonConvert.SerializeObject(responseBody);
                            var obj = JObject.Parse(responseBody);
                            var tokenStats = obj.SelectToken("stats");
                            var token = obj.SelectToken("documentList");
                            var tokendoc = token.SelectToken("documents");
                            var tokenFacet = obj.SelectToken("facets");

                            var totlHits = tokenStats.First().ToString().Split(':').LastOrDefault();

                            lblCount.Text = Convert.ToString(totlHits) + " Document(s) available";

                            dt = (DataTable)JsonConvert.DeserializeObject(tokendoc.ToString(), (typeof(DataTable)));

                            // int c = (int)dt.Rows.Count;

                            dtChart.Columns.Add("Year");
                            dtChart.Columns.Add("Value");

                            dtGrid.Columns.Add("FilePath");
                            dtGrid.Columns.Add("FileName");

                            // DataRow drp = dtPie.NewRow();

                            foreach (DataRow row in dt.Rows)
                            {
                                //string result = row["_id"].ToString().Replace("C:\\i3", "\\EVWP0058");
                                // string docfilename = result.ToString().Replace("\\EVWP0058\\pdf_data\\", "");

                                DataRow dr = dtGrid.NewRow();
                                dr["FilePath"] = row["_id"].ToString();
                                dr["FileName"] = Path.GetFileName(row["_id"].ToString());
                                dtGrid.Rows.Add(dr);

                                DataRow drChart = dtChart.NewRow();
                                drChart["Year"] = row["year"].ToString();
                                drChart["Value"] = row["value"].ToString();
                                dtChart.Rows.Add(drChart);
                            }

                            GrdSearchResult.DataSource = dtGrid;
                            GrdSearchResult.DataBind();

                            chartData.DataSource = dtChart;
                            chartData.DataBind();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (dt != null)
                    dt.Clear();
                dt = null;

                if (dtChart != null)
                    dtChart.Clear();
                dtChart = null;

                if (dtGrid != null)
                    dtGrid.Clear();
                dtGrid = null;
                response = null;
            }
        }

        public void NetworkPath()
        {

            //string networkPath = @"\\EVWP0058\\pdf_data\\DocSample14.pdf";
            //NetworkCredential credentials = new NetworkCredential(@"{User Name}", "{Password}");
            //string myNetworkPath = string.Empty;

            //myNetworkPath = networkPath;

            //string ReportURL = "{Your File Path}";
            //byte[] FileBytes = System.IO.File.ReadAllBytes(ReportURL);
            ////return File(FileBytes, "application/pdf");

            //----------------------------------------------------------------------
            // string fileName = "documents.pdf";
            string filePath = "\\EVWP0058\\pdf_data\\DocSample14.pdf";
            string fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
            string fileExtension = Path.GetExtension(filePath);
            Response.ContentType = "Application/pdf";
            Response.ContentType = "\".pdf\", \"application/pdf\"";
            Response.AppendHeader("Content-Disposition", "inline; filename=" + fileName);
            Response.WriteFile(filePath);
            Response.End();

            //-------------------------------------------------------------------------



        }

        public void BindSerarchResults()
        {
            Response.End();
        }

        protected void GrdSearchResult_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Common common = default(Common);
            try
            {
                common = new Common();

                if (e.CommandName == "Download")
                {
                    //string filePath = Convert.ToString(e.CommandArgument);
                    //string fileName = System.IO.Path.GetFileName(filePath);
                    //string fileExtension = Path.GetExtension(filePath);

                    common.FilePath = Convert.ToString(e.CommandArgument);
                    common.FileName = System.IO.Path.GetFileName(common.FilePath);
                    common.FileExtension = Path.GetExtension(common.FilePath);

                    Response.ContentType = "Application/pdf";
                    Response.ContentType = "\".pdf\", \"application/pdf\"";
                    Response.AppendHeader("Content-Disposition", "inline; filename=" + common.FileName);
                    Response.WriteFile(common.FilePath);
                    Response.End();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (common != null)
                    common = null;
            }
        }
    }
}