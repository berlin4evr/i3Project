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
        DataTable dtChart1Data = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            Task T = new Task(ApiCall);
            T.Start();

            //if (!IsPostBack)
            //{
            //    chartData.DataSource = ViewState["DataTable"];
            //    chartData.DataBind();
            //}
        }

        public async void ApiCall()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://evwp0058:8090/rest/apps/residential_sample/searchers/residential_sample?q=%22Austin%22");
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
                        DataRow dr = dtPie.NewRow();
                        dr["Year"] = row["year"];
                        dr["Value"] = row["value"];
                        dtPie.Rows.Add(dr);
                    }

                    //GetDatatable(dtPie);
                    dtChart1Data= dtPie;

                    Session["DataTable"] = dtPie;

                    //chartData.DataSource = null;
                    //chartData.DataSource = ViewState["DataTable"];
                    //chartData.DataBind();

                    using (DataTable data = dtPie)
                    {
                        //chartData.DataSource= data;
                        //this.Chart2.DataSource = data;
                        ////Chart2.Legends[0].Enabled = true;
                        //this.Chart2.Series[0].XValueMember = "Year";
                        //this.Chart2.Series[0].YValueMembers = "Value";
                        //this.Chart2.DataBind();
                    }
                }

            }
        }

        //public void GetDatatable(DataTable dtChartData)
        //{
        //    chartData.DataSource = dtChartData;
        //    chartData.DataBind();
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            chartData.DataSource = Session["DataTable"];
            chartData.DataBind();
        }

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