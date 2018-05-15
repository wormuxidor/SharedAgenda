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
        String[] userData;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.userData = (String[]) Session["userData"];
            firstname.Text = this.userData[0];
            surname.Text = this.userData[1];

            int privilege = Convert.ToInt32(this.userData[2]);
            if (privilege < 2)
            {
                newEventButton.Attributes.Add("style","display:none");
            }
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
            int privilege = Convert.ToInt32(this.userData[2]);
            if (privilege >= 2)
            {
                Response.Redirect("NewEvent.aspx");
            }
        }
    }
}