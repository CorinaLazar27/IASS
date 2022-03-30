using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectIASS
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\SQL_Demo;Initial Catalog=IASS;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {

            labelLogare.Text = "User logat: " + (string)Application["numeUser"];

            try
            {

                SqlDataAdapter da = new SqlDataAdapter("SELECT CNP as [CNP], Nume as [Nume], Prenume as [Prenume], Diagnostic as [Diagnostic] FROM Pacienti ORDER BY Nume, Prenume", con);

                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                //pentru chestionare
                string[] filePaths = Directory.GetFiles(Server.MapPath("~/Formulare/"));
                foreach (string filePath in filePaths)
                {
                    DropDownList2.Items.Add(new ListItem(Path.GetFileNameWithoutExtension(filePath)));
                }
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
                    Button3.Enabled = true; //butonul de vizionare reteta
                    Button4.Enabled = true; //butonul de chestionare
                    Application["cnpPacient"] = row.Cells[0].Text.Trim();
                    aparitii++;
                }
            }
            if(aparitii > 0)
            {
                LabelCautare.Text = "";
            }
            else
            {
                LabelCautare.Text = "Pacientul nu exista in baza de date";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string url;
            url = "WebForm3.aspx";
            Response.Redirect(url);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //reteta
            string url;
            url = "WebForm5.aspx";
            Response.Redirect(url);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //adaugare pacient
            string url;
            url = "WebForm4.aspx";
            Response.Redirect(url);
        }
    }
}