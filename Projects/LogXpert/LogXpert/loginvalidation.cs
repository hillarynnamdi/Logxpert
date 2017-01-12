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
    public partial class loginvalidation : Form
    {
        public loginvalidation()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.Close();

           

            XmlDocument xd = new XmlDocument();
            xd.Load("useraccount.xml");

            XmlNodeList xnl = xd.SelectNodes("//user");

            foreach (XmlNode node in xnl)
            {
                string email = node.SelectSingleNode("Email").InnerText;
                verifyemail frm = new verifyemail(email,"");
                frm.ShowDialog();
            }
        }
    }
}
