using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SharedAgenda
{
    public partial class Event : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

         protected void cancel_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shared_Agenda.aspx", true);
        }

        protected void delete_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shared_Agenda.aspx", true);
        }

        protected void edit_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewEvent.aspx", true);
        }
    }
}