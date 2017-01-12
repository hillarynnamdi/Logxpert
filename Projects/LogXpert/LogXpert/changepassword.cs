using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LogXpert
{
    public partial class changepassword : Form
    {
        public changepassword()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Password")
            {
                textBox1.Clear();
                textBox1.Multiline = false;
                textBox1.ForeColor = Color.Black;


            }
            password_error.Hide();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                textBox1.Multiline = true;
                textBox1.Text = "Password";
                textBox1.ForeColor = Color.Silver;

            }

            string pass = textBox1.Text;
            if (pass == "Password")
            {
                password_error.Show();
                password_error.Text = "*password is required";
            }
            else if (pass.Length <= 5)
            {
                password_error.Show();
                password_error.Text = "*password must be at least six(6) chars long.";
            }
            else if (!Regex.Match(pass, "^[a-zA-Z0-9_*]*$").Success)
            {
                password_error.Show();
                password_error.Text = "password must contain only [ a-z/A-Z/0-9/_/* ]";
            }
        }


        private void textBox2_Enter(object sender, EventArgs e)
        {

            if (textBox2.Text == "Confirm Password")
            {
                textBox2.Clear();
                textBox2.Multiline = false;
                textBox2.ForeColor = Color.Black;


            }
            password_conf_error.Hide();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                textBox2.Multiline = true;
                textBox2.Text = "Confirm Password";
                textBox2.ForeColor = Color.Silver;

            }

            string confirm = textBox2.Text;
            string pass = textBox1.Text;
            if (confirm == "Confirm Password")
            {
                password_conf_error.Show();
                password_conf_error.Text = "*password confirmation is required";
            }
            else if (pass.Length>0 && pass != confirm)
            {
                password_conf_error.Show();
                password_conf_error.Text = "*password confirm. does not match password";
            }



        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string text = textBox1.Text.Trim();
            if (text.Length > 2)
            {
                textBox2.Enabled = true;
            }
            else if(text.Length==0)
            {
                textBox2.Multiline = true;
                textBox2.Text = "Confirm Password";
                textBox2.Enabled = false;
                textBox2.ForeColor = Color.Silver;
                password_conf_error.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string pass = textBox1.Text.Trim();
            string conf = textBox2.Text.Trim();


            if ((pass != "" || pass != "Password") &&
                pass == conf && pass.Length > 5 && Regex.Match(pass, "^[a-zA-Z0-9_*]*$").Success)
            {

                button1.Hide();
                button2.Hide();
                button3.Show();

                textBox1.Enabled = false;
                textBox2.Enabled = false;

                

                XmlDocument xd = new XmlDocument();
            xd.Load("useraccount.xml");

            XmlNodeList xl = xd.SelectNodes("//user");

                foreach (XmlNode node in xl)
                {

                    node.SelectSingleNode("Password").InnerText = textBox1.Text.Trim();
                    xd.Save("useraccount.xml");
                    string name = node.SelectSingleNode("FirstName").InnerText;
                   
                }


                //"messages.xml"
                

                if (File.Exists("messages.xml")){

                    XmlDocument xdmsg = new XmlDocument();
                    xdmsg.Load("messages.xml");

                    XmlElement xe = xdmsg.CreateElement("message");

                    XmlDocument xds= new XmlDocument();
                    xds.Load("useraccount.xml");
                    XmlNodeList xls = xd.SelectNodes("//user");

                    foreach (XmlNode node in xls)
                    {
                        string name = node.SelectSingleNode("LastName").InnerText;

                        XmlElement messages = xdmsg.CreateElement("Notification");
                        messages.InnerText = "Hi "+name+",your password was changed successfully!";
                        xe.AppendChild(messages);

                    }

                    XmlElement date = xdmsg.CreateElement("DateTime");
                    date.InnerText = DateTime.Now.ToString();
                   xe.AppendChild(date);

                    XmlElement type = xdmsg.CreateElement("Type");
                    type.InnerText = "Activity Log";
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
                        string msg = "Hi " + name + ",your password was changed successfully!";
                        xwriter.WriteElementString("Notification", msg);
                    }



                    
                    xwriter.WriteElementString("DateTime", DateTime.Now.ToString());
                    xwriter.WriteElementString("Type", "Activity Log");
                    xwriter.WriteElementString("Status", "Unread");
                    xwriter.WriteEndElement();
                    xwriter.WriteEndElement();
                    xwriter.WriteEndDocument();
                    xwriter.Close();
                }

                //"messages.xml" stops


            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.UseSystemPasswordChar = false;
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox1.UseSystemPasswordChar = true;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
