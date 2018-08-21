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
        private Invoice _invoice;
        private int _prereqCount;
        IApiConfiguration config;
        private const string CsOAuthScope = "CompanyFile";
        private const string CsOAuthServer = "https://secure.myob.com/oauth2/account/authorize/";
        string url = string.Format("{0}?client_id={1}&redirect_uri={2}&scope={3}&response_type=code", CsOAuthServer,
                                       "saikatkrroy@gmail.com", HttpUtility.UrlEncode(config.RedirectUrl), CsOAuthScope);
        public void Show(Invoice invoice)
        {
            _invoice = invoice;
            Show();
        }

        private void DoBind()
        {
            _prereqCount += 1;
            if (_prereqCount == 4)
            {
                BindInvoice();
                HideSpinner();
            }
        }


        private void BindInvoice()
        {
            if ((_invoice != null))
            {
                var serviceInvoiceSvc = new ServiceInvoiceService(MyConfiguration,
                                                                  null,
                                                                  MyOAuthKeyService);
                ServiceInvoice serviceInvoice = serviceInvoiceSvc.Get(MyCompanyFile, _invoice.UID, MyCredentials);

                //Set the default value
                var customers =
                    CmboCustomer.DataSource as PagedCollection<Customer>;

                if (customers != null)
                {
                    for (int i = 0; i <= customers.Count; i++)
                    {
                        Customer customer = customers.Items[i];
                        if (customer.UID == serviceInvoice.Customer.UID)
                        {
                            CmboCustomer.SelectedIndex = i;
                            break;
                        }
                    }
                }
                BsServiceInvoice.DataSource = serviceInvoice;
                GrdServiceLines.DataSource = FlattenLines(serviceInvoice.Lines);
            }
        }
        private void createinvoice()
        {
            var serviceInvoiceSvc = new ServiceInvoiceService(MyConfiguration, null,
                                                              MyOAuthKeyService);
            var serviceInvoice = new ServiceInvoice();

            if ((_invoice == null))
            {
                var customerLnk = new CustomerLink { UID = (Guid)CmboCustomer.SelectedValue };
                serviceInvoice.Customer = customerLnk;
                serviceInvoice.ShipToAddress = TxtAddress.Text;
                serviceInvoice.Number = TxtInvoiceNo.Text;
                serviceInvoice.Date = DtDate.Value;
                serviceInvoice.IsTaxInclusive = ChkTaxInclusive.Checked;

                var lines = new List<ServiceInvoiceLine>();

                foreach (DataGridViewRow row in GrdServiceLines.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var line = new ServiceInvoiceLine
                        {
                            Type = InvoiceLineType.Transaction,
                            Description = (string)row.Cells["ColDescription"].Value,
                            Total = Convert.ToDecimal(row.Cells["ColAmount"].Value)
                        };

                        if ((row.Cells["ColAccount"].Value == null))
                        {
                            MessageBox.Show("you must select an account on each row");
                            return;
                        }
                        var accountlnk = new AccountLink { UID = (Guid)row.Cells["ColAccount"].Value };
                        line.Account = accountlnk;

                        if ((row.Cells["ColTax"].Value == null))
                        {
                            MessageBox.Show("you must select a taxcode on each row");
                            return;
                        }
                        var taxcodelnk = new TaxCodeLink { UID = (Guid)row.Cells["ColTax"].Value };
                        line.TaxCode = taxcodelnk;

                        if ((row.Cells["ColJob"].Value != null))
                        {
                            var joblnk = new JobLink { UID = (Guid)row.Cells["ColJob"].Value };
                            line.Job = joblnk;
                        }

                        lines.Add(line);
                    }
                }


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
