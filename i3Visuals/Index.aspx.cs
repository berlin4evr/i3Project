﻿using System;
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
        Documents documents = new Documents();
        //DataTable dtChart1Data = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

            //Task T = new Task(ApiCall);
            //T.Start();
        }

        protected async void btnRefresh_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                //HttpResponseMessage response = await client.GetAsync("http://evwp0058:8090/rest/apps/residential_sample/searchers/residential_sample?q=%22Austin%22");
                HttpResponseMessage response = await client.GetAsync("http://evwp0058:8090/rest/apps/residential_sample/searchers/residential_sample?q=*&%22transaction_type%22:%22refinance%22");
                response.EnsureSuccessStatusCode();

                using (HttpContent content = response.Content)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(responseBody);

                    var articles = JsonConvert.DeserializeObject(responseBody);

                    var ser = JsonConvert.SerializeObject(responseBody);
                    var obj = JObject.Parse(responseBody);
                    var token = obj.SelectToken("documentList");
                    var tokendoc = token.SelectToken("documents");

                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(tokendoc.ToString(), (typeof(DataTable)));

                    // int c = (int)dt.Rows.Count;

                    DataTable dtPie = new DataTable();
                    dtPie.Columns.Add("Year");
                    dtPie.Columns.Add("Value");

                    // DataRow drp = dtPie.NewRow();

                    foreach (DataRow row in dt.Rows)
                    {
                        string result = row["_id"].ToString().Replace("C:\\i3", "\\EVWP0058");
                        string docfilename = result.ToString().Replace("\\EVWP0058\\pdf_data\\", "");

                     //   Response.ContentType = "Application/pdf";
                     // Response.AppendHeader("Content-Disposition", "attachment; filename=Test_PDF.pdf");
                     //Response.TransmitFile(Server.MapPath(result));
                     //Response.End();
                     //HyperLink1.NavigateUrl = result;
                     //HyperLink1.Text = result;
                        DataRow dr = dtPie.NewRow();
                        dr["Year"] = result;
                        dr["Value"] = docfilename;
                        dtPie.Rows.Add(dr);
                    }

                    repDocument.DataSource = dtPie;
                    repDocument.DataBind();

                    chartData.DataSource = dtPie;
                    chartData.DataBind();
                }
            }
        }

      

        protected void repDocument_ItemCreated(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void repDocument_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }


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
    }
}