using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace WindowsFormsApplication16
{
    public partial class viewrecords : Form
    {
        public viewrecords()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void viewrecords_Load(object sender, EventArgs e)
        {
            
            XmlDocument xd = new XmlDocument("customers.xml",settings);
        }
    }
}
