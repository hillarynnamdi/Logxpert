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

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Queue days = new Queue();
            days.Enqueue("SunDay");
            days.Enqueue("MonDay");
            days.Enqueue("TueDay");
            days.Enqueue("WedDay");
            days.Enqueue("ThuDay");
            days.Enqueue("FriDay");
            

                MessageBox.Show(days.Dequeue().ToString());
          
        }
    }
    }

