using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace i3Visuals
{
    public partial class SamplePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["a"] = "Test Session";
            string a = Session["a"].ToString();

            DataTable dtPie = new DataTable();
            dtPie.Columns.Add("Year");
            dtPie.Columns.Add("Value");

            DataRow dr = dtPie.NewRow();
            dr["Year"] = 2020;
            dr["Value"] = 1000;
            dtPie.Rows.Add(dr);

            DataRow dr1 = dtPie.NewRow();
            dr["Year"] = 2021;
            dr["Value"] = 10000;
            dtPie.Rows.Add(dr1);

            DataRow dr2 = dtPie.NewRow();
            dr["Year"] = 2022;
            dr["Value"] = 100000;
            dtPie.Rows.Add(dr2);

            Chart1.DataSource = dtPie;
            Chart1.Series["Year"].XValueMember = "Year";
            Chart1.Series["Year"].YValueMembers = "value";
            Chart1.DataBind();
        }
    }
}