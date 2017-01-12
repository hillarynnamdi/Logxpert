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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.No;
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Multiline = false;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            

            XmlDocument doc = new XmlDocument();
            doc.Load("useraccount.xml");

            XmlNodeList nl = doc.SelectNodes("//user");

            foreach (XmlNode node in nl)
            {
                string vcode=node.SelectSingleNode("VerificationCode").InnerText;
                int vcodelen = vcode.Length;
                textBox1.MaxLength = vcodelen;
            }
        }


        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            

            XmlDocument doc = new XmlDocument();
            doc.Load("useraccount.xml");

            XmlNodeList nl = doc.SelectNodes("//user");

            foreach (XmlNode node in nl)
            {
                string vcode = node.SelectSingleNode("VerificationCode").InnerText;
                int vcodelen = vcode.Length;
                if (textBox1.TextLength == vcodelen)
                {
                    if (textBox1.Text.Trim() == vcode)
                    {
                        textBox1.Enabled = false;
                        pictureBox1.Show();
                        pictureBox2.Hide();
                        button1.Show();
                        linkLabel1.Hide();
                        node.SelectSingleNode("Verification").InnerText = "True";
                        linkLabel1.Hide();

                    }
                    else
                    {
                        pictureBox2.Show();
                        pictureBox1.Hide();

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
