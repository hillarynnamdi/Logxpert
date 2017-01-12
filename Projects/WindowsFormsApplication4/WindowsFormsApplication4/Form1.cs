using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
            pictureBox1.ImageLocation=openFileDialog1.FileName;
            progressBar1.Show();
            int i;
            for (i = 0; i <= 200; i++)
            {
                progressBar1.Value=i;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
