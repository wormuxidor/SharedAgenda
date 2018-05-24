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
            getEventtypes();
            getFaecher();

        }

        protected void getFaecher()
        {
            string BoardID = (string)Session["BoardID"];
            Testlabel.Text = BoardID;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open(); ;
            SqlCommand cmd = new SqlCommand("getFaecher", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add("@BoardID", SqlDbType.Int).Value = Convert.ToInt32(BoardID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            subject_db.DataSource = ds;
            subject_db.DataTextField = "Fach";
            subject_db.DataValueField = "ID";
            subject_db.DataBind();
            subject_db.Items.Insert(0, BoardID);
            subject_db.SelectedIndex = 0;
        }

        protected void getEventtypes()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open(); ;
            SqlCommand cmd = new SqlCommand("getEventtypes", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            rb_eventtype.DataSource = ds;
            rb_eventtype.DataTextField = "Typ";
            rb_eventtype.DataValueField = "ID";
            rb_eventtype.DataBind();
        }

        protected void submit_btn_Click(object sender, EventArgs e)
        {
            string BoardID = (string)Session["BoardID"];

            DateTime hi = new DateTime(2008, 3, 1, 7, 0, 0); // Nur ein Testwert: Dieser Code wird entfernt


            SqlConnection conn = new SqlConnection(connectionString); //Connectionstring erstellen

            SqlCommand cmd = new SqlCommand("Eintrag_hinzufügen", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            cmd.Parameters.Add("@FachID", SqlDbType.Int).Value = subject_db.SelectedItem.Value;
            cmd.Parameters.Add("@Termin", SqlDbType.DateTime).Value = calender.SelectedDate;
            cmd.Parameters.Add("@kKommentar",SqlDbType.NVarChar ).Value = tb_kBeschreibung.Text;
            cmd.Parameters.Add("@TypID", SqlDbType.Int).Value = rb_eventtype.SelectedItem.Value;
            cmd.Parameters.Add("@BoardID", SqlDbType.Int).Value = BoardID;
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