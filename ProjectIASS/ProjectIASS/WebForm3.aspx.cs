using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace ProjectIASS
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument xmlSursa = new XmlDocument();
            string nume_fisier = Request.QueryString["chestionar"];
            // xmlSursa.Load(Server.MapPath("~/Formulare/" + nume_fisier + ".xml"));
            xmlSursa.Load(Server.MapPath("~/Formulare/clienti.xml"));
        
            XmlNodeList nodes2 = xmlSursa.SelectNodes("//Chestionar//textbox");
            foreach (XmlNode text in nodes2)
            {
                string idr = text.Attributes["detalii"].Value;
                PlaceHolder1.Controls.Add(new LiteralControl("<p/>" + idr));
                ///textBox generat
                TextBox txt = new TextBox();
                txt.ID = text.Attributes["nume"].Value;
                txt.Text = "";
                PlaceHolder1.Controls.Add(new LiteralControl("<p/>"));
                PlaceHolder1.Controls.Add(txt);
            }
            
            XmlNodeList nodes = xmlSursa.SelectNodes("//Chestionar//radio");
            foreach (XmlNode radio in nodes)
            {
                string idr = radio.Attributes["detalii"].Value;
                PlaceHolder1.Controls.Add(new LiteralControl("<p/>" + idr));
                RadioButtonList new_radio = new RadioButtonList();
                new_radio.ID = radio.Attributes["nume"].Value;
                XmlNodeList valori = radio.ChildNodes;
                foreach (XmlNode valoare in valori)
                {
                    string val = valoare.InnerText;
                    new_radio.Items.Add(val);
                }
                new_radio.RepeatDirection = RepeatDirection.Horizontal;
                PlaceHolder1.Controls.Add(new_radio);
            }
        }

        protected void Button1_Click2(object sender, EventArgs e)
        {
            foreach (TextBox txt in PlaceHolder1.Controls.OfType<TextBox>())
            {
                string nume_Control = txt.ID;
                string valoare_Control = txt.Text;
                TextBox1.Text = TextBox1.Text + nume_Control + ":"+
                valoare_Control + Environment.NewLine;
            }
            foreach (RadioButtonList rb in PlaceHolder1.Controls.OfType<RadioButtonList>())
            {
                string nume_Control = rb.ID;
                string valoare_Control = rb.SelectedValue;
                TextBox1.Text = TextBox1.Text + nume_Control+":" +
                valoare_Control + Environment.NewLine;
            }
        }
    }
}