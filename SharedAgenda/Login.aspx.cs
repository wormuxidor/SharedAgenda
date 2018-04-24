using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SharedAgenda
{
    public partial class Login : System.Web.UI.Page
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void checkDetails()
        {
            Boolean isRight = false;
            String user = usernameBox.Text;
            String password = passwordBox.Text;

            Boolean isAdmin = false;
            Boolean isErweitert = false;

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("getPwhash", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add("inKuerzel", SqlDbType.VarChar).Value = user;
            conn.Open();

            using (SqlDataAdapter sda = new SqlDataAdapter(command))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataRow row = dt.Rows[0];
                string passwordhash = Convert.ToString(row.ItemArray[0]);
                long salt = Convert.ToInt64(row.ItemArray[1]);
                isErweitert = Convert.ToBoolean(row.ItemArray[2]);
                isAdmin = Convert.ToBoolean(row.ItemArray[3]);
                if (passwordhash == this.sha256_hash(password + salt))
                {
                    isRight = true;
                }
                conn.Close();

            }
            if (isRight == true)
            {
                SqlConnection conn2 = new SqlConnection(connectionString);
                string connectionString2 = String.Format("UPDATE Users SET isLoggedIn = 1 WHERE Kuerzel = '{0}';", user);
                SqlCommand command2 = new SqlCommand(connectionString2, conn2);
                conn2.Open();
                int response = command2.ExecuteNonQuery();
                conn2.Close();
                if (response == 1)
                {
                    if (isAdmin)
                    {
                        usernameBox.Enabled = false;
                        passwordBox.Enabled = false;
                        Response.AppendHeader("Refresh", String.Format("1;url=./admin.aspx?id={0}", user));
                    }
                    else if (isErweitert)
                    {
                        usernameBox.Enabled = false;
                        passwordBox.Enabled = false;
                        Response.AppendHeader("Refresh", String.Format("1;url=./reservierenErweitert.aspx?id={0}", user));
                    }
                    else
                    {
                        usernameBox.Enabled = false;
                        passwordBox.Enabled = false;
                        Response.AppendHeader("Refresh", String.Format("1;url=./reservieren.aspx?id={0}", user));
                    }
                }
                else
                {
                    Label lbl = (Label)this.Master.FindControl("lblmsgMaster");
                    lbl.BackColor = Color.Red;
                    lbl.ForeColor = Color.White;
                    lbl.Text = " Es ist ein Fehler aufgetreten.....";
                }


            }
            else
            {
                Label lbl = (Label)this.Master.FindControl("lblmsgMaster");
                lbl.BackColor = Color.Red;
                lbl.ForeColor = Color.White;
                lbl.Text = " Username oder Passwort ist falsch.....";
            }
        }

        private String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        protected void button1_Click(object sender, EventArgs e)
        {
            this.checkDetails();
        }
    }
}