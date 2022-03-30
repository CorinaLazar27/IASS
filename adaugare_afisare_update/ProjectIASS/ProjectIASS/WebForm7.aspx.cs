using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectIASS
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            labelLogare.Text = "User logat: " + (string)Application["numeUser"];
        }

        protected void Buton1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\SQL_Demo;Initial Catalog=IASS;Integrated Security=True");
            SqlCommand cmd;
            if (TextBox1.Text.ToString().Trim().Length == 0)
            {
                Label1.Text = "Denumirea trebuie introdusa";
            }
            else
            {
                try
                {
                    conn.Open();
                    cmd = new SqlCommand("insert into Medicamente (Denumire,Stoc) values(@denumire, @stoc) ", conn);

                    cmd.Parameters.AddWithValue("@denumire", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@stoc", TextBox2.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        string url = "WebForm6.aspx";
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