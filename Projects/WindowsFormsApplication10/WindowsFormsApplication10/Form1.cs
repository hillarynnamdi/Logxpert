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

namespace WindowsFormsApplication10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Indent = true;
            setting.Encoding = Encoding.UTF8;
            
            XmlWriter write = XmlWriter.Create("users.xml", setting);

            write.WriteStartDocument(true);
            write.WriteStartElement("Student");
            write.WriteAttributeString("id", "10");
            write.WriteAttributeString("status", "archived");
            write.WriteElementString("firstname","Jaime");
            write.WriteElementString("lastname", "show");

            write.WriteEndElement();
            write.WriteEndDocument();
            write.Close();
            MessageBox.Show("created!");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            XmlReaderSettings setting = new XmlReaderSettings();
            setting.IgnoreWhitespace = true;
            setting.IgnoreComments = true;
            setting.IgnoreProcessingInstructions = true;
            XmlReader read = XmlReader.Create("users.xml", setting);
            read.MoveToContent();
            string id = read["id"];
            string status = read["status"];
            read.ReadStartElement("Student");
            string age = read["age"];
            string firstname = read.ReadElementContentAsString("firstname","");
            string lastname = read.ReadElementContentAsString("lastname", "");
            MessageBox.Show(id.ToString());
            MessageBox.Show(status.ToString());
            MessageBox.Show(firstname.ToString());
            MessageBox.Show(lastname.ToString());
            MessageBox.Show(age.ToString());

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                XmlReader xmlFile;
                xmlFile = XmlReader.Create("users.xml", new XmlReaderSettings());
                DataSet ds = new DataSet();
                ds.ReadXml(xmlFile);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
