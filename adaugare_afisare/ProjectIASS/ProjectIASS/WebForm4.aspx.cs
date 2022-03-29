using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectIASS
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            labelLogare.Text = "User logat: " + (string)Application["numeUser"];
        }

        protected void Buton1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\SQL_Demo;Initial Catalog=IASS;Integrated Security=True");
            SqlCommand cmd;
            if (TextBox1.Text.ToString().Length != 13)
            {
                Label1.Text = "CNP incorect";
            }
            else
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand("insert into Pacienti (CNP,Nume,Prenume,Diagnostic) values(@cnp, @nume, @prenume, @diagnostic) ", conn);

                    cmd.Parameters.AddWithValue("@cnp", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@nume", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@prenume", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@diagnostic", TextBox4.Text.Trim());
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        string url = "WebForm2.aspx";
                        Response.Redirect(url);
                    }
                    else
                        LabelEroare.Text = "Eroare inserare!";
                }
                 catch (Exception ex)
                {
                    LabelEroare.Text = "Eroare la deschidere baza date " + ex.Message;
                }
                //adaugarea datelor
                finally
                {
                    conn.Close();
                }

            }
        }
    }
}