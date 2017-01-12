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
    public partial class verifieralert : Form
    {
        public verifieralert()
        {
            InitializeComponent();
        }

        private void verifieralert_Load(object sender, EventArgs e)
        {
            

            XmlDocument xd = new XmlDocument();
            xd.Load("useraccount.xml");

            XmlNodeList xnl = xd.SelectNodes("//user");

            foreach (XmlNode node in xnl)
            {
               string name = node.SelectSingleNode("FirstName").InnerText;
                label2.Text = "Hi "+name+",";
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            if (File.Exists("useraccount.xml"))
            {
                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");
                XmlNodeList xl = xd.SelectNodes("//user");

                foreach (XmlNode node in xl)
                {

                    string email = node.SelectSingleNode("Email").InnerText;

                    string verify = node.SelectSingleNode("Verification").InnerText;

                    string verifysent = node.SelectSingleNode("VerificationSent").InnerText;

                    if (verify == "false" && verifysent == "Yes")
                    {

                        emailverifier frm = new emailverifier();
                        frm.ShowDialog();
                    }
                    else if (verify == "false" && verifysent == "No")
                    {

                        verifyemail2 frm = new verifyemail2(email, "");
                        frm.ShowDialog(); 
                    }

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }
    }
}
