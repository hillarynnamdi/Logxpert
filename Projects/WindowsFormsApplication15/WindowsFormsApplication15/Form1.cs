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
    public partial class Form1 : Form
    {
        public Form1(string updated)
        {
            InitializeComponent();

            if (updated == "true")
            {
                    
                
            }

        }




        private void Form1_Load(object sender, EventArgs e)
        {
            XmlReaderSettings setting = new XmlReaderSettings();
            setting.IgnoreWhitespace = true;
            setting.IgnoreProcessingInstructions = true;
            setting.IgnoreComments = true;
            XmlReader read = XmlReader.Create("users.xml", setting);


            DataSet ds = new DataSet();
            ds.ReadXml(read);

            dataGridView1.DataSource = ds.Tables[0];

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "Action";
            btn.Text = "Edit";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;

            read.Close();

            timer1.Enabled = true;
            timer1.Start();
  
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string price = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string product = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                Form2 frm = new Form2(id,product,price);
                frm.Show();

               

               // MessageBox.Show(this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
               // MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
            }
        }




    }
}
