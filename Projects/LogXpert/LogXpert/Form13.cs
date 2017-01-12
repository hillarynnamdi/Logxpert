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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label1.Text == "Please Wait...")
            {
                label1.Text = "Restoring.";
                pictureBox2.Hide();
                pictureBox1.Show();
            }
            else if (label1.Text == "Restoring.")
            {
                label1.Text = "Restoring..";
            }
            else if (label1.Text == "Restoring..")
            {
                label1.Text = "Restoring...";
            }
            else if (label1.Text == "Restoring...")
            {
                label1.Text = "Restore was successful!";
            }
            else if (label1.Text == "Restore was successful!")
            {
                label1.Text = "Re-setting up LogXpert application..40%";
                pictureBox1.Hide();
                pictureBox2.Show();
            }
            else if (label1.Text == "Re-setting up LogXpert application..40%")
            {
                label1.Text = "Re-setting up LogXpert application...60%";
            }
            else if (label1.Text == "Re-setting up LogXpert application...60%")
            {
                label1.Text = "Re-setting up LogXpert application...90%";
            }
            else if (label1.Text == "Re-setting up LogXpert application...90%")
            {
                timer1.Interval = 2000;
                label1.Text = "Ready For Use!";
                pictureBox2.Hide();
                pictureBox1.Hide();
                pictureBox3.Show();
               
            }
            else if (label1.Text == "Ready For Use!")
            {
                timer1.Interval = 3000;
                label1.Text = "Closing Restorer in 3 seconds...";
                pictureBox3.Hide();
                pictureBox1.Hide();
                pictureBox2.Show();

            }
            else if(label1.Text== "Closing Restorer in 3 seconds...")
            {
                this.Close();
                timer1.Stop();
            }




        }

    }
}
