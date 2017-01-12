using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {

        private void button1_Click(object sender, EventArgs e)
        {
            Process[] _process = null;
            _process = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            if (_process.Length > 1)
            {
                MessageBox.Show("Multiple instancess running...");
            }
            else
            {
                MessageBox.Show("Single instance only....");
            }
        }
    }
}
        }
    }
}
