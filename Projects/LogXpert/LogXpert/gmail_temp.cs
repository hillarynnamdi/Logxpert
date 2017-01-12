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

namespace LogXpert
{
    public partial class gmail_temp : Form
    {
        public gmail_temp(string email)
        {
            InitializeComponent();
            textBox1.Text = email;
            textBox2.Focus();
        }

        private void gmail_temp_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox4.Hide();
            pictureBox2.Show();
            textBox2.Enabled = true;
            textBox2.Focus();
            timer1.Stop();
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox2.Text.Trim().Length > 4)
            {
                button1.Enabled = true;
            }
            else
            {
               button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "BACKING UP...";
            button1.Enabled = false;
            string email = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            
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
                    mail.From = new MailAddress(email);

                    mail.Subject = "LogXpert-BackUp";
                    mail.Body = "This is a copy of all your personal information/accounts on LogXpert application.";

                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment("accounts.xml");
                    mail.Attachments.Add(attachment);


                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(email, password);
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
                    MessageBox.Show("Please check the following and try again:\n\n 1. Your Gmail Password \n\n 2. Your Internet Connection \n\n 3. Your Data Bundle", "LogXpert", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                }
            
            
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
