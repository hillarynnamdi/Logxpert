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
    public partial class unmaskauth : Form
    {
        public unmaskauth()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Password")
            {
                textBox1.Clear();
                textBox1.Multiline = false;
                textBox1.ForeColor = Color.Black;


            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                textBox1.Multiline = true;
                textBox1.Text = "Password";
                textBox1.ForeColor = Color.Silver;

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.UseSystemPasswordChar = false;

            }
            else
            {
                textBox1.UseSystemPasswordChar = true;

            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
          

            XmlDocument xd = new XmlDocument();
            xd.Load("useraccount.xml");

            XmlNodeList xl = xd.SelectNodes("//user");

            foreach (XmlNode node in xl)
            {
                if (textBox1.Text == node.SelectSingleNode("Password").InnerText)
                {
                    textBox1.Enabled = false;
                    button1.Enabled = true;

                }
                else
                {
                    textBox1.Enabled = true;
                    button1.Enabled = false;
                }
                
            }

        }

        private void button1_EnabledChanged(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
             this.Close();
            
        }
    }
}
