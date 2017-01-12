using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        private void Form1_Load_1(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string textual = comboBox1.Text;
            int len = textual.Length;
            if (len > 0)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                comboBox1.Enabled = false;
                comboBox1.Text="";
                textBox2.Enabled = true;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton2.Checked == true)
            {
                comboBox1.Enabled = true;
                textBox2.Clear();
                textBox2.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string textual = textBox2.Text;
            int len = textual.Length;
            if (len > 0)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                string textbx = textBox2.Text;
                comboBox1.Items.Add(textbx);
                textBox2.Clear();
                MessageBox.Show("added successfully", "notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(radioButton2.Checked == true)
            {
                string combobx = comboBox1.Text;

                

                if (comboBox1.Items.Contains(combobx)) {
                    comboBox1.Items.Remove(combobx);
                    comboBox1.Text = "";
                    MessageBox.Show("removed successfully", "notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("no match!", "notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                   
                
            }
        }
    }
    }

    
