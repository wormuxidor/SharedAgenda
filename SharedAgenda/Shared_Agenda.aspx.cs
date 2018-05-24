using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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

            getBoards();
            getEventtypes();
            Get_Date();
            if (!Page.IsPostBack)
            {
                getSessionBoard();
            }
            
        }

        protected void getBoards()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open(); ;
            SqlCommand cmd = new SqlCommand("getBoard", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(this.userData[3]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            class_list.DataSource = ds;
            class_list.DataTextField = "Boardname";
            class_list.DataValueField = "ID";
            class_list.DataBind();
            class_list.SelectedIndex = 1;
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
            events.DataSource = ds;
            events.DataTextField = "Typ";
            events.DataValueField = "ID";
            events.DataBind();

        }

        protected void Get_Date()
        {
            SqlConnection conn = new SqlConnection(connectionString); //Connectionstring erstellen
            
            SqlCommand cmd = new SqlCommand("Get_Eintrag", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            string WeekInputText = week_selection.SelectedItem.Text;
            string[] Week = WeekInputText.Split(' ');
             
            cmd.Parameters.Add("@Board", SqlDbType.NVarChar).Value = class_list.SelectedItem.Text;
            cmd.Parameters.Add("@WochenStart", SqlDbType.DateTime).Value = GetDaysOfWeek(int.Parse(Week[1]), int.Parse(Week[0]) - 1); // Montag der Woche von Woche und Jahr ableiten.
            cmd.Parameters.Add("@WochenEnde", SqlDbType.DateTime).Value = GetDaysOfWeek(int.Parse(Week[1]), int.Parse(Week[0])); // Montag der nächsten Woche von Woche und Jahr ableiten

            cmd.Connection = conn;

            conn.Open();
            cmd.ExecuteNonQuery();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            splitInDays(ds);
            conn.Close();


            
            }

        protected void splitInDays(DataSet ds)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DateTime Einstelldatum = DateTime.Parse(ds.Tables[0].Rows[i]["Einstelldatum"].ToString());

                String DayOfWeek = Convert.ToString(Einstelldatum.DayOfWeek);
                //Test.Text = DayOfWeek;
                /*   Div erstellen und Befüllen fehlt noch
                 
                */
                

                HtmlGenericControl createDiv =
                new HtmlGenericControl("DIV");
                createDiv.ID = "createDiv" + i;

                createDiv.InnerHtml = Server.HtmlEncode( ds.Tables[0].Rows[i]["KKommentar"].ToString());
                this.Controls.Add(createDiv);

                /*if (DayOfWeek == "Monday")
                {
                    HtmlGenericControl Monday = (HtmlGenericControl) FindControl("Monday");
                    Monday.Controls.Add(createDiv);
                }
                else if (DayOfWeek == "Tuesday")
                {
                    HtmlGenericControl Tuesday = (HtmlGenericControl)FindControl("Tuesday");
                    Tuesday.Controls.Add(createDiv);
                }
                else if (DayOfWeek == "Wednesday")
                {
                    HtmlGenericControl Wednesday = (HtmlGenericControl)FindControl("Wednesday");
                    Wednesday.Controls.Add(createDiv);
                }
                else if (DayOfWeek == "Thursday")
                {
                    HtmlGenericControl Thursday = (HtmlGenericControl)FindControl("Thursday");
                    Thursday.Controls.Add(createDiv);
                }
                else if (DayOfWeek == "Friday")
                {
                    HtmlGenericControl Friday = (HtmlGenericControl)FindControl("Friday");
                    Friday.Controls.Add(createDiv);
                }
                else if (DayOfWeek == "Saturday")
                {
                    HtmlGenericControl Saturday = (HtmlGenericControl)FindControl("Saturday");
                    Saturday.Controls.Add(createDiv);
                }
                else if (DayOfWeek == "Sunday")
                {
                    HtmlGenericControl Sunday = (HtmlGenericControl)FindControl("Sunday");
                    Sunday.Controls.Add(createDiv);
                }*/
            }

                
        }

        protected void week_selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_Date();
        }

        protected void Board_selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["BoardID"] = 0;
            getSessionBoard();
            week_selection_SelectedIndexChanged(sender, e);
        }

        protected void getSessionBoard()
        {
            string BoardID = class_list.SelectedItem.Value.ToString();
            Session["BoardID"] = BoardID;
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

        protected DateTime GetDaysOfWeek(int year, int Woche)
        {
            
            DateTime date = new DateTime(year, 1, 1);
            DateTime newDate = date;

            while (Convert.ToString(newDate.DayOfWeek) != "Monday")
            {
                newDate = newDate.AddDays(-1);
            }

            //herausfinden des Montages aus der Woche des 1.Januar

            newDate = newDate.AddDays(+7 * Woche);

            // Woche verrechnen

            return newDate;
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
            cmd.Parameters.Add("@kBeschreibung", SqlDbType.NVarChar).Value = tb_kBeschreibung.Text;
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
            
        }
    }
}