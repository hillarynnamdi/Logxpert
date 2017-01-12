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

namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlWriterSettings setting =new  XmlWriterSettings();
            setting.Indent = true;

            XmlWriter writer = XmlWriter.Create("user.xml",setting);
            writer.WriteStartDocument(true);
                     

            writer.WriteStartElement("users");

            writer.WriteStartElement("user");
            writer.WriteAttributeString("id","1");
            writer.WriteAttributeString("username","hillarynnamdi");
            writer.WriteAttributeString("password", "hillarynnamdi12345");
            writer.WriteEndElement();


            writer.WriteEndElement();

            writer.WriteEndDocument();
            writer.Close();

            MessageBox.Show("created successfully");

        }

     }
    }

