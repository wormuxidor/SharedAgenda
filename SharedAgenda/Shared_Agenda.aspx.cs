using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SharedAgenda
{
    public partial class Shared_Agenda : System.Web.UI.Page
    {

        public string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
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

            Get_Date();
        }

        protected void Get_Date()
        {
            SqlConnection conn = new SqlConnection(connectionString); //Connectionstring erstellen

            SqlCommand cmd = new SqlCommand("Get_Eintrag", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cmd.Parameters.Add("@Board", SqlDbType.NVarChar).Value = class_list.SelectedItem.Text;
            cmd.Parameters.Add("@WochenStart", SqlDbType.DateTime).Value = GetDaysOfWeek(year, int.Parse(week_selection.SelectedItem.Text) - 1); // UNFUNCTIONAL Montag der Woche von Woche und Jahr ableiten.
            cmd.Parameters.Add("@WochenEnde", SqlDbType.DateTime).Value = GetDaysOfWeek(year, int.Parse(week_selection.SelectedItem.Text)); // UNFUNCTIONAL Montag der nächsten Woche von Woche und Jahr ableiten

            cmd.Connection = conn;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        protected void week_selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_Date();
        }

        protected void log_out_button_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }

        protected void New_Event_Click(object sender, EventArgs e)
        {
            /*
            int privilege = Convert.ToInt32(this.userData[2]);
            if (privilege >= 2)
            {
                Response.Redirect("NewEvent.aspx");
            }*/
        }

        protected DateTime GetDaysOfWeek(int year, int Woche)
        {
            
            DateTime date = new DateTime(year, 1, 1);
            DateTime newDate = date;

            while (Convert.ToString(newDate.DayOfWeek) != "Monday")
            {
                newDate = newDate.AddDays(-1);
            }

            //herausfinden des Montages aus der Woche des 1.Januar

            newDate = newDate.AddDays(7 * Woche);

            // Woche verrechnen

            return newDate;
        }
    }
}