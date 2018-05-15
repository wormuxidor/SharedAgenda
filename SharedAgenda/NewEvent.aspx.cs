using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SharedAgenda
{
    public partial class NewEvent : System.Web.UI.Page
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_btn_Click(object sender, EventArgs e)
        {
            DateTime hi = new DateTime(2008, 3, 1, 7, 0, 0); // Nur ein Testwert: Dieser Code wird entfernt


            SqlConnection conn = new SqlConnection(connectionString); //Connectionstring erstellen

            SqlCommand cmd = new SqlCommand("Eintrag_hinzufügen", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cmd.Parameters.Add("@Fach", SqlDbType.NVarChar).Value = subject_db.SelectedItem.Text;
            cmd.Parameters.Add("@Termin", SqlDbType.DateTime).Value = calender.SelectedDate;
            cmd.Parameters.Add("@kBeschreibung",SqlDbType.NVarChar ).Value = tb_kBeschreibung.Text;
            cmd.Parameters.Add("@Typ", SqlDbType.NVarChar, 30).Value = rb_eventtype.SelectedItem.Text;
            //cmd.Parameters.Add("@Board", SqlDbType.Int).Value = int.Parse(DDBoard.SelectedItem.Text);
            cmd.Parameters.Add("@Kommentar", SqlDbType.NVarChar, 350).Value = tb_Beschreibung.Text;
            cmd.Connection = conn;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            /* 
             Parameter für den Typ  wird aus Radiobutton entnommen da es nur 2-3 Optionen gibt.
             und das Board wird aus Dropdowns entnommen, da es nur eine 
             beschränkte Anzahl Möchlichkeiten gibt, während der Kommentar vom Nutzer selbst
             geschrieben werden muss. 
             
             Die Parameter werden über eine Stored Procedure an die Datenbank weitergeleitet,
             um von Überall die Einträge aufrufen zu können.
             */

            Response.Redirect("Shared_Agenda.aspx", true);
        }

        protected void cancel_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Shared_Agenda.aspx", true);
        }
    }
}