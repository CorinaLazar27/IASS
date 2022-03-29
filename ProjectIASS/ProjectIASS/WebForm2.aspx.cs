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
using System.Xml.Linq;

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
            string email = "2";
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

            try
            {
                con.Open();
                cmd = new SqlCommand("select Email from Pacienti where cnp='" + cnp_pacient + "'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    email = dr[0].ToString();
                }

                Label1.Text = email;
            }
            catch (Exception ex)
            {
                Label1.Text = "nu se poate obtine mail-ul pacientului" + ex;
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
                message.To.Add(new MailAddress(email));
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            var cnp_cautat = TextBox1.Text;
            string nume, prenume, diagnostic, numar, medicament, indicatii;

            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 5, 5);
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-PF9DAIU5\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;");
            SqlCommand cmd;
            SqlDataReader dr;
            try
            {
                con.Open();
                cmd = new SqlCommand("select Nume, Prenume, Diagnostic from Pacienti where CNP='" + cnp_cautat + "'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    nume = dr[0].ToString();
                    prenume = dr[1].ToString();
                    diagnostic = dr[2].ToString();
                    TextBox1.Text = "Nume: "+ nume +"\n"+ "Prenume: "+prenume +"\n"+ "Diagnostic: "+diagnostic+"\n";
                }
            }
            catch (Exception ex)
            {
                Label2.Text = cnp_cautat + "Conexiune esuata" + ex;
            }
            finally
            {
                con.Close();
            }

            try
            {
                con.Open();
                cmd = new SqlCommand("select numar, medicament, indicati from Reteta where cnp='" + cnp_cautat + "'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    numar = dr[0].ToString();
                    medicament = dr[1].ToString();
                    indicatii = dr[2].ToString();
                    TextBox1.Text = TextBox1.Text+"Numar reteta: "+ numar+"\n" +"Medicament: " + medicament+"\n"+"Indicatii: " + indicatii;
                }
            }
            catch (Exception ex)
            {
                Label2.Text = cnp_cautat + "Conexiune esuata baza reteta" + ex;
            }
            finally
            {
                con.Close();
            }

            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            var cnp_stergere = TextBox1.Text;
            

            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 5, 5);
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-PF9DAIU5\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;");
            SqlCommand cmd;
            SqlDataReader dr;
            try
            {
                con.Open();
                cmd = new SqlCommand("delete from Pacienti where Pacienti.CNP='" + cnp_stergere + "'", con);
                dr = cmd.ExecuteReader();
            
            }
            catch (Exception ex)
            {
                Label2.Text = cnp_stergere + "Conexiune esuata" + ex;
            }
            finally
            {
                con.Close();
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            var cnp_xml = TextBox1.Text;
            string nume= "1", prenume="2", diagnostic="2", numar="2", medicament="3", indicatii = "2", email="2";
            XDocument doc;
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-PF9DAIU5\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;");
            SqlCommand cmd;
            SqlDataReader dr;
            try
            {
                con.Open();
                cmd = new SqlCommand("select Nume, Prenume, Diagnostic, Email from Pacienti where CNP='" + cnp_xml + "'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    nume = dr[0].ToString();
                    prenume = dr[1].ToString();
                    diagnostic = dr[2].ToString();
                    email = dr[3].ToString();
                }
            }
            catch (Exception ex)
            {
                Label2.Text = cnp_xml + "Conexiune esuata" + ex;
            }
            finally
            {
                con.Close();
            }

            try
            {
                con.Open();
                cmd = new SqlCommand("select numar, medicament, indicati from Reteta where cnp='" + cnp_xml + "'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    numar = dr[0].ToString();
                    medicament = dr[1].ToString();
                    indicatii = dr[2].ToString();
                    TextBox1.Text = "XML generat reusit";
                    
                }
            }
            catch (Exception ex)
            {
                Label2.Text = cnp_xml + "Conexiune esuata baza reteta" + ex;
            }
            finally
            {
                con.Close();
            }

            doc = new XDocument(new XElement("Farmacie",
                                           new XElement("Pacienti",
                                               new XElement("nume", nume),
                                               new XElement("prenume", prenume),
                                               new XElement("diagnostic", diagnostic),
                                               new XElement("email",email)),
                                           new XElement("Reteta",
                                           new XElement("medicament",medicament),
                                           new XElement("indicatii",indicatii))));
            doc.Save("C:\\Users\\hamat\\OneDrive\\Documente\\Facultate\\Anul 4\\sem2\\IASS\\lab\\IASS\\ProjectIASS\\"+cnp_xml + ".xml");

        }
    }
}