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
    public partial class todo : Form
    {
        public todo()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            if (!File.Exists("todo.xml"))
            {
                XmlWriterSettings xs = new XmlWriterSettings();
                xs.Indent = true;
                XmlWriter xw = XmlWriter.Create("todo.xml", xs);

                xw.WriteStartDocument(true);
                xw.WriteStartElement("todolist");
                xw.WriteStartElement("todo");

                xw.WriteElementString("Task", textBox1.Text);

                xw.WriteElementString("Date", dateTimePicker2.Value.ToLongDateString().ToString());
                xw.WriteElementString("HiddenDate", dateTimePicker2.Value.ToString());

                xw.WriteElementString("Time", dateTimePicker1.Value.ToShortTimeString().ToString());
                xw.WriteElementString("HiddenTime", dateTimePicker1.Value.ToString());

                xw.WriteElementString("Status", "Undone");


                xw.WriteElementString("Id", DateTime.Now.ToString());

                xw.WriteEndElement();
                xw.WriteEndElement();
                xw.WriteEndDocument();
                xw.Close();

            }

            else
            {

                DataSet ds = new DataSet();
                ds.ReadXml("todo.xml");

                DataView dv = new DataView(ds.Tables[0]);
                dv.Sort = "Time,Date";
                DataRowView[] foundrows = dv.FindRows(new object[] { dateTimePicker1.Value.ToShortTimeString().ToString(), dateTimePicker2.Value.ToLongDateString().ToString() });

                if (foundrows.Length==0)
                {

                    XmlDocument xd = new XmlDocument();
                    xd.Load("todo.xml");

                    XmlElement xe = xd.CreateElement("todo");


                    XmlElement task = xd.CreateElement("Task");
                    task.InnerText = textBox1.Text;
                    xe.AppendChild(task);

                    XmlElement date = xd.CreateElement("Date");
                    date.InnerText = dateTimePicker2.Value.ToLongDateString().ToString();
                    xe.AppendChild(date);

                    XmlElement hdate = xd.CreateElement("HiddenDate");
                    hdate.InnerText = dateTimePicker2.Value.ToString();
                    xe.AppendChild(hdate);

                    XmlElement time = xd.CreateElement("Time");
                    time.InnerText = dateTimePicker1.Value.ToShortTimeString().ToString();
                    xe.AppendChild(time);

                    XmlElement htime = xd.CreateElement("HiddenTime");
                    htime.InnerText = dateTimePicker1.Value.ToString();
                    xe.AppendChild(htime);

                    XmlElement status = xd.CreateElement("Status");
                    status.InnerText = "Undone";
                    xe.AppendChild(status);

                    XmlElement id = xd.CreateElement("Id");
                    id.InnerText = DateTime.Now.ToString();
                    xe.AppendChild(id);


                    xd.DocumentElement.AppendChild(xe);
                    xd.Save("todo.xml");

                }
                else
                {
                    XmlDocument xd = new XmlDocument();
                    xd.Load("todo.xml");

                    XmlNodeList xl = xd.SelectNodes("todolist/todo");

                    foreach(XmlNode node in xl)
                    {
                        string timenode = node.SelectSingleNode("Time").InnerText;
                        string datenode = node.SelectSingleNode("Date").InnerText;

                        if (timenode == dateTimePicker1.Value.ToShortTimeString().ToString() && datenode==dateTimePicker2.Value.ToLongDateString().ToString())
                        {
                            string task1 = node.SelectSingleNode("Task").InnerText;

                            string task2 = textBox1.Text;


                            string newstring = task1 + " & " + task2;

                            node.SelectSingleNode("Task").InnerText = newstring;

                            xd.Save("todo.xml");

                        }
                    }




                }
            }
            
        }
    }
}
