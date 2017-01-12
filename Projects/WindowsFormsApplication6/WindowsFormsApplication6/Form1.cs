using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ArrayList list = new ArrayList();
        private void button1_Click(object sender, EventArgs e)
        {
            
            string txtbox = textBox1.Text;
            list.Add(txtbox);
            MessageBox.Show("Added");
            textBox1.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            for (i=0;i<=list.Count-1;i++)
            {
                list.Sort();
                //label1.Text = list[i].ToString()+" ";
                MessageBox.Show(list[i].ToString());
                textBox1.Clear();
            }
        }
    }
}
