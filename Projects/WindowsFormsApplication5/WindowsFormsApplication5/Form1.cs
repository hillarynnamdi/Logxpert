using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_leave(object sender, EventArgs e)
        {
            int len = textBox1.TextLength;
            if (len <= 5)
            {
                MessageBox.Show("too short");
                textBox1.BackColor = Color.SaddleBrown;
            }
            else
            {
                textBox1.BackColor = Color.White;
            }
        }

        private void textBox1_focus(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string name=openFileDialog1.FileName;
            pictureBox1.ImageLocation = name;
            progressBar1.Show();

            int i;
            for (i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (button3.Text!="") {
                button3.Text = DateTime.Now.ToString(); 
            }
           
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
        }
    }
}
