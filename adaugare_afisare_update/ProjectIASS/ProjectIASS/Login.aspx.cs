using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectIASS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] utilizatori = File.ReadAllLines(Server.MapPath("~/Fisiere/") + "utilizatori.txt");
            foreach (var line in utilizatori)
            {
                string[] inregistrare = line.Split(',');
                DropDownList1.Items.Add(inregistrare[0]);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] utilizatori = File.ReadAllLines(Server.MapPath("~/Fisiere/") + "utilizatori.txt");
            foreach (var line in utilizatori)
            {
                string[] inregistrare = line.Split(',');

                if ((DropDownList1.Text).Equals(inregistrare[0]))
                {
                    if (TextBox1.Text.Trim().Equals(inregistrare[1].Trim()))
                    {
                        Response.Redirect("WebForm2.aspx?utilizator=" + DropDownList1.Text.Trim());
                    }
                    else
                    {
                        string script = "alert(\"Parola incorecta!\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
                }
            }

        }
    }
}