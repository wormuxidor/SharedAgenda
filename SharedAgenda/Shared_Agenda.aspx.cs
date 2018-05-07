using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SharedAgenda
{
    public partial class Shared_Agenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void week_selection_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void log_out_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", true);
        }

        protected void New_Event_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewEvent.aspx", true);
        }
    }
}