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

namespace LogXpert
{
    public partial class emailverifier : Form
    {
        public emailverifier()
        {
            InitializeComponent();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
           

            XmlDocument doc = new XmlDocument();
            doc.Load("useraccount.xml");

            XmlNodeList nl = doc.SelectNodes("//user");

            foreach (XmlNode node in nl)
            {
                string vcode = node.SelectSingleNode("VerificationCode").InnerText;
                int vcodelen = vcode.Length;
                if (textBox1.TextLength == vcodelen)
                {
                    if (textBox1.Text.Trim() == vcode)
                    {
                        textBox1.Enabled = false;
                        pictureBox1.Show();
                        pictureBox2.Hide();
                        button1.Show();
                        linkLabel1.Hide();
                        node.SelectSingleNode("Verification").InnerText = "True";
                        doc.Save("useraccount.xml");

                        //message
                        if (File.Exists("messages.xml"))
                        {

                            XmlDocument xdmsg = new XmlDocument();
                            xdmsg.Load("messages.xml");

                            XmlElement xe = xdmsg.CreateElement("message");

                            XmlDocument xds = new XmlDocument();
                            xds.Load("useraccount.xml");
                            XmlNodeList xls = xds.SelectNodes("//user");

                            foreach (XmlNode nodes in xls)
                            {

                                string name = nodes.SelectSingleNode("FirstName").InnerText;


                                XmlElement messages = xdmsg.CreateElement("Notification");
                                messages.InnerText = "Hello " + name + ",your Email has been verified!"; ;





                                xe.AppendChild(messages);

                            }

                            XmlElement date = xdmsg.CreateElement("DateTime");
                            date.InnerText = DateTime.Now.ToString();
                            xe.AppendChild(date);

                            XmlElement type = xdmsg.CreateElement("Type");
                            type.InnerText = "E-mail Verification";
                            xe.AppendChild(type);

                            XmlElement status = xdmsg.CreateElement("Status");
                            status.InnerText = "Unread";
                            xe.AppendChild(status);

                            xdmsg.DocumentElement.AppendChild(xe);

                            xdmsg.Save("messages.xml");

                        }
                        else
                        {

                            XmlWriterSettings setting = new XmlWriterSettings();
                            setting.Indent = true;
                            XmlWriter xwriter = XmlWriter.Create("messages.xml", setting);

                            xwriter.WriteStartDocument(true);
                            xwriter.WriteStartElement("messages");
                            xwriter.WriteStartElement("message");

                            XmlDocument xdmsg = new XmlDocument();
                            xdmsg.Load("useraccount.xml");

                            XmlElement xe = xdmsg.CreateElement("message");

                            XmlNodeList xls = xdmsg.SelectNodes("//user");

                            foreach (XmlNode nodes in xls)
                            {
                                string name = nodes.SelectSingleNode("LastName").InnerText;
                                string msg = "Hello " + name + ",your Email has been verified!";
                                xwriter.WriteElementString("Notification", msg);
                            }




                            xwriter.WriteElementString("DateTime", DateTime.Now.ToString());
                            xwriter.WriteElementString("Type", "Email Verification");
                            xwriter.WriteElementString("Status", "Unread");
                            xwriter.WriteEndElement();
                            xwriter.WriteEndElement();
                            xwriter.WriteEndDocument();
                            xwriter.Close();
                        }

                        //message stops

                    }
                    else
                    {

                        pictureBox2.Show();
                        pictureBox1.Hide();

                    }
    
                }
            }
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
