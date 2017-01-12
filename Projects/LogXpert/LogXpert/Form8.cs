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
using System.Text.RegularExpressions;

namespace LogXpert
{
    public partial class Form8 : Form
    {
        public Form8(string email)
        {
            InitializeComponent();
            textBox1.Text = email;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          

            if (File.Exists("useraccount.xml"))
            {
                string text = textBox1.Text.Trim();
                string pattern = null;
                pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
                if (text != "" && Regex.Match(text, pattern).Success)
                {
                    
                    XmlDocument xd = new XmlDocument();
                    xd.Load("useraccount.xml");
                    XmlNodeList xl = xd.SelectNodes("//user");

                    foreach (XmlNode node in xl)
                    {
                        if (node.SelectSingleNode("Email").InnerText == textBox1.Text.Trim())
                        {
                            node.SelectSingleNode("Email").InnerText = textBox1.Text;
                            string edited_first_name = node.SelectSingleNode("Email").InnerText;
                            xd.Save("useraccount.xml");
                            this.Close();
                        }
                        else
                        {
                            string verify = node.SelectSingleNode("Verification").InnerText;
                            string email = node.SelectSingleNode("Email").InnerText;
                            if (verify == "True") {
                              DialogResult res=MessageBox.Show("Changing Your E-mail \n From "+"'"+email+"' "+"to "+"'"+textBox1.Text+"' "+ "\n Requires Another Verification", "Notification", MessageBoxButtons.OKCancel);
                                if (res == DialogResult.OK)
                                {
                                    node.SelectSingleNode("Email").InnerText = textBox1.Text;
                                    string edited_first_name = node.SelectSingleNode("Email").InnerText;
                                    node.SelectSingleNode("Verification").InnerText = "False";
                                    node.SelectSingleNode("VerificationSent").InnerText = "No";
                                    node.SelectSingleNode("VerificationCode").InnerText = "";
                                    xd.Save("useraccount.xml");
                                    this.Close();
                                }
                                else
                                {
                                    this.Close();
                                }
                            }
                            else
                            {
                                node.SelectSingleNode("Email").InnerText = textBox1.Text;
                                string edited_first_name = node.SelectSingleNode("Email").InnerText;
                                xd.Save("useraccount.xml");
                                this.Close();
                            }
                        }
                    }

                }
                else
                {
                    toolTip1.SetToolTip(textBox1, "E-mail must contain @(at) , .(dot) ,and must be valid!");
                    label2.Show();
                }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            label2.Hide();
        }
    }
}
