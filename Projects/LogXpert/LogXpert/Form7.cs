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
    public partial class Form7 : Form
    {
        public Form7(string last)
        {
            InitializeComponent();
            textBox1.Text = last;

        }

        private void button1_Click(object sender, EventArgs e)
        {
  

            if (File.Exists("useraccount.xml"))
            {
                string text = textBox1.Text.Trim();
                if (text != "" && Regex.Match(text, "^[a-zA-Z]*$").Success)
                {
                    XmlDocument xd = new XmlDocument();
                    xd.Load("useraccount.xml");
                    XmlNodeList xl = xd.SelectNodes("//user");

                    foreach (XmlNode node in xl)
                    {
                        node.SelectSingleNode("LastName").InnerText = textBox1.Text;

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "Last Name must contain alphabets and non-space characters only");
            label2.Hide();
        }
    }
}
