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
using System.Text.RegularExpressions;

namespace LogXpert
{
    public partial class Form6 : Form
    {
        public Form6(string first)
        {

            InitializeComponent();
            textBox1.Text = first;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (File.Exists("useraccount.xml"))
            {
                string text = textBox1.Text.Trim();
                if (text != "" && Regex.Match(text,"^[a-zA-Z]*$").Success)
                {
                    XmlDocument xd = new XmlDocument();
                    xd.Load("useraccount.xml");
                    XmlNodeList xl = xd.SelectNodes("//user");

                    foreach (XmlNode node in xl)
                    {
                        node.SelectSingleNode("FirstName").InnerText = textBox1.Text;
                   
                        string edited_first_name = node.SelectSingleNode("FirstName").InnerText;

                        xd.Save("useraccount.xml");
                        mainform frm = new mainform();
                        
                        this.Close();

                    }
                }
                else
                {
                                        
                    label2.Show();
                }


            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
            toolTip1.SetToolTip(textBox1, "First Name must contain alphabets and non-space characters only");
            label2.Hide();
        }
    }
}
