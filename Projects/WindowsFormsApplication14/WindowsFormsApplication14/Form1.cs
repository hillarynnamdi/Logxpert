using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("product_name");
            dt.Columns.Add("product_price");

            int i = 0;
            for (i = 0; i <= 11; i++)
            {
                dt.Rows.Add(i, "Product_name" + 1, "product_price" + 1);
            }

            dataGridView1.DataSource = dt;
            dataGridView1.DefaultCellStyle.BackColor = Color.Wheat;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Yellow;


            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "Archive";
            btn.Text = "Archive";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
        }
    }
}
