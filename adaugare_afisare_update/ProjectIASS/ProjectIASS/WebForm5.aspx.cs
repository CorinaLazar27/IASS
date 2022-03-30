using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectIASS
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\SQL_Demo;Initial Catalog=IASS;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            labelLogare.Text = "User logat: " + (string)Application["numeUser"];
            string cnp = (string)Application["cnpPacient"];

            try
            {

                SqlDataAdapter da = new SqlDataAdapter("SELECT Medicamente as [Medicament], Indicatii as [Indicatii] FROM Retete WHERE CnpPacient = '" + cnp + "' ORDER BY Medicamente", con);

                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }
    }
}