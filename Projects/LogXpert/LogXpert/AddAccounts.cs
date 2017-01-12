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
    public partial class AddAccounts : Form
    {
        public AddAccounts()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "Email or Username")
            {
                textBox1.Clear();
                textBox1.ForeColor = Color.Black;

            }
            toolTip1.SetToolTip(textBox1,"Email or Username");
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
            if(textBox5.Text.Trim()== "Type or Select Account Name")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
            toolTip1.SetToolTip(textBox5, "Type or Select Account Name");
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if(textBox5.Text.Trim()== "")
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
            toolTip1.SetToolTip(textBox2,"Password or Pin");
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                textBox2.Text= "Password or Pin";
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
                textBox3.Text= "Paste URL e.g http://www.hillarycasts.net";
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
            toolTip1.SetToolTip(textBox4,"More Description/Information...");
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "")
            {
                textBox4.Text = "More Description/Information...";
                textBox4.ForeColor = Color.Silver;

            }
        }

        private void AddAccounts_Load(object sender, EventArgs e)
        {
            if (textBox1.Focused == true)
            {
                textBox4.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            if (textBox5.Text != "Type or Select Account Name" && (textBox1.Text != "Email or Username" || textBox2.Text != "Password or Pin" || textBox3.Text != "Paste URL e.g http://www.hillarycasts.net" || textBox4.Text != "More Description/Information..."))
            {
                if (!File.Exists("accounts.xml"))
                {
                    XmlWriterSettings xs = new XmlWriterSettings();
                    xs.Indent = true;
                    xs.Encoding = Encoding.UTF8;
                    XmlWriter xw = XmlWriter.Create("accounts.xml", xs);
                    xw.WriteStartDocument(true);
                    xw.WriteStartElement("accounts");
                    xw.WriteEndElement();
                    xw.WriteEndDocument();
                    xw.Close();

                    XmlDocument xd = new XmlDocument();
                    xd.Load("accounts.xml");
                    XmlElement xe = xd.CreateElement("account");


                    XmlElement Id = xd.CreateElement("Id");
                    Id.InnerText = "1";
                    xe.AppendChild(Id);

                    XmlElement AccountName = xd.CreateElement("Account");
                    AccountName.InnerText = textBox5.Text.Trim();
                    xe.AppendChild(AccountName);

                    XmlElement UserName = xd.CreateElement("Username");
                    if (textBox1.Text.Trim() != "Email or Username")
                    {
                        UserName.InnerText = textBox1.Text.Trim();
                    }
                    else
                    {
                        UserName.InnerText = "<Nil>";
                    }
                    xe.AppendChild(UserName);

                    XmlElement Password = xd.CreateElement("Password");
                    if (textBox2.Text.Trim() != "Password or Pin")
                    {
                        Password.InnerText = textBox2.Text.Trim();
                    }
                    else
                    {
                        Password.InnerText = "<Nil>";
                    }

                    xe.AppendChild(Password);

                    XmlElement url = xd.CreateElement("URL");
                    if (textBox3.Text.Trim() != "Paste URL e.g http://www.hillarycasts.net" && textBox3.Text.Trim() != "http://wwww.")
                    {
                        
                        url.InnerText = textBox3.Text.Trim();
                    }
                    else
                    {
                        url.InnerText = "<http://>";
                    }

                    xe.AppendChild(url);

                    XmlElement desc = xd.CreateElement("Description");
                    if (textBox4.Text.Trim() != "More Description/Information...")
                    {
                        desc.InnerText = textBox4.Text.Trim();
                    }
                    else
                    {
                        desc.InnerText = "<Nil>";
                    }

                    xe.AppendChild(desc);


                    XmlElement date = xd.CreateElement("Saved");
                    date.InnerText = System.DateTime.Now.ToString();
                    xe.AppendChild(date);

                    xd.DocumentElement.AppendChild(xe);
                    xd.Save("accounts.xml");


                }
                else
                {
                    XmlDocument xd = new XmlDocument();
                    xd.Load("accounts.xml");


                    XmlNode Id = xd.DocumentElement.LastChild;
                    string id = Id.SelectSingleNode("Id").InnerText;
                    int newid = int.Parse(id) + int.Parse("1");


                    XmlElement xe = xd.CreateElement("account");

                    XmlElement Ids = xd.CreateElement("Id");
                    Ids.InnerText = newid.ToString();
                    xe.AppendChild(Ids);

                    XmlElement AccountName = xd.CreateElement("Account");
                    AccountName.InnerText = textBox5.Text.Trim();
                    xe.AppendChild(AccountName);

                    XmlElement UserName = xd.CreateElement("Username");
                    if (textBox1.Text.Trim() != "Email or Username")
                    {
                        UserName.InnerText = textBox1.Text.Trim();
                    }
                    else
                    {
                        UserName.InnerText = "<Nil>";
                    }
                    xe.AppendChild(UserName);

                    XmlElement Password = xd.CreateElement("Password");
                    if (textBox2.Text.Trim() != "Password or Pin")
                    {
                        Password.InnerText = textBox2.Text.Trim();
                    }
                    else
                    {
                        Password.InnerText = "<Nil>";
                    }

                    xe.AppendChild(Password);

                    XmlElement url = xd.CreateElement("URL");
                    if (textBox3.Text.Trim() != "Paste URL e.g http://www.hillarycasts.net")
                    {
                        url.InnerText = textBox3.Text.Trim();
                    }
                    else
                    {
                        url.InnerText = "<http://>";
                    }

                    xe.AppendChild(url);

                    XmlElement desc = xd.CreateElement("Description");
                    if (textBox4.Text.Trim() != "More Description/Information...")
                    {
                        desc.InnerText = textBox4.Text.Trim();
                    }
                    else
                    {
                        desc.InnerText = "<Nil>";
                    }

                    xe.AppendChild(desc);

                    XmlElement date = xd.CreateElement("Saved");
                    date.InnerText = System.DateTime.Now.ToString();
                    xe.AppendChild(date);


                    xd.DocumentElement.AppendChild(xe);
                    xd.Save("accounts.xml");


                }
            }
            else
            {
                addaccountvalidation frm = new addaccountvalidation();
                frm.ShowDialog();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }
    }
}
