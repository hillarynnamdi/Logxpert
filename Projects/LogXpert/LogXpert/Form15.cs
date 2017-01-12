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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox7_Click(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                if (textBox1.Text == "Enter License Key")
                {
                    textBox1.Clear();
                    textBox1.Focus();
                    textBox1.ForeColor = Color.Black;
                    textBox1.UseSystemPasswordChar = true;
                }
                else
                {
                    textBox1.Focus();
                    textBox1.ForeColor = Color.Black;
                    textBox1.UseSystemPasswordChar = true;
                }
            }
            else if (checkBox7.Checked == false)
            {
                textBox1.UseSystemPasswordChar = false;
                textBox1.ForeColor = Color.Black;


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
      

            int strlrn = textBox1.Text.Trim().Length;
            if (textBox1.Text.ToLower() == "1112131415161718")
            {
                
                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");

                XmlNodeList xl = xd.SelectNodes("//user");

                foreach (XmlNode node in xl)
                {
                    node.SelectSingleNode("Activated").InnerText = "Yes";
                    xd.Save("useraccount.xml");
                }
                button7.Text = "Activated!";
                textBox1.Enabled = false;
                groupBox8.Enabled = false;
                this.Close();
                MessageBox.Show("Activated", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);


                if (File.Exists("messages.xml"))
                {

                    XmlDocument xdmsg = new XmlDocument();
                    xdmsg.Load("messages.xml");

                    XmlElement xe = xdmsg.CreateElement("message");

                    XmlDocument xds = new XmlDocument();
                    xds.Load("useraccount.xml");
                    XmlNodeList xls = xd.SelectNodes("//user");

                    foreach (XmlNode node in xls)
                    {
                        string name = node.SelectSingleNode("LastName").InnerText;

                        XmlElement messages = xdmsg.CreateElement("Notification");
                        messages.InnerText = "Hi " + name + ",this software was activated successfully!";
                        xe.AppendChild(messages);

                    }

                    XmlElement date = xdmsg.CreateElement("DateTime");
                    date.InnerText = DateTime.Now.ToString();
                    xe.AppendChild(date);

                    XmlElement type = xdmsg.CreateElement("Type");
                    type.InnerText = "Activion Status";
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

                    foreach (XmlNode node in xls)
                    {
                        string name = node.SelectSingleNode("LastName").InnerText;
                        string msg = "Hi " + name + ",this software was activated successfully!";
                        xwriter.WriteElementString("Notification", msg);
                    }




                    xwriter.WriteElementString("DateTime", DateTime.Now.ToString());
                    xwriter.WriteElementString("Type", "Activation Status");
                    xwriter.WriteElementString("Status", "Unread");
                    xwriter.WriteEndElement();
                    xwriter.WriteEndElement();
                    xwriter.WriteEndDocument();
                    xwriter.Close();
                }


            }
            else if (strlrn == 16 && textBox5.Text.ToLower() != "1112131415161718")
            {
                MessageBox.Show("Incorrect License Key,please contact +234-813-198-4-208", "Licensor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "Enter License Key")
            {
                textBox1.Clear();
                textBox1.ForeColor = Color.Black;

            }


        }
    }
}
