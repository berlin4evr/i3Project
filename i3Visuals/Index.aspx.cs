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

namespace i3Visuals
{
    public partial class Index : System.Web.UI.Page
    {
        //DataTable dtChart1Data = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            //\\EVWP0058\pdf_data\DocSample14.pdf

            //Task T = new Task(ApiCall);
            //T.Start();
        }

        protected async void btnRefresh_Click(object sender, EventArgs e)
        {
            Documents documents = default(Documents);
            DataTable dt = default(DataTable);
            DataTable dtGrid = default(DataTable);
            DataTable dtChart = default(DataTable);
            HttpResponseMessage response = default(HttpResponseMessage);
            try
            {
                documents = new Documents();
                dt = new DataTable();
                dtGrid = new DataTable();
                dtChart = new DataTable();
                
                response = new HttpResponseMessage();

                    using (var client = new HttpClient())
                    {

                    string search = txtSearch.Text.ToLower();
                    switch (search)
                    {
                        case var s when search.Contains("refinance"):
                            response = await client.GetAsync("http://evwp0058:8090/rest/apps/residential_sample/searchers/residential_sample?q=%22transaction_type%22%20:%20%22refinance%22");
                            break;

                        case var s when search.Contains("Purchase"):
                            response = await client.GetAsync("http://evwp0058:8090/rest/apps/residential_sample/searchers/residential_sample?q=%22transaction_type%22%20:%20%22refinance%22");
                            break;

                        case var s when search.Contains("other"):
                            response = await client.GetAsync("http://evwp0058:8090/rest/apps/residential_sample/searchers/residential_sample?q=%22transaction_type%22%20:%20%22refinance%22");
                            break;

                        default:
                            this.GrdSearchResult.DataSource = null;
                            this.GrdSearchResult.DataBind();
                            chartData.DataSource = null;
                            chartData.DataBind();
                            lblCount.Text = "No Documents avaiable!!! Search Again";
                            txtSearch.Text = string.Empty;
                            //this.GrdSearchResult.Rows.Clear();
                            break;
                            
                    }
                  if(txtSearch.Text.Length!=0)
                    {
                        response.EnsureSuccessStatusCode();

                        using (HttpContent content = response.Content)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();

                            Console.WriteLine(responseBody);

                            var articles = JsonConvert.DeserializeObject(responseBody);

                            var ser = JsonConvert.SerializeObject(responseBody);
                            var obj = JObject.Parse(responseBody);
                            var tokenStats = obj.SelectToken("stats");
                            var token = obj.SelectToken("documentList");
                            var tokendoc = token.SelectToken("documents");

                            var totlHits = tokenStats.First().ToString().Split(':').LastOrDefault();

                            lblCount.Text = Convert.ToString(totlHits) + " Document(s) available";

                            //lblCount.Text = Convert.ToString(tokenStats.First());

                            dt = (DataTable)JsonConvert.DeserializeObject(tokendoc.ToString(), (typeof(DataTable)));

                            // int c = (int)dt.Rows.Count;

                            //DataTable dtGrid = new DataTable();
                            //DataTable dtChart = new DataTable();
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

                            // repDocument.DataSource = dtPie;
                            //  repDocument.DataBind();

                            GrdSearchResult.DataSource = dtGrid;
                            GrdSearchResult.DataBind();

                            chartData.DataSource = dtChart;
                            chartData.DataBind();
                        }
                    }
                }
                
                //else
                //{
                //    this.GrdSearchResult.DataSource = null;
                //    this.GrdSearchResult.DataBind();
                //    chartData.DataSource = null;
                //    chartData.DataBind();
                //    lblCount.Text = "No Documents avaiable!!! Search Again";

                //    //this.GrdSearchResult.Rows.Clear();
                //}
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (dt != null)
                    dt.Clear();
                dt= null;

                if (dtChart != null)
                    dtChart.Clear();
                dtChart = null;

                if(dtGrid!=null)
                    dtGrid.Clear();
                dtGrid = null;
                response = null;
            }
        }



        //protected void repDocument_ItemCreated(object sender, RepeaterItemEventArgs e)
        //{

        //}

        //protected void repDocument_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{

        //}


        //protected void repDocument_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "download")
        //    {
        //        string filename = e.CommandArgument.ToString();
        //        string path = MapPath("~/Docfiles/" + filename);
        //        byte[] bts = System.IO.File.ReadAllBytes(path);
        //        Response.Clear();
        //        Response.ClearHeaders();
        //        Response.AddHeader("Content-Type", "Application/octet-stream");
        //        Response.AddHeader("Content-Length", bts.Length.ToString());
        //        Response.AddHeader("Content-Disposition", "attachment; filename=" +
        //        filename);
        //        Response.BinaryWrite(bts);
        //        Response.Flush();
        //    }
        //}



        //public void CreateChartData()
        //{
        //    Documents documents = default(Documents);
        //    DataTable dataTable = default(DataTable);
        //    HttpClient httpClient = default(HttpClient);
        //    try
        //    {
        //        httpClient = new HttpClient();
        //        documents = new Documents();
        //        dataTable = new DataTable();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if(httpClient !=null)
        //            httpClient.Dispose();
        //        httpClient = null;

        //        if(dataTable!=null)
        //            dataTable.Clear();
        //        dataTable = null;
        //    }
        //}

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

        protected void GrdSearchResult_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                //  string fileName = "documents.pdf";
                string filePath = Convert.ToString(e.CommandArgument);
                string fileName = System.IO.Path.GetFileName(filePath);
                string fileExtension = Path.GetExtension(filePath);
                Response.ContentType = "Application/pdf";
                Response.ContentType = "\".pdf\", \"application/pdf\"";
                Response.AppendHeader("Content-Disposition", "inline; filename=" + fileName);
                Response.WriteFile(filePath);
                Response.End();

            }
        }
    }
}