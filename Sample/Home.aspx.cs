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
using Sample.DataObjects;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization;
using System.Web.UI.DataVisualization.Charting;
using System.Security.Policy;

namespace Sample
{
    public partial class Home : System.Web.UI.Page
    {
        Documents documents = new Documents();

        protected void Page_Load(object sender, EventArgs e)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://evwp0058:8090/rest/apps/residential_sample/searchers/residential_sample?q=%22Austin%22");

            //DataTable dtPie = new DataTable();
            //dtPie.Columns.Add("Year");
            //dtPie.Columns.Add("Value");

            //DataRow dr = dtPie.NewRow();
            //dr["Year"] = 2020;
            //dr["Value"] = 1000;
            //dtPie.Rows.Add(dr);

            //DataRow dr1 = dtPie.NewRow();
            //dr["Year"] = 2021;
            //dr["Value"] = 10000;
            //dtPie.Rows.Add(dr1);

            //DataRow dr2 = dtPie.NewRow();
            //dr["Year"] = 2022;
            //dr["Value"] = 100000;
            //dtPie.Rows.Add(dr2);

            //Chart1.DataSource = dtPie;
            //Chart1.Series["Year"].XValueMember = "Year";
            //Chart1.Series["Year"].YValueMembers = "value";
            //Chart1.DataBind();
        }
    }
}