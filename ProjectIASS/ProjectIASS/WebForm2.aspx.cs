using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace ProjectIASS
{
    
    public partial class WebForm2 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            String nume = Request.QueryString["utilizator"];
          

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var cnp_pacient = ListBox1.SelectedItem.Text;
            string numar="2";
            string medicament="2";
            string indicatii="2";
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 5, 5);
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-PF9DAIU5\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;");
            SqlCommand cmd;
            SqlDataReader dr;
            try
            {
                con.Open();
                cmd = new SqlCommand("select numar,medicament,indicati from Reteta where cnp='"+ cnp_pacient+"'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    numar = dr[0].ToString();
                    medicament = dr[1].ToString();
                    indicatii = dr[2].ToString();
                }
            }
            catch (Exception ex)
            {
                Label1.Text = cnp_pacient+"Conexiune esuata" + ex;
            }
            finally
            {
                con.Close();
            }
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\hamat\\OneDrive\\Documente\\Facultate\\Anul 4\\sem2\\IASS\\lab\\IASS\\ProjectIASS\\"+cnp_pacient + ".pdf", FileMode.Create));
            doc.Open();
            Paragraph para = new Paragraph("Numar reteta: " + numar + "\nMedicament: " + medicament + "\nIndicatii: " + indicatii);
            doc.Add(para);
            doc.Close();

            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("iassissa3@gmail.com");
                message.To.Add(new MailAddress("hamatila7@gmail.com"));
                message.Subject = "Reteta dumneavoastra";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = "In urma achizitie din reteaua noastra de farmacii va trimitem atasat si reteta cu modul de administrare si indicatiile medicamentelor.";
                message.Attachments.Add(new Attachment("C:\\Users\\hamat\\OneDrive\\Documente\\Facultate\\Anul 4\\sem2\\IASS\\lab\\IASS\\ProjectIASS\\" + cnp_pacient + ".pdf"));
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("iassissa3@gmail.com", "iasstest1!");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception r) {

                Label1.Text = "nu s-a trimis mail "+r;
            }
        

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-PF9DAIU5\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;");
            SqlCommand cmd;
            SqlDataReader dr;
            ListBox1.Items.Clear();
            try
            {
                con.Open();
                cmd = new SqlCommand("select CNP from Pacienti", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ListBox1.Items.Add(dr[0].ToString());
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "Conexiune esuata" + ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}