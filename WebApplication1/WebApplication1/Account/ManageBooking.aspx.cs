using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MYOB.AccountRight.SDK.Contracts.Version2;
using MYOB.AccountRight.SDK.Contracts.Version2.Contact;
using MYOB.AccountRight.SDK.Contracts.Version2.GeneralLedger;
using MYOB.AccountRight.SDK.Contracts.Version2.Sale;
using MYOB.AccountRight.SDK.Services.Contact;
using MYOB.AccountRight.SDK.Services.GeneralLedger;
using MYOB.AccountRight.SDK.Services.Sale;
using MYOB.AccountRight.SDK;

namespace WebApplication1.Account
{
    public partial class ManageBooking : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\webdb.mdf;Integrated Security=True;";
        DataSetTableAdapters.QueriesTableAdapter qta = new DataSetTableAdapters.QueriesTableAdapter();
        DataSetTableAdapters.retrievebookingTableAdapter rta = new DataSetTableAdapters.retrievebookingTableAdapter();
        DataSet.retrievebookingDataTable rdt;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconnection = new SqlConnection(ConnectionString);
            sqlconnection.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT b.Name, b.SessionDate, b.Email, s.Time, st.Status from dbo.Booking b inner join dbo.SessionTime s inner join dbo.Status st on b.SessionTimeID=s.Id and st.Id=b.Status where st.Status='Requested'", sqlconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView2.DataSource = dt;
            GridView2.DataBind();
            sqlconnection.Close();
            
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconnection = new SqlConnection(ConnectionString);
            sqlconnection.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT b.Name, b.SessionDate,s.Time from dbo.Booking b inner join dbo.SessionTime s on b.SessionTimeID=s.Id where b.Email='" + EmailID.Text.ToString() + "'", sqlconnection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            sqlconnection.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowUpdating(Object sender, GridViewUpdateEventArgs e)
        {
        }
        protected void GridView1_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DataSetTableAdapters.QueriesTableAdapter qta = new DataSetTableAdapters.QueriesTableAdapter();
            GridView1.EditIndex = e.NewEditIndex;
            DataTable dt = (DataTable)Session["TaskTable"];
            GridViewRow row = GridView1.Rows[e.NewEditIndex];
            dt.Rows[row.DataItemIndex]["Name"] = ((TextBox)(row.Cells[1].Controls[0])).Text;
            dt.Rows[row.DataItemIndex]["SessionDate"] = ((TextBox)(row.Cells[2].Controls[0])).Text;
            dt.Rows[row.DataItemIndex]["Email"] = ((TextBox)(row.Cells[3].Controls[0])).Text;
            dt.Rows[row.DataItemIndex]["Time"] = ((TextBox)(row.Cells[3].Controls[0])).Text;
            dt.Rows[row.DataItemIndex]["Status"] = ((DropDownList)(row.Cells[3].Controls[0])).SelectedIndex;
            GridView1.EditIndex = -1;

            //Bind data to the GridView control.
            GridView1.DataBind();

        }
        protected void GridView2_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {
            DataSet dataset = new DataSet();
            DataSetTableAdapters.QueriesTableAdapter qta = new DataSetTableAdapters.QueriesTableAdapter();
            //qta.deletebooking();
        }
        protected void GridView2_RowUpdating(Object sender, GridViewUpdateEventArgs e)
        {
            DataTable dt = (DataTable)Session["TaskTable"];

            //Update the values.
            GridViewRow row = GridView1.Rows[e.RowIndex];
            dt.Rows[row.DataItemIndex]["Name"] = ((TextBox)(row.Cells[1].Controls[0])).Text;
            dt.Rows[row.DataItemIndex]["SessionDate"] = ((TextBox)(row.Cells[2].Controls[0])).Text;
            dt.Rows[row.DataItemIndex]["Email"] = ((TextBox)(row.Cells[3].Controls[0])).Text;
            dt.Rows[row.DataItemIndex]["Time"] = ((TextBox)(row.Cells[3].Controls[0])).Text;
            dt.Rows[row.DataItemIndex]["Status"] = ((TextBox)(row.Cells[3].Controls[0])).Text;

            //Reset the edit index.
            GridView1.EditIndex = -1;

            //Bind data to the GridView control.
            GridView1.DataBind();
        }
    }
}
