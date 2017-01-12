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
    public partial class Form17 : Form
    {
        public Form17(string nam)
        {
            InitializeComponent();
            if (nam == "" || nam=="First Name")
            {
                label1.Text = "By clicking the checkbox,you agree that this application software  is a licenced software and can only be activated by its author/developer and that ,any act that contravenes this policy is subject to punishment.";
            }
            else
            {
                label1.Text ="Hi "+nam+", By clicking the checkbox,you agree that this application software  is a licenced software and can only be activated by its author/developer and that ,any act that contravenes this policy is subject to punishment.";
            }
        }
    }
}
