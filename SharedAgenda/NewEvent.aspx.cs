using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SharedAgenda
{
    public partial class NewEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shared_Agenda.aspx", true);
        }

        protected void cancel_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shared_Agenda.aspx", true);
        }
    }
}