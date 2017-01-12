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

namespace WindowsFormsApplication11
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
            XmlWriter write = XmlWriter.Create("users.xml", setting);
            write.WriteStartDocument(true);
            write.WriteStartElement("table");
            write.WriteStartElement("product");
            write.WriteElementString("product_id", "11");
            write.WriteElementString("product_name", "close up");
            write.WriteElementString("product_price", "2000");
            write.WriteEndElement();
            write.WriteEndElement();
            write.WriteEndDocument();
            write.Close();
            MessageBox.Show("created single child node");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Indent = true;
            XmlWriter write = XmlWriter.Create("users.xml", setting);
            write.WriteStartDocument(true);
            write.WriteStartElement("table");
            write.WriteStartElement("product");
            write.WriteElementString("product_id", "11");
            write.WriteElementString("product_name", "close up");
            write.WriteElementString("product_price", "2000");
            write.WriteEndElement();

            write.WriteStartElement("product");
            write.WriteElementString("product_id", "12");
            write.WriteElementString("product_name", "omo");
            write.WriteElementString("product_price", "400");
            write.WriteEndElement();

            write.WriteEndElement();
            write.WriteEndDocument();
            write.Close();
            MessageBox.Show("created multiple child node");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try {
                
                File.Delete("users.xml");
                MessageBox.Show("deleted successfully");
                
            }
            catch(IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                FileInfo info = new FileInfo("users.xml");
                MessageBox.Show(info.CreationTime.ToString());
                MessageBox.Show(info.Attributes.ToString());
            }
            catch(IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("users.xml");

            XmlNodeList node = doc.SelectNodes("table/product");

            foreach (XmlNode n in node)
            {
                MessageBox.Show(n.ChildNodes[0].InnerText);
                MessageBox.Show(n.ChildNodes[1].InnerText);
                MessageBox.Show(n.ChildNodes[2].InnerText);
                
            }

        }

        private void text_bx_clear(object sender, EventArgs e)
        {
            if(textBox1.Text=="search item")
            {
                textBox1.Clear();
                textBox1.ForeColor = Color.Black;
            }
        }

        private void text_bx_set(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = Color.Silver;
                textBox1.Text = "search item";
            }
        }

        private void search_xml(object sender, KeyPressEventArgs e)
        {
            XmlReader xmlFile;
            xmlFile = XmlReader.Create("users.xml", new XmlReaderSettings());

            DataSet ds = new DataSet();
            
            ds.ReadXml(xmlFile);

            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "product_name";
            int index = dv.Find("close up");

            if (index == -1)
            {
                MessageBox.Show("Item Not Found");
            }
            else
            {
                //MessageBox.Show(index.ToString());
                // MessageBox.Show(dv[index]["product_name"].ToString() + " " + dv[index]["product_price"].ToString());

               
                MessageBox.Show(dv[index]["product_name"].ToString() + " " + dv[index]["product_price"].ToString());

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
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
