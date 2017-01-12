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
using System.Net.Mail;
using System.Net;

namespace LogXpert
{
    public partial class yahoo_temp : Form
    {
        public yahoo_temp(string email)
        {
            InitializeComponent();
            textBox1.Text = email;
            
        }

        private void yahoo_temp_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox3.Hide();
            button1.Enabled = true;
           
            timer1.Stop();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "BACKING UP...";
            button1.Enabled = false;
            
            try
            {
                MailMessage mail = new MailMessage();
                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");

                XmlNodeList xl = xd.SelectNodes("//user");
                foreach (XmlNode node in xl)
                {
                    string emails = node.SelectSingleNode("Email").InnerText;
                    mail.To.Add(emails);
                }

                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("hillarynnamdievans@gmail.com");

                mail.Subject = "LogXpert-BackUp";
                mail.Body = "This is a copy of all your personal information/accounts on LogXpert application.";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment("accounts.xml");
                mail.Attachments.Add(attachment);


                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("hillarynnamdievans@gmail.com", "hillarynnamdi");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                DialogResult res = MessageBox.Show("Backup Was Successful!", "LogXpert", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (res == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }


             



            }
            catch (Exception)
            {
                button1.Text = "BACK UP";
                button1.Enabled = true;
                MessageBox.Show("Please check the following and try again:\n\n 1. Your Internet Connection \n\n 2. Your Data Bundle", "LogXpert", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }

        }
    }
}
