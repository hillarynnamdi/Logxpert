using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using System.Xml;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.IO;

namespace LogXpert
{
    public partial class Form3 : Form



    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }


        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Last Name")
            {
                textBox2.Clear();
                textBox2.Multiline = false;
                textBox2.ForeColor = Color.Black;

            }

            last_name_error.Hide();
            toolTip1.SetToolTip(textBox2, "Enter Last Name");
        }


        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                textBox2.Text = "Last Name";
                textBox2.Multiline = true;
                textBox2.ForeColor = Color.Silver;
              

            }

            string last = textBox2.Text;
            if (last == "Last Name")
            {
                last_name_error.Show();
                last_name_error.Text = "last name can't be blank*";
            }
            else if (!Regex.Match(last, "^[a-zA-Z]*$").Success)
            {
                last_name_error.Show();
                last_name_error.Text = "invalid last name*";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "First Name")
            {
                textBox1.Clear();
                textBox1.Multiline = false;
                textBox1.ForeColor = Color.Black;
                

            }
            firstname_error.Hide();
            toolTip1.SetToolTip(textBox1,"Enter First Name");

            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            

            if (textBox1.Text.Trim() == "")
            {
                textBox1.Text = "First Name";
                textBox1.Multiline = true;
                textBox1.ForeColor = Color.Silver;

                

            }

            string first = textBox1.Text.Trim();

            if (first == "First Name")
            {
                firstname_error.Show();
                firstname_error.Text = "first name can't be blank*";
            }
            else if (!Regex.Match(first, "^[a-zA-Z]*$").Success)
            {
                firstname_error.Show();
                firstname_error.Text = "invalid first name*";
            }


        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "E-mail address")
            {
                textBox3.Clear();
                textBox3.Multiline = false;
                textBox3.ForeColor = Color.Black;

            }
            email_error.Hide();
            toolTip1.SetToolTip(textBox3, "Enter E-mail Address");
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == "")
            {
                textBox3.Text = "E-mail address";
                textBox3.Multiline = true;
                textBox3.ForeColor = Color.Silver;

            }
           

            string email = textBox3.Text.Trim();
            string pattern = null;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (email == "E-mail address")
            {
                email_error.Show();
                email_error.Text = "a valid e-mail id is required*";
            }
            else if (!Regex.IsMatch(email, pattern))
            {
                email_error.Show();
                email_error.Text = "invalid e-mail id*";
            }


        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Password")
            {
                textBox4.Clear();
                textBox4.Multiline = false;
                textBox4.ForeColor = Color.Black;
            }
            password_error.Hide();
            toolTip1.SetToolTip(textBox4, "Enter a Secured password");
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "")
            {
                textBox4.Text = "Password";
                textBox4.Multiline = true;
                textBox4.ForeColor = Color.Silver;

            }

            string pass = textBox4.Text;
            if (pass == "Password")
            {
                password_error.Show();
                password_error.Text = "password is required*";
            }
            else if (pass.Length <= 5)
            {
                password_error.Show();
                password_error.Text = "password must be at least six(6) chars long.*";
            }
            else if (!Regex.Match(pass, "^[a-zA-Z0-9_]*$").Success)
            {
                password_error.Show();
                password_error.Text = "password must contain only [ a-z/A-Z/0-9/_]";
            }


        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Confirm Password")
            {
                textBox5.Clear();
                textBox5.Multiline = false;
                textBox5.ForeColor = Color.Black;

            }
            password_conf_error.Hide();
            toolTip1.SetToolTip(textBox5, "Re-enter Password");
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim() == "")
            {
                textBox5.Text = "Confirm Password";
                textBox5.Multiline = true;
                textBox5.ForeColor = Color.Silver;

            }

            string confirm = textBox5.Text;
            string pass = textBox4.Text;
            if (confirm == "Confirm Password")
            {
                password_conf_error.Show();
                password_conf_error.Text = "password confirmation is required*";
            }
            else if (pass.Length > 0 && pass != confirm)
            {
                password_conf_error.Show();
                password_conf_error.Text = "password confirm. does not match password*";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "First Name";
            textBox1.ForeColor = Color.Silver;

            textBox2.Text = "Last Name";
            textBox2.ForeColor = Color.Silver;

            textBox3.Text = "E-mail address";
            textBox3.ForeColor = Color.Silver;

            textBox4.Multiline = true;
            textBox4.Text = "Password";
            textBox4.ForeColor = Color.Silver;

            textBox5.Multiline = true;
            textBox5.Text = "Confirm Password";
            textBox5.ForeColor = Color.Silver;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            checkBox1.Checked = false;


            //hide all errorlabels
            firstname_error.Hide();
            last_name_error.Hide();
            gender_error.Hide();
            email_error.Hide();
            password_error.Hide();
            password_conf_error.Hide();
            term_error.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string first = textBox1.Text.Trim();
            string last = textBox2.Text.Trim();
            string email = textBox3.Text.Trim();
            string pass = textBox4.Text.Trim();
            string confirm = textBox5.Text.Trim();
            string pattern = null;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";


            if ((first == "" || first == "First Name") &&
                (last == "" || last == "Last Name") &&
                (email == "" || email == "E-mail address") &&
                (pass == "" || pass == "Password") &&
                (confirm == "" || confirm == "Confirm Password") &&
                (radioButton1.Checked==false) &&
                (radioButton2.Checked == false) &&
                (checkBox1.Checked == false))         
            {
                
            }
            else
            {
                if(first == "First Name")
                {
                    firstname_error.Show();
                    last_name_error.Hide();
                    gender_error.Hide();
                    email_error.Hide();
                    password_error.Hide();
                    password_conf_error.Hide();
                    term_error.Hide();                    
                    firstname_error.Text = "first name can't be blank*";
                    
                }

                else if (!Regex.Match(first, "^[a-zA-Z]*$").Success)
                {
                    firstname_error.Show();
                    last_name_error.Hide();
                    gender_error.Hide();
                    email_error.Hide();
                    password_error.Hide();
                    password_conf_error.Hide();
                    term_error.Hide();
                    firstname_error.Text = "invalid first name*";
                }
               
                else if (last == "Last Name")
                {
                    last_name_error.Show();
                    firstname_error.Hide();
                    gender_error.Hide();
                    email_error.Hide();
                    password_error.Hide();
                    password_conf_error.Hide();
                    term_error.Hide();
                    last_name_error.Text = "last name can't be blank*";

                }

                else if (!Regex.Match(last, "^[a-zA-Z]*$").Success)
                {
                    last_name_error.Show();
                    firstname_error.Hide();
                    gender_error.Hide();
                    email_error.Hide();
                    password_error.Hide();
                    password_conf_error.Hide();
                    term_error.Hide();
                    last_name_error.Text = "invalid last name*";
                }

                else if (radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    gender_error.Show();
                    firstname_error.Hide();
                    last_name_error.Hide();
                    email_error.Hide();
                    password_error.Hide();
                    password_conf_error.Hide();
                    term_error.Hide();
                    gender_error.Text = "select your gender*";
                }
                else if (email == "E-mail address")
                {
                    email_error.Show();
                    firstname_error.Hide();
                    last_name_error.Hide();
                    gender_error.Hide();
                    password_error.Hide();
                    password_conf_error.Hide();
                    term_error.Hide();
                    email_error.Text = "a valid e-mail id is required*";

                }

                else if (!Regex.IsMatch(email, pattern))
                {
                    email_error.Show();
                    email_error.Text = "invalid e-mail id*";
                }

                else if (pass == "Password")
                {
                    password_error.Show();
                    firstname_error.Hide();
                    last_name_error.Hide();
                    gender_error.Hide();
                    email_error.Hide();
                    password_conf_error.Hide();
                    term_error.Hide();
                    password_error.Text = "password is required*";

                }
                else if (pass.Length<=5)
                {
                    password_error.Show();
                    firstname_error.Hide();
                    last_name_error.Hide();
                    gender_error.Hide();
                    email_error.Hide();
                    password_conf_error.Hide();
                    term_error.Hide();
                    password_error.Text = "password must be at least six(6) chars long.*";
                }
                else if (!Regex.Match(pass, "^[a-zA-Z0-9_]*$").Success)
                {
                    password_error.Show();
                    firstname_error.Hide();
                    last_name_error.Hide();
                    gender_error.Hide();
                    email_error.Hide();
                    password_conf_error.Hide();
                    term_error.Hide();
                    password_error.Text = "password must contain only [ a-z/A-Z/0-9/_]";
                }

                else if (confirm == "Confirm Password")
                {
                    password_conf_error.Show();
                    firstname_error.Hide();
                    last_name_error.Hide();
                    gender_error.Hide();
                    email_error.Hide();
                    password_error.Hide();
                    term_error.Hide();
                    password_conf_error.Text = "password confirmation is required*";

                }
                else if (pass!=confirm)
                {
                    password_conf_error.Show();
                    firstname_error.Hide();
                    last_name_error.Hide();
                    gender_error.Hide();
                    email_error.Hide();
                    password_error.Hide();
                    term_error.Hide();
                    password_conf_error.Text = "password confirm. does not match password*";
                }
               
                else if (checkBox1.Checked == false)
                {
                    term_error.Show();
                    firstname_error.Hide();
                    last_name_error.Hide();
                    gender_error.Hide();
                    email_error.Hide();
                    password_error.Hide();
                    password_conf_error.Hide();
                    term_error.Text = "you must agree to logXpert's policies*";
                }
                else if (first != "First Name" &&
                    Regex.Match(first, "^[a-zA-Z]*$").Success &&
                    last != "Last Name" &&
                    Regex.Match(last, "^[a-zA-Z]*$").Success &&
                    (radioButton1.Checked == true || radioButton2.Checked == true) &&
                    email != "E-mail address" &&
                    Regex.IsMatch(email, pattern) &&
                    pass != "Password" &&
                    pass.Length > 5 &&
                    Regex.Match(pass, "^[a-zA-Z0-9_]*$").Success &&
                    confirm != "Confirm Password" &&
                    pass == confirm &&
                    checkBox1.Checked == true)
                    
                    
                {


                    this.Enabled = false;
                    progressBar1.Show();
                    int i = 0;
                    for (i = 0; i <= 300; i++)
                    {
                        progressBar1.Value = i;
                    }



                   

                    timer1.Enabled = true;
                    timer1.Start();

                    
                    



    }

               
               
               


            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender_error.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender_error.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                term_error.Show();
                term_error.Text = "you must agree to logXpert's policies*";
            }
            else
            {
                string nam = textBox1.Text.Trim();
                Form17 frm = new Form17(nam);
                frm.ShowDialog();
                term_error.Hide();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (button1.Text == "Configure")
            {
                button1.Text = "Configuring.";
            }
            else if(button1.Text == "Configuring.")
            {
                button1.Text = "Configuring..";
            }
            else if (button1.Text == "Configuring..")
            {
                button1.Text = "Configuring...";
            }
            else if (button1.Text == "Configuring...")
            {

                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "LogXpert"));

                Directory.SetCurrentDirectory(Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "LogXpert"));

                XmlWriterSettings setting = new XmlWriterSettings();
                setting.Indent = true;

                

                XmlWriter xw = XmlWriter.Create("useraccount.xml", setting);

                xw.WriteStartDocument(true);
                xw.WriteStartElement("user");
                xw.WriteElementString("FirstName", textBox1.Text.Trim());
                xw.WriteElementString("LastName", textBox2.Text.Trim());
                if (radioButton1.Checked == true)
                {
                    xw.WriteElementString("Gender",radioButton1.Text);
                }
                else if(radioButton2.Checked==true)
                {
                    xw.WriteElementString("Gender", radioButton2.Text);
                }
                xw.WriteElementString("Email", textBox3.Text.Trim().ToLower());
                xw.WriteElementString("Password", textBox4.Text.Trim());
                xw.WriteElementString("Verification", "False");
                xw.WriteElementString("VerificationCode", "");
                xw.WriteElementString("VerificationSent", "No");
                xw.WriteElementString("VerificationNotifier", "On");
                xw.WriteElementString("AutoLogin", "Off");
                xw.WriteElementString("MaskPassword", "True");
                xw.WriteElementString("MaskPasswordDialog", "On");                
                xw.WriteElementString("UnmaskingAuthentication", "On");
                xw.WriteElementString("LastBackUp", "");
                xw.WriteElementString("Activated", "No");
                xw.WriteElementString("Remaining", "11");


                xw.WriteEndDocument();
                


                xw.Close();


                








                button1.Text = "Configured";
                progressBar1.Hide();

                DialogResult res=MessageBox.Show("LogXpert Configuration Was Successful!","LogXpert-Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (res ==DialogResult.OK)
                {
                    timer1.Stop();
                    this.Hide();

                    string txt = textBox3.Text;
                    Form1 frm = new Form1(txt);
                    frm.Show();


                    //Sending Mail after configuration

                    int Out;
                    if (InternetGetConnectedState(out Out, 0) == true)
                    {

                        XmlDocument xd = new XmlDocument();
                        xd.Load("useraccount.xml");

                        XmlNodeList xl = xd.SelectNodes("//user");

                        // MessageBox.Show("Connected !");

                        Random rnd1 = new Random();
                        string ran = rnd1.Next(10000, 100000).ToString();
                        try
                        {



                            MailMessage mail = new MailMessage();
                            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                            mail.From = new MailAddress("hillarynnamdievans@gmail.com");
                            
                            mail.Subject = "LogXpert-Set Complete";

                           

                            foreach (XmlNode node in xl)
                            {

                                string fname = node.SelectSingleNode("FirstName").InnerText;
                                string lname = node.SelectSingleNode("LastName").InnerText;
                                string email = node.SelectSingleNode("Email").InnerText;
                                
                                
                                string ran2 = node.SelectSingleNode("VerificationCode").InnerText;
                                mail.To.Add(email);
                                mail.Body = "Hi " + fname + " " + lname + ",your LogXpert's configuration was successful and your email verification code is " + ran;
                                SmtpServer.Port = 587;
                                SmtpServer.Credentials = new System.Net.NetworkCredential("hillarynnamdievans@gmail.com", "hillarynnamdi");
                                SmtpServer.EnableSsl = true;
                                SmtpServer.Send(mail);

                                node.SelectSingleNode("VerificationCode").InnerText = ran;
                                node.SelectSingleNode("VerificationSent").InnerText = "Yes";
                                xd.Save("useraccount.xml");
                            }

                           

                            XmlWriter xwriter = XmlWriter.Create("messages.xml", setting);

                            xwriter.WriteStartDocument(true);
                            xwriter.WriteStartElement("messages");
                            xwriter.WriteStartElement("message");
                            string msg = "Hi " + textBox1.Text.Trim() + ",your application was setup sucessfully.Have a cool cruise!";
                            xwriter.WriteElementString("Notification", msg);
                            xwriter.WriteElementString("DateTime", DateTime.Now.ToString());
                            xwriter.WriteElementString("Type", "Activity Log");
                            xwriter.WriteElementString("Status", "Unread");
                            xwriter.WriteEndElement();
                            xwriter.WriteEndElement();
                            xwriter.WriteEndDocument();
                            xwriter.Close();

                        }

                        catch (SmtpException)
                        {


                        }

                    }
                    else
                    {

                        

                        XmlWriter xwriter = XmlWriter.Create("messages.xml", setting);

                        xwriter.WriteStartDocument(true);
                        xwriter.WriteStartElement("messages");
                        xwriter.WriteStartElement("message");
                        string msg = "Hi " + textBox1.Text.Trim() + ",your application was setup sucessfully.Have a cool cruise!";
                        xwriter.WriteElementString("Notification", msg);
                        xwriter.WriteElementString("DateTime", DateTime.Now.ToString());
                        xwriter.WriteElementString("Type", "Activity Log");
                        xwriter.WriteElementString("Status", "Unread");
                        xwriter.WriteEndElement();
                        xwriter.WriteEndElement();
                        xwriter.WriteEndDocument();
                        xwriter.Close();


                    }

                }



            }
            
        }



        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            string text = textBox4.Text.Trim();
            if (text.Length == 0)
            {
                textBox5.Multiline = true;
                textBox5.Text = "Confirm Password";
                textBox5.ForeColor = Color.Silver;
                password_conf_error.Hide();
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
