using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ProjectIASS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection("Data Source=DESKTOP-JN36OI3\\MSSQLSERVER01;Initial Catalog=IASS;Integrated Security=True");
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\SQL_Demo;Initial Catalog=IASS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("select NumeUtilizator from Users", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DropDownList1.Items.Add(dr[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Label1.Text = "Conexiune esuata " + ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select Parola from Users where NumeUtilizator='" + DropDownList1.Text +
               "'", con);
                dr = cmd.ExecuteReader();
                if (!dr.Read())
                {
                    Label1.Text = "Datele sunt gresite!";
                }
                else
                {
                    string url;
                    if (dr[0].ToString().Trim() == TextBox1.Text.Trim())
                    {
                        Application["numeUser"] = DropDownList1.Text;
                        url = "WebForm2.aspx";
                        Response.Redirect(url);
                    }
                    else
                    {
                        Label1.Text = "Parola gresita!";
                    }
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "Nu se poate realiza conexiunea " + ex.Message;
            }
            finally
            {
                con.Close();
            }

        }
    }
}