using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Xml;

namespace LogXpert
{
    public partial class verifyemail : Form
    {


        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);

        public verifyemail(string email,string type)
        {
            InitializeComponent();
          
                textBox1.Text = email;
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to verify later?", "Verification Confirmation", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (DialogResult.Yes == res)
            {
                this.Hide();

    
                Form1 frms = new Form1("");
                frms.Hide();

                success frm = new success();
                frm.Show();
            }
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            XmlDocument xd = new XmlDocument();
            xd.Load("useraccount.xml");

            XmlNodeList xl = xd.SelectNodes("//user");


            Random rnd1 = new Random();
            string ran = rnd1.Next(10000, 100000).ToString();
            try
            {
              
               

                MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("hillarynnamdievans@gmail.com");
            mail.To.Add(textBox1.Text);
            mail.Subject = "LogXpert-Password Reset";

                button1.Text = "Sending...";
                button1.Enabled = false;

            foreach (XmlNode node in xl)
            {

                string fname = node.SelectSingleNode("FirstName").InnerText;
                string lname = node.SelectSingleNode("LastName").InnerText;
                                   
                string ran2 = node.SelectSingleNode("VerificationCode").InnerText;
                mail.Body = "Hi " + fname + " " + lname + ",your Password Reset code is " + ran;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("hillarynnamdievans@gmail.com", "hillarynnamdi");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                    node.SelectSingleNode("VerificationSent").InnerText = "Yes";
                    node.SelectSingleNode("VerificationCode").InnerText = ran;
                    xd.Save("useraccount.xml");
                }




                
                //message
                if (File.Exists("messages.xml"))
                {

                    XmlDocument xdmsg = new XmlDocument();
                    xdmsg.Load("messages.xml");

                    XmlElement xe = xdmsg.CreateElement("message");

                    XmlDocument xds = new XmlDocument();
                    xds.Load("useraccount.xml");
                    XmlNodeList xls = xd.SelectNodes("//user");

                    foreach (XmlNode nodes in xls)
                    {

                        string name = nodes.SelectSingleNode("LastName").InnerText;
                        

                        XmlElement messages = xdmsg.CreateElement("Notification");
                        messages.InnerText = "Hi " + name + ",your Password Reset code  was sent successfully!";





                        xe.AppendChild(messages);

                    }

                    XmlElement date = xdmsg.CreateElement("DateTime");
                    date.InnerText = DateTime.Now.ToString();
                    xe.AppendChild(date);

                    XmlElement type = xdmsg.CreateElement("Type");
                    type.InnerText = "Account Recovery";
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
                        string name = nodes.SelectSingleNode("FirstName").InnerText;
                        string msg = "Hi " + name + ",your Password Reset code  was sent successfully!";
                        xwriter.WriteElementString("Notification", msg);
                    }




                    xwriter.WriteElementString("DateTime", DateTime.Now.ToString());
                    xwriter.WriteElementString("Type", "Account Recovery");
                    xwriter.WriteElementString("Status", "Unread");
                    xwriter.WriteEndElement();
                    xwriter.WriteEndElement();
                    xwriter.WriteEndDocument();
                    xwriter.Close();
                }

                //message stops


                this.Close();

                XmlDocument xdmsgs = new XmlDocument();
                xdmsgs.Load("useraccount.xml");

                XmlNodeList xlss = xdmsgs.SelectNodes("//user");

                foreach (XmlNode nodes in xlss)
                {
                    nodes.SelectSingleNode("VerificationSent").InnerText = "Yes";
                    xdmsgs.Save("useraccount.xml");

                }


                Form5 frm = new Form5();

               DialogResult res= frm.ShowDialog();
                if (res == DialogResult.OK)
                {                
                    changepassword frms = new changepassword();
                    frms.ShowDialog();

                }
                else if (res == DialogResult.No)
                {
                    foreach (XmlNode nodes in xlss)
                    {
                        string email = nodes.SelectSingleNode("Email").InnerText;

                        verifyemail frms = new verifyemail(email, "");
                        frms.ShowDialog();
                        

                    }
                }

            }


            catch (SmtpException)
            {
                button1.Enabled = true;
                button1.Text = "Send";
                MessageBox.Show("Double Check your connection and data availability and try again!!","Verification code not sent",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

             
           

        }


        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox1.Enabled = true;
            textBox1.Focus();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string pattern = null;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (!Regex.Match(textBox1.Text.Trim(),pattern).Success || textBox1.Text.Trim()=="")
            {
                textBox1.BackColor = Color.Red;
                textBox1.ForeColor = Color.WhiteSmoke;
                button1.Enabled = false;
            }
            else
            {
                textBox1.BackColor = Color.White;
                textBox1.ForeColor = Color.Black;
                button1.Enabled = true;

            }
        }

        private void verifyemail_Load(object sender, EventArgs e)
        {
            

            timer1.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                // MessageBox.Show("Connected !");
                pictureBox1.Show();
                label1.Show();
                pictureBox2.Hide();
                label2.Hide();
                button1.Enabled = true;

            }
            else
            {
                // MessageBox.Show("Not Connected !");
                pictureBox2.Show();
                label2.Show();
                pictureBox1.Hide();
                label1.Hide();
                button1.Enabled = false;
            }
        }
    }
}
