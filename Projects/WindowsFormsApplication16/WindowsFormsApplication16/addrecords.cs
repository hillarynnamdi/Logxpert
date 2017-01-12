using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace WindowsFormsApplication16
{
    public partial class addrecords : Form
    {
        public addrecords()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists("customers.xml"))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter write = XmlWriter.Create("customers.xml", settings);
                write.WriteStartDocument(true);
                write.WriteStartElement("customers");


                write.WriteEndElement();
                write.WriteEndDocument();

                write.Close();


                XmlDocument xd = new XmlDocument();
                xd.Load("customers.xml");


                XmlElement xm = xd.CreateElement("customer");

                XmlElement first = xd.CreateElement("FirstName");
                first.InnerText = textBox1.Text;
                xm.AppendChild(first);

                XmlElement last = xd.CreateElement("LastName");
                last.InnerText = textBox2.Text;
                xm.AppendChild(last);

                XmlElement email = xd.CreateElement("Email");
                email.InnerText = textBox3.Text;
                xm.AppendChild(email);

                XmlElement gender = xd.CreateElement("Gender");
                gender.InnerText = radioButton1.Text;
                xm.AppendChild(gender);

                xd.DocumentElement.AppendChild(xm);


                xd.Save("customers.xml");

            }
            else
            {
                

                DataSet ds = new DataSet();
                ds.ReadXml("customers.xml");

                DataView dv = new DataView(ds.Tables[0]);
                dv.Sort = "Email";
                int find = dv.Find(textBox3.Text.Trim());
                if (find == -1)
                {



                    XmlDocument xd = new XmlDocument();
                    xd.Load("customers.xml");
                    XmlElement xm = xd.CreateElement("customer");

                    XmlElement first = xd.CreateElement("FirstName");
                    first.InnerText = textBox1.Text;
                    xm.AppendChild(first);

                    XmlElement last = xd.CreateElement("LastName");
                    last.InnerText = textBox2.Text;
                    xm.AppendChild(last);

                    XmlElement email = xd.CreateElement("Email");
                    email.InnerText = textBox3.Text;
                    xm.AppendChild(email);

                    XmlElement gender = xd.CreateElement("Gender");
                    gender.InnerText = radioButton1.Text;
                    xm.AppendChild(gender);

                    xd.DocumentElement.AppendChild(xm);

                    xd.Save("customers.xml");


                }
                else
                {
                    MessageBox.Show("A user with " + textBox3.Text + " email exist already!");
                }
                

            }

            

        }
    }
}
