using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Account
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSetTableAdapters.RetrieveAppliedBookingTableAdapter rbta= new DataSetTableAdapters.RetrieveAppliedBookingTableAdapter();
            DataSet.RetrieveAppliedBookingDataTable rbdt;
            rbdt = rbta.GetData("Applied");
            GridView1.DataSource = rbdt;
            GridView1.DataBind();
            Label1.Text = rbdt.Rows.Count.ToString();

        }
    }
}