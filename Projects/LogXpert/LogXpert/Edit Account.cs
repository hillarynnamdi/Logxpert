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
    public partial class Edit_Account : Form
    {
        public Edit_Account(string id, string account, string username, string password, string url, string desc)
        {
            

            InitializeComponent();
            textBox5.ForeColor = Color.Black;
            textBox5.Text = account;

            label1.Text = id;

            if (username != "<Nil>")
            {
                textBox1.ForeColor = Color.Black;
                textBox1.Text = username;
            }

            if (password != "<Nil>" && password.Trim() != "*******")
            {
                textBox2.ForeColor = Color.Black;
                textBox2.Text = password;
            }

            if (password != "<Nil>" && password.Trim() == "*******")
            {
                textBox2.ForeColor = Color.Black;
                textBox2.UseSystemPasswordChar = true;
 
                XmlDocument xd = new XmlDocument();
                xd.Load("accounts.xml");

                XmlNodeList xl = xd.SelectNodes("accounts/account");
                string ids = label1.Text;

                foreach (XmlNode node in xl)
                {
                    string dbid = node.SelectSingleNode("Id").InnerText;
                    if (ids == dbid)
                    {
                        textBox2.Text = node.SelectSingleNode("Password").InnerText;
                    }
                }
            }

            



            if (url != "<http://>")
            {
                textBox3.ForeColor = Color.Black;
                textBox3.Text = url;
            }
            if (desc != "<Nil>")
            {
                textBox4.ForeColor = Color.Black;
                textBox4.Text = desc;
            }

        }

        private void Edit_Account_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "Email or Username")
            {
                textBox1.Clear();
                textBox1.ForeColor = Color.Black;

            }
            toolTip1.SetToolTip(textBox1, "Email or Username");
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                textBox1.Text = "Email or Username";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim() == "Type or Select Account Name")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
            toolTip1.SetToolTip(textBox5, "Type or Select Account Name");
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim() == "")
            {
                textBox5.Text = "Type or Select Account Name";
                textBox5.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "Password or Pin")
            {
                textBox2.Clear();
                textBox2.ForeColor = Color.Black;
            }
            toolTip1.SetToolTip(textBox2, "Password or Pin");
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                textBox2.Text = "Password or Pin";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == "Paste URL e.g http://www.hillarycasts.net")
            {
                textBox3.Text = "http://www.";
                textBox3.ForeColor = Color.Black;
            }
            toolTip1.SetToolTip(textBox3, "Paste URL e.g http://www.hillarycasts.net");
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == "" || textBox3.Text.Trim() == "http://www.")
            {
                textBox3.Text = "Paste URL e.g http://www.hillarycasts.net";
                textBox3.ForeColor = Color.Silver;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "More Description/Information...")
            {
                textBox4.Clear();
                textBox4.ForeColor = Color.Black;
            }
            toolTip1.SetToolTip(textBox4, "More Description/Information...");
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "")
            {
                textBox4.Text = "More Description/Information...";
                textBox4.ForeColor = Color.Silver;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            XmlDocument xd = new XmlDocument();
            xd.Load("accounts.xml");

            XmlNodeList xl = xd.SelectNodes("accounts/account");
            if (textBox5.Text != "Type or Select Account Name" && (textBox1.Text != "Email or Username" || textBox2.Text != "Password or Pin" || textBox3.Text != "Paste URL e.g http://www.hillarycasts.net" || textBox4.Text != "More Description/Information..."))
            {
                foreach (XmlNode node in xl)
                {
                    string dbid = node.SelectSingleNode("Id").InnerText;
                    if (label1.Text.Trim() == dbid)
                    {

                        node.SelectSingleNode("Account").InnerText = textBox5.Text;
                        if (textBox1.Text.Trim() != "Email or Username")
                        {
                            node.SelectSingleNode("Username").InnerText = textBox1.Text.Trim();
                        }
                        else
                        {
                            node.SelectSingleNode("Username").InnerText = "<Nil>";
                        }

                        if (textBox2.Text.Trim() != "Password or Pin")
                        {
                            node.SelectSingleNode("Password").InnerText = textBox2.Text.Trim();
                        }
                        else
                        {
                            node.SelectSingleNode("Password").InnerText = "<Nil>";
                        }

                        if (textBox3.Text.Trim() != "Paste URL e.g http://www.hillarycasts.net" && textBox3.Text.Trim() != "http://www.")
                        {

                            node.SelectSingleNode("URL").InnerText = textBox3.Text.Trim();
                        }
                        else
                        {
                            node.SelectSingleNode("URL").InnerText = "<http://>";
                        }

                        if (textBox4.Text.Trim() != "More Description/Information...")
                        {
                            node.SelectSingleNode("Description").InnerText = textBox4.Text.Trim();
                        }
                        else
                        {
                            node.SelectSingleNode("Description").InnerText = "<Nil>";
                        }

                    }

                }

                xd.Save("accounts.xml");

            }
            else
            {
                addaccountvalidation frm = new addaccountvalidation();
                frm.ShowDialog();
            }
        }

       
        }
    }

