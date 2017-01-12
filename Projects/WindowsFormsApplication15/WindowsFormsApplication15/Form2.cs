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

namespace WindowsFormsApplication15
{
    public partial class Form2 : Form
    {
        public Form2(string id, string product,string price)
        {
            InitializeComponent();
            textBox1.Text = id;
            textBox2.Text = product;
            textBox3.Text = price;
        }

        private void Edit_Load(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            XmlDocument xd = new XmlDocument();

           
                xd.Load("users.xml");


            XmlNodeList node = xd.SelectNodes("table/product");

            foreach(XmlNode n in node)
            {
                string id=n.ChildNodes[0].InnerText;
                
               if (id == textBox1.Text)
                {
                   
                    n.ChildNodes[1].InnerText =textBox2.Text;
                    n.ChildNodes[2].InnerText = textBox3.Text;
                    
                }

               
            }

            
                xd.Save("users.xml");
                 this.Hide();

            string updated = "true";
            Form1 frmal = new Form1(updated);            
            
           

        }
    }
}
