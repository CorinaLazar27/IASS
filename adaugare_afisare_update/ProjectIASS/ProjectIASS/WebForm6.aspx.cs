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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            labelLogare.Text = "User logat: " + (string)Application["numeUser"];
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\SQL_Demo;Initial Catalog=IASS;Integrated Security=True");

            try
            {

                SqlDataAdapter da = new SqlDataAdapter("SELECT IdMedicament as [Nr.Crt], Denumire as [Denumire], Stoc as [Numar bucati] FROM Medicamente ORDER BY IdMedicament", con);

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

        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                    row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                    row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + row.DataItemIndex, true);
                    row.Style.Add(HtmlTextWriterStyle.Cursor, "pointer");
                }
            }
            base.Render(writer);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int aparitii = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.Cells[1].Text != null && row.Cells[1].Text.Trim() == TextBox1.Text.Trim())
                {
                    GridView1.SelectedIndex = row.RowIndex;
                    Button3.Enabled = true; //butonul de stergere
                    Button4.Enabled = true; //butonul de modificare
                    Application["idMed"] = Convert.ToInt32(row.Cells[0].Text);
                    aparitii++;
                }
            }
            if (aparitii > 0)
            {
                LabelCautare.Text = "";
            }
            else
            {
                LabelCautare.Text = "Medicamentul nu exista in baza de date";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //modificare stoc
            string url;
            url = "WebForm8.aspx";
            Response.Redirect(url);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //logica stergere
            string url;
            url = "WebForm6.aspx";
            Response.Redirect(url);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //adaugare medicament
            string url;
            url = "WebForm7.aspx";
            Response.Redirect(url);
        }

    }
}