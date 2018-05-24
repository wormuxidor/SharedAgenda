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
            class_list.SelectedIndex = 0;
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
                

                System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
                new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                createDiv.ID = "createDiv" + i;

                createDiv.InnerHtml = Server.HtmlEncode( ds.Tables[0].Rows[i]["KKommentar"].ToString());
                this.Controls.Add(createDiv);

                if (DayOfWeek == "Monday")
                {
                    Monday.Controls.Add(createDiv);
                }
                else if (DayOfWeek == "Tuesday")
                {
                    Tuesday.Controls.Add(createDiv);
                }
                else if (DayOfWeek == "Wednesday")
                {
                    Wednesday.Controls.Add(createDiv);
                }
                else if (DayOfWeek == "Thursday")
                {
                    Thursday.Controls.Add(createDiv);
                }
                else if (DayOfWeek == "Friday")
                {
                    Friday.Controls.Add(createDiv);
                }
                else if (DayOfWeek == "Saturday")
                {
                    Saturday.Controls.Add(createDiv);
                }
                else if (DayOfWeek == "Sunday")
                {
                    Sunday.Controls.Add(createDiv);
                }
            }

                
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

            newDate = newDate.AddDays(+7 * Woche);

            // Woche verrechnen

            return newDate;
        }
    }
}