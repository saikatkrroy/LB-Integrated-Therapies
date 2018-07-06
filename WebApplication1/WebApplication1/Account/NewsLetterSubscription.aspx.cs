using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Account
{
    public partial class NewsLetterSubscription : System.Web.UI.Page
    {
        static int id = 0;
        /*DataSetTableAdapters.newsletterTableAdapter nta = new DataSetTableAdapters.newsletterTableAdapter();
DataSetTableAdapters.QueriesTableAdapter qta = new DataSetTableAdapters.QueriesTableAdapter();*/
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Search_Click(object sender, EventArgs e)
        {
           /*id += 1;
           qta.newslettersubscription(id, Name.Text, ContactNumber.Text, EmailID.Text);*/
        }
    }
}