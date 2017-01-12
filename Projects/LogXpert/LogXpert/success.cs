using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogXpert
{
    public partial class success : Form
    {
        public success()
        {
            InitializeComponent();

            int i;
            for (i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
                label3.Text = "";
                label3.Text = i + "%";

                if (i == 100)
                {


                    button1.Enabled = true;

                    
                }
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            Form1 frm = new Form1("");
            frm.Show();
            frm.Refresh();
        }
    }
}
