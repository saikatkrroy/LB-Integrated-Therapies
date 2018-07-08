using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionTime.Visible = false;
            Time.Visible = false;
            Duration.Visible = false;
            Location.Visible = false;
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            /*var manager = new UserManager();
            var user = new ApplicationUser() { UserName = Name.Text };
            //DataSet dataset = new DataSet();
            IdentityResult result = manager.Create(user);
            if (result.Succeeded)
            {
                IdentityHelper.SignIn(manager, user, isPersistent: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }*/

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            SessionTime.Visible = true;
            Time.Visible = true;
            Duration.Visible = true;
            Location.Visible = true;
        }
        protected void DayRender(Object source, DayRenderEventArgs e)
        {
            // LINQtoSQL to get the desc
            string desc = "8 Slots";
            // Add custom desc to cell in the Calendar control.
            e.Cell.Controls.Add(new LiteralControl("<br />" + desc));
        }
    }
}
