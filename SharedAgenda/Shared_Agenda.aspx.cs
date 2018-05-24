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

            getBoards();
            getEventtypes();
            Get_Date();
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
            class_list.Items.Insert(0, "--Klasse auswählen--");
            class_list.SelectedIndex = 1;
        }

        protected void getEventtypes()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
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

        protected object Get_Date()
        {
            SqlConnection conn = new SqlConnection(connectionString); //Connectionstring erstellen
            conn.Open(); ;
            SqlCommand cmd = new SqlCommand("get_Eintrag", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            String WeekInputText;
            String[] Week;
            WeekInputText = week_selection.SelectedItem.Text;
            Week = WeekInputText.Split(' ');
            DateTime testDate1 = GetDaysOfWeek(Int32.Parse(Week[1]), Int32.Parse(Week[0])-1);
            DateTime testDate2 = GetDaysOfWeek(Int32.Parse(Week[1]), Int32.Parse(Week[0]));
            cmd.Parameters.Add("Board", SqlDbType.NVarChar).Value = class_list.SelectedItem.Text;
            cmd.Parameters.Add("WochenStart", SqlDbType.DateTime).Value =
                GetDaysOfWeek(Int32.Parse(Week[1]), Int32.Parse(Week[0]) - 1); // Montag der Woche von Woche und Jahr ableiten.
            cmd.Parameters.Add("WochenEnde", SqlDbType.DateTime).Value =
                GetDaysOfWeek(Int32.Parse(Week[1]), Int32.Parse(Week[0])); // Montag der nächsten Woche von Woche und Jahr ableiten
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                DataTable ds = new DataTable();
                adapter.Fill(ds);
                conn.Close();
                int rt = ds.Rows.Count;
                // ds wird noch nicht befüllt
                return SplitInDays(ds);
            }
            
            //SplitInDays(ds);
            
            

            
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

        protected object SplitInDays(DataTable ds)
        {
            
            DateTime Einstelldatum;
            String DayOfWeek;
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                
                Einstelldatum = DateTime.Parse(ds.Rows[i]["Einstelldatum"].ToString());
                
                DayOfWeek = Einstelldatum.DayOfWeek.ToString();
                
                /*   Div erstellen und Befüllen fehlt noch
                 
                */
                Label TextKKommentar = new Label();
                TextKKommentar.ID = "Text" + i.ToString();
                
                TextKKommentar.Text = ds.Rows[i]["KKommentar"].ToString();
              
                TextKKommentar.Visible = true;
               // TextKKommentar.DataBind();

                System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
                new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
               
                createDiv.ID = "EintragDiv" + i.ToString();
                createDiv.Controls.Add(TextKKommentar);
              

                createDiv.InnerHtml = Server.HtmlEncode( ds.Rows[i]["KKommentar"].ToString());
                // this.Controls.Add(createDiv);
                

                if (DayOfWeek == "Monday")
                {
                    Monday.Controls.Add(createDiv);
                    return Monday;
                }
                else if (DayOfWeek == "Tuesday")
                {
                    Tuesday.Controls.Add(createDiv);
                    return Tuesday;
                }
                else if (DayOfWeek == "Wednesday")
                {
                    Wednesday.Controls.Add(createDiv);
                    return Wednesday;
                }
                else if (DayOfWeek == "Thursday")
                {
                    Thursday.Controls.Add(createDiv);
                    return Thursday;
                }
                else if (DayOfWeek == "Friday")
                {
                    Friday.Controls.Add(createDiv);
                    return Friday;
                }
                else if (DayOfWeek == "Saturday")
                {
                    Saturday.Controls.Add(createDiv);
                    return Saturday;
                }
                else 
                {
                    Sunday.Controls.Add(createDiv);
                    return Sunday;
                }
            }
            return this;
            
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

       
    }
}