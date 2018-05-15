using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SharedAgenda
{
    public partial class Shared_Agenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String[] userData = (String[]) Session["userData"];
            firstname.Text = userData[0];
            surname.Text = userData[1];

            

        }

        protected void week_selection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void log_out_button_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }

        protected void New_Event_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewEvent.aspx");
        }
    }
}