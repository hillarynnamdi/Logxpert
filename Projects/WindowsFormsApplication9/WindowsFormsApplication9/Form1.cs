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
namespace WindowsFormsApplication9

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txtbox = textBox1.Text;
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Indent = true;

            if (File.Exists("users.xml"))
            {
                XmlDocument writemore = new XmlDocument();
                writemore.Load("users.xml");

               // writemore.AppendChild();

            }
            else
            {
                XmlWriter write = XmlWriter.Create("users.xml", setting);
                write.WriteStartDocument(true);

                write.WriteStartElement("user");

                write.WriteStartElement("username");
                write.WriteString(txtbox);
                write.WriteEndElement();

                write.WriteEndElement();

                write.WriteEndDocument();
                write.Close();

                MessageBox.Show("created successfully!");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            XmlReader read = XmlReader.Create("users.xml",settings);
            read.MoveToContent();
            read.ReadStartElement("user");
        }
    }
}
