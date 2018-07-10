using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Account
{
    public partial class ManageBooking : System.Web.UI.Page
    {
        DataSetTableAdapters.QueriesTableAdapter qta = new DataSetTableAdapters.QueriesTableAdapter();
        DataSetTableAdapters.retrievebookingTableAdapter rta = new DataSetTableAdapters.retrievebookingTableAdapter();
        DataSet.retrievebookingDataTable rdt;
        
        Object placeholder;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            rdt = rta.GetData(EmailID.Text);
            //rta.Fill();
            GridView1.DataSource= rdt;
            GridView1.DataBind();
            if (rdt == null)
            {
                Label1.Visible = true;
                Label1.Text = "No data found";
            }
            else
            {
                Label1.Visible = true;
                foreach (DataRow row in rdt.Rows)
                {
                    Console.WriteLine();
                    for (int x = 0; x < rdt.Columns.Count; x++)
                    {
                        Label1.Text = Label1.Text + row[x].ToString() + " ";
                    }
                }
            }
        }
    }
}