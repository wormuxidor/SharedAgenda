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

        private bool checkDetails()
        {
            Boolean isRight = false;
            String user = emailBox.Text;
            String password = passwordBox.Text;

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("pwCompare", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add("pwhash", SqlDbType.NVarChar).Value = this.sha256_hash(password);
            command.Parameters.Add("email", SqlDbType.NVarChar).Value = user;
            conn.Open();

            using (SqlDataAdapter sda = new SqlDataAdapter(command))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DataRow row = dt.Rows[0];
                int result = Convert.ToInt32(row.ItemArray[0]);
                if (result == 1)
                {
                    isRight = true;
                }
                conn.Close();

            }
            if (isRight == true)
            {
                return true;
            }
            else
            {
                return false;
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
            if (this.checkDetails())
            {
                FormsAuthentication.RedirectFromLoginPage(emailBox.Text);
            }
            else
            {
                Label lbl = loginRow2StatusLabel;
                lbl.BackColor = Color.Red;
                lbl.ForeColor = Color.White;
                lbl.Text = "Username oder Passwort ist falsch.....";
            }
        }
    }
}