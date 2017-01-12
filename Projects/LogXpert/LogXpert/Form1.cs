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
using System.Xml;


namespace LogXpert
{
    public partial class Form1 : Form
    {
        public Form1(string txt)
        {
            InitializeComponent();
            if (txt != "")
            {
                
                
                textBox1.Text = txt;
                button1.Focus();
                textBox1.ForeColor = Color.Black;


            }
            else
            {
                textBox1.Text = "e-mail";
            }
            

        }


        private void Form1_Load(object sender, EventArgs e)
        {

           

            

            if (File.Exists("useraccount.xml"))
            {
                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");

                XmlNodeList xnl = xd.SelectNodes("//user");
                foreach (XmlNode node in xnl)
                {
                    string email = node.SelectSingleNode("Email").InnerText;
                    string pass = node.SelectSingleNode("Password").InnerText;
                    string autologin = node.SelectSingleNode("AutoLogin").InnerText;

                    if (autologin == "On")
                    {
                        textBox1.Enabled = false;
                        textBox1.ForeColor = Color.Black;
                        textBox1.Multiline = false;

                        textBox2.Enabled = false;
                        textBox2.ForeColor = Color.Black;
                        textBox2.Multiline = false;

                        textBox1.Text = email;
                        textBox2.Text = pass;

                        checkBox2.Hide();
                        checkBox1.Show();
                        checkBox1.Checked = true;
                        button1.Enabled = true;


                    }
                    else
                    {
                        checkBox1.Hide();




                    }



                }
            }
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text == "e-mail")
            {
                textBox1.Clear();
                textBox1.ForeColor = Color.Black;
                textBox1.Multiline = false;


            }

            toolTip1.SetToolTip(textBox1, "Enter E-mail");
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                this.textBox1.Font = new System.Drawing.Font("Comic Sans MS", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
                textBox1.Text = "e-mail";
                textBox1.ForeColor = Color.Silver;
                textBox1.Multiline = true;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "password")
            {
                textBox2.Clear();
                textBox2.Multiline = false;
                textBox2.ForeColor = Color.Black;
                

            }
            toolTip1.SetToolTip(textBox2, "Enter Password");

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Multiline = true;
                textBox2.Text = "password";
                textBox2.ForeColor = Color.Silver;

            }
           
            
        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
           

            if (File.Exists("useraccount.xml"))
            {
                contextMenuStrip1.Show(button2,-button2.Width * 2, 0);
            }
            else
            {
                contextMenuStrip2.Show(button2,-button2.Width*2, 0);
            }
            
        }

        

        private void createMyAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Form3 frm = new Form3();
            frm.ShowDialog();

            

        }

   
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox1.TextLength > 0 && textBox2.TextLength > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled =false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            XmlDocument xd = new XmlDocument();

            
            xd.Load("useraccount.xml");

            XmlNodeList xnl = xd.SelectNodes("//user");
            string email = textBox1.Text.ToLower().Trim();
            
            string pass = textBox2.Text.ToLower().Trim();
            foreach (XmlNode node in xnl)
            {
                if (email == node.SelectSingleNode("Email").InnerText && pass == node.SelectSingleNode("Password").InnerText)
                {
                    string verify = node.SelectSingleNode("Verification").InnerText.Trim();
                    string notifier = node.SelectSingleNode("VerificationNotifier").InnerText.Trim();

                    //activation

                    string activate = node.SelectSingleNode("Activated").InnerText.Trim();
                    string remain = node.SelectSingleNode("Remaining").InnerText.Trim();

                    if (activate == "No" && int.Parse(remain) == 1)
                    {

                        //MessageBox.Show("unactivated");
                        Form15 frm = new Form15();
                        frm.ShowDialog();

                    }
                    else
                    {
                        if (int.Parse(remain) >=2)
                        {
                            int num = int.Parse(remain);
                            num = num - 1;
                            node.SelectSingleNode("Remaining").InnerText = num.ToString();
                            xd.Save("useraccount.xml");
                        }

                        if (verify == "True")
                        {
                            mainform frm = new mainform();
                            frm.Show();
                            this.Hide();
                        }
                        else
                        {

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

                                    string name = nodes.SelectSingleNode("FirstName").InnerText;
                                    string last = nodes.SelectSingleNode("LastName").InnerText;

                                    XmlElement messages = xdmsg.CreateElement("Notification");
                                    messages.InnerText = "Hi " + name + " " + last + ",your email id is still yet to be verified!!";





                                    xe.AppendChild(messages);

                                }

                                XmlElement date = xdmsg.CreateElement("DateTime");
                                date.InnerText = DateTime.Now.ToString();
                                xe.AppendChild(date);

                                XmlElement type = xdmsg.CreateElement("Type");
                                type.InnerText = "Verification";
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
                                    string last = nodes.SelectSingleNode("LastName").InnerText;
                                    string msg = "Hi " + name + " " + last + ",your email id is still yet to be verified!!";
                                    xwriter.WriteElementString("Notification", msg);
                                }




                                xwriter.WriteElementString("DateTime", DateTime.Now.ToString());
                                xwriter.WriteElementString("Type", "Verification");
                                xwriter.WriteElementString("Status", "Unread");
                                xwriter.WriteEndElement();
                                xwriter.WriteEndElement();
                                xwriter.WriteEndDocument();
                                xwriter.Close();
                            }

                            //message stops

                            if (notifier == "On")
                            {

                                verifieralert frm = new verifieralert();
                                DialogResult res = frm.ShowDialog();
                                if (res == DialogResult.Cancel)
                                {
                                    DialogResult resb = MessageBox.Show("You can turn off verification reminder in your settings tabs.", "Remind Me Later", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (DialogResult.OK == resb)
                                    {
                                        this.Hide();
                                        mainform frms = new mainform();
                                        frms.Show();


                                    }
                                }
                                else if (res == DialogResult.OK)
                                {

                                    string emails = node.SelectSingleNode("Email").InnerText;

                                    string verifysent = node.SelectSingleNode("VerificationSent").InnerText;

                                    if (verify == "False" && verifysent == "Yes")
                                    {

                                       emailverifier frms = new emailverifier();
                                        DialogResult rest = frms.ShowDialog();
                                        if (rest == DialogResult.OK)
                                        {
                                            verifyemail2 frmss = new verifyemail2(email, "");
                                            frmss.ShowDialog();
                                        }
                                    }
                                    else if (verify == "False" && verifysent == "No")
                                    {
                                        verifyemail2 frmss = new verifyemail2(email, "");
                                        frmss.ShowDialog();
                                    }

                                }



                            }
                            else
                            {
                                mainform frm = new mainform();
                                frm.Show();
                                this.Hide();
                            }


                        }
                    }
                }
                else
                {

                    loginvalidation frm = new loginvalidation();
                    DialogResult res = frm.ShowDialog();

                }
            }
            
            
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox1.TextLength > 0 && textBox2.TextLength > 0)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void forgotPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            XmlDocument xd = new XmlDocument();
            xd.Load("useraccount.xml");
            string type = "forgot_password";
            XmlNodeList xnl = xd.SelectNodes("//user");

            foreach (XmlNode node in xnl)
            {
                string email = node.SelectSingleNode("Email").InnerText;
                string verification = node.SelectSingleNode("Verification").InnerText;
               
                    verifyemail frm = new verifyemail(email, type);
                    frm.ShowDialog();
                

            }



        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }


        private void S_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           

            if (checkBox1.Checked == false)
            {
                textBox1.Enabled = true;

                textBox2.Enabled = true;


                if (File.Exists("useraccount.xml")) { 
                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");

                XmlNodeList xnl = xd.SelectNodes("//user");
                    foreach (XmlNode node in xnl)
                    {
                        string email = node.SelectSingleNode("Email").InnerText;
                        string pass = node.SelectSingleNode("Password").InnerText;
                        node.SelectSingleNode("AutoLogin").InnerText = "Off";
                        xd.Save("useraccount.xml");

                        textBox1.Text = email;
                        textBox2.Text = pass;

                        checkBox1.Hide();
                    }

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
