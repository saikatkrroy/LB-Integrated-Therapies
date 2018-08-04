using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Account
{
    public partial class Register : System.Web.UI.Page
    {
        String ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\webdb.mdf;Integrated Security=True;";
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

        protected void SessionTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection sqlconnection = new SqlConnection(ConnectionString);
            sqlconnection.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT l.LocationName, s.StartTime,s.EndTime, l.DayofWeek  from dbo.Location l inner join dbo.Schedule s on l.ID=s.LocationId where l.DayofWeek='" + SessionDate.SelectedDate.DayOfWeek.ToString() + "';", sqlconnection);
            DataTable datatable = new DataTable();
            da.Fill(datatable);          
            sqlconnection.Close();
            switch (SessionDate.SelectedDate.DayOfWeek.ToString())
            {
                case "Monday":
                    {
                        for (int i = 0; i < datatable.Rows.Count; i++)
                        {
                            if ((Convert.ToInt32(SessionTime.SelectedValue) < Convert.ToInt32(datatable.Rows[i]["EndTime"])) && (Convert.ToInt32(SessionTime.SelectedValue)> Convert.ToInt32(datatable.Rows[i]["StartTime"])))
                            {
                                Location.Items.Add(datatable.Rows[i]["Location"].ToString());
                            }
                        }
                                break;
                    }
                case "Tuesday":
                    {
                        for (int i = 0; i < datatable.Rows.Count; i++)
                        {
                            if ((Convert.ToInt32(SessionTime.SelectedValue) < Convert.ToInt32(datatable.Rows[i]["EndTime"])) && (Convert.ToInt32(SessionTime.SelectedValue) > Convert.ToInt32(datatable.Rows[i]["StartTime"])))
                            {
                                Location.Items.Add(datatable.Rows[i]["Location"].ToString());
                            }
                        }
                        break;
                    }
                case "Wednesday":
                    {
                        for (int i = 0; i < datatable.Rows.Count; i++)
                        {
                            if ((Convert.ToInt32(SessionTime.SelectedValue) < Convert.ToInt32(datatable.Rows[i]["EndTime"])) && (Convert.ToInt32(SessionTime.SelectedValue) > Convert.ToInt32(datatable.Rows[i]["StartTime"])))
                            {
                                Location.Items.Add(datatable.Rows[i]["Location"].ToString());
                            }
                        }
                        break;
                    }
                case "Thursday":
                    {
                        for (int i = 0; i < datatable.Rows.Count; i++)
                        {
                            if ((Convert.ToInt32(SessionTime.SelectedValue) < Convert.ToInt32(datatable.Rows[i]["EndTime"])) && (Convert.ToInt32(SessionTime.SelectedValue) > Convert.ToInt32(datatable.Rows[i]["StartTime"])))
                            {
                                Location.Items.Add(datatable.Rows[i]["Location"].ToString());
                            }
                        }
                        break;
                    }
                case "Friday":
                    {
                        for (int i = 0; i < datatable.Rows.Count; i++)
                        {
                            if ((Convert.ToInt32(SessionTime.SelectedValue) < Convert.ToInt32(datatable.Rows[i]["EndTime"])) && (Convert.ToInt32(SessionTime.SelectedValue) > Convert.ToInt32(datatable.Rows[i]["StartTime"])))
                            {
                                Location.Items.Add(datatable.Rows[i]["Location"].ToString());
                            }
                        }
                        break;
                    }
                case "Saturday":
                    {
                        for (int i = 0; i < datatable.Rows.Count; i++)
                        {
                            if ((Convert.ToInt32(SessionTime.SelectedValue) < Convert.ToInt32(datatable.Rows[i]["EndTime"])) && (Convert.ToInt32(SessionTime.SelectedValue) > Convert.ToInt32(datatable.Rows[i]["StartTime"])))
                            {
                                Location.Items.Add(datatable.Rows[i]["Location"].ToString());
                            }
                        }
                        break;
                    }
                case "Sunday":
                    {
                        for (int i = 0; i < datatable.Rows.Count; i++)
                        {
                            if ((Convert.ToInt32(SessionTime.SelectedValue) < Convert.ToInt32(datatable.Rows[i]["EndTime"])) && (Convert.ToInt32(SessionTime.SelectedValue) > Convert.ToInt32(datatable.Rows[i]["StartTime"])))
                            {
                                Location.Items.Add(datatable.Rows[i]["Location"].ToString());
                            }
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }


            }
        }
    }
}
