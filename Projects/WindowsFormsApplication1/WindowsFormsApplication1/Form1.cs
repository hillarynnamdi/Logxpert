using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button12.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Math Error")
            {
                textBox1.Clear();

            }
            textBox2.Text += button1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.TextLength == 0)
            {
                plus.Enabled = false;
                minus.Enabled = false;
                divide.Enabled = false;
                multiply.Enabled = false;
                button12.Enabled = false;


            }
            else
            {
                if (textBox1.Text=="Math Error")
                {
                    textBox2.Clear();
                    plus.Enabled = false;
                    minus.Enabled = false;
                    divide.Enabled = false;
                    multiply.Enabled = false;
                    button12.Enabled = false;
                }
                else if(textBox2.TextLength > 0)
                {
                    plus.Enabled = true;
                    minus.Enabled = true;
                    divide.Enabled = true;
                    multiply.Enabled = true;
                    button12.Enabled = true;
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Math Error")
            {
                textBox1.Clear();

            }
            textBox2.Text += button3.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Math Error")
            {
                textBox1.Clear();

            }
            textBox2.Text += button2.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Math Error")
            {
                textBox1.Clear();

            }
            textBox2.Text += button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Math Error")
            {
                textBox1.Clear();

            }
            textBox2.Text += button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Math Error")
            {
                textBox1.Clear();

            }
            textBox2.Text += button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Math Error")
            {
                textBox1.Clear();

            }
            textBox2.Text += button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Math Error")
            {
                textBox1.Clear();

            }
            textBox2.Text += button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Math Error")
            {
                textBox1.Clear();

            }
            textBox2.Text += button9.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Math Error")
            {
                textBox1.Clear();

            }
            textBox2.Text += button10.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
            bool findplus, findminus, findmultiply, finddivide;
            string current = textBox2.Text;
            findplus = current.EndsWith("+");
            findminus = current.EndsWith("-");
            findmultiply = current.EndsWith("*");
            finddivide = current.EndsWith("/");

          
                    if(findminus==true || findmultiply==true || finddivide == true)
                {
                    int currentlen = textBox2.TextLength;
                //textBox2.Text=current.Replace(current.Substring(currentlen-1).ToString(), "+");
                textBox2.Text = current.Substring(0, currentlen-1)+"+";

                }

                else 
                {
                if (findplus == false)
                {
                    int checkingminus = current.LastIndexOf("-");
                    int checkingplus = current.LastIndexOf("+");
                    int checkingdivide = current.LastIndexOf("/");
                    int checkingmultiply = current.LastIndexOf("*");

                    if (checkingplus == -1)
                    {
                        if (checkingminus != -1)
                        {


                            string currents = textBox2.Text;
                            bool check_beginning = currents.StartsWith("-");
                            if (check_beginning == true)
                            {
                                int checkingplus_again = currents.LastIndexOf("+");
                                int checkingdivide_again = currents.IndexOf("/");
                                int checkingmultiply_again = currents.IndexOf("*");
                                int checkingminus_again = currents.LastIndexOf("-");

                                if (checkingplus_again != -1)
                                {
                                    string split1 = currents.Substring(0, checkingplus_again);
                                    string split2 = currents.Substring(checkingplus_again + 1, currents.Length - (checkingplus_again + 1));
                                    //MessageBox.Show(split1, split2, MessageBoxButtons.OK);
                                    double calculated_value = double.Parse(split1) + double.Parse(split2);
                                    textBox2.Text = calculated_value.ToString();
                                    textBox1.Text = textBox2.Text;
                                    textBox2.Text += minus.Text;
                                }
                                else if (checkingmultiply_again != -1)
                                {
                                    string split1 = currents.Substring(0, checkingmultiply_again);
                                    string split2 = currents.Substring(checkingmultiply_again + 1, currents.Length - (checkingmultiply_again + 1));
                                    //MessageBox.Show(split1, split2, MessageBoxButtons.OK);
                                    double calculated_value = double.Parse(split1) * double.Parse(split2);
                                    textBox2.Text = calculated_value.ToString();
                                    textBox1.Text = textBox2.Text;
                                    textBox2.Text += minus.Text;
                                }
                                else if (checkingdivide_again != -1)
                                {
                                    string split1 = currents.Substring(0, checkingdivide_again);
                                    string split2 = currents.Substring(checkingdivide_again + 1, currents.Length - (checkingdivide_again + 1));
                                    //MessageBox.Show(split1, split2, MessageBoxButtons.OK);
                                    double calculated_value = double.Parse(split1) / double.Parse(split2);
                                    textBox2.Text = calculated_value.ToString();
                                    textBox1.Text = textBox2.Text;
                                    textBox2.Text += minus.Text;
                                }
                                else if (checkingminus_again != -1)
                                {
                                    string split1 = currents.Substring(0, checkingminus_again);
                                    string split2 = currents.Substring(checkingminus_again + 1, currents.Length - (checkingminus_again + 1));
                                    //MessageBox.Show(split1, split2, MessageBoxButtons.OK);
                                    double calculated_value = double.Parse(split1) - double.Parse(split2);
                                    textBox2.Text = calculated_value.ToString();
                                    textBox1.Text = textBox2.Text;
                                    textBox2.Text += minus.Text;
                                }
                            }
                            else
                            {
                                string split3 = current.Substring(0, checkingminus);
                                string split4 = current.Substring(checkingminus + 1, current.Length - (checkingminus + 1));
                                //MessageBox.Show(split3, split4, MessageBoxButtons.OK);
                                double calculated_value = double.Parse(split3) - double.Parse(split4);
                                textBox2.Text = calculated_value.ToString();
                                textBox1.Text = textBox2.Text;
                                textBox2.Text += plus.Text;
                            }

                        }
                        else if (checkingdivide != -1)
                        {
                            string split1 = current.Substring(0, checkingdivide);
                            string split2 = current.Substring(checkingdivide + 1, current.Length - (checkingdivide + 1));
                            double calculated_value = double.Parse(split1) / double.Parse(split2);
                            textBox2.Text = calculated_value.ToString();
                            textBox1.Text = textBox2.Text;
                            textBox2.Text += plus.Text;
                        }
                        else if (checkingmultiply != -1)
                        {
                            string split1 = current.Substring(0, checkingmultiply);
                            string split2 = current.Substring(checkingmultiply + 1, current.Length - (checkingmultiply + 1));
                            double calculated_value = double.Parse(split1) * double.Parse(split2);
                            textBox2.Text = calculated_value.ToString();
                            textBox1.Text = textBox2.Text;
                            textBox2.Text += plus.Text;
                        }
                        else
                        {
                            textBox1.Text = textBox2.Text;
                            textBox2.Text += plus.Text;
                        }

                    }
                    else
                    {

                        string split3 = current.Substring(0, checkingplus);
                        string split4 = current.Substring(checkingplus + 1, current.Length - (checkingplus + 1));
                        //MessageBox.Show(split3, split4, MessageBoxButtons.OK);
                        double calculated_value = double.Parse(split3) + double.Parse(split4);
                        textBox2.Text = calculated_value.ToString();
                        textBox1.Text = textBox2.Text;
                        textBox2.Text += plus.Text;

                    }







                }

                }
                
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            bool findplus, findminus, findmultiply, finddivide;
            string current = textBox2.Text;
            findplus = current.EndsWith("+");
            findminus = current.EndsWith("-");
            findmultiply = current.EndsWith("*");
            finddivide = current.EndsWith("/");


            if (findplus == true || findmultiply == true || findminus == true)
            {
                int currentlen = textBox2.TextLength;
                textBox2.Text = current.Substring(0, currentlen - 1) + "/";

            }
            else
            {
                if (finddivide == false)
                {
                    int checkingminus = current.LastIndexOf("-");
                    int checkingplus = current.LastIndexOf("+");
                    int checkingdivide = current.LastIndexOf("/");
                    int checkingmultiply = current.LastIndexOf("*");

                    if (checkingdivide == -1)
                    {
                        if (checkingplus != -1)
                        {
                            string split1 = current.Substring(0, checkingplus);
                            string split2 = current.Substring(checkingplus + 1, current.Length - (checkingplus + 1));
                            double calculated_value = double.Parse(split1) + double.Parse(split2);
                            textBox2.Text = calculated_value.ToString();
                            textBox1.Text = textBox2.Text;
                            textBox2.Text += divide.Text;
                        }

                        else if (checkingmultiply != -1)
                        {
                            string split1 = current.Substring(0, checkingmultiply);
                            string split2 = current.Substring(checkingmultiply + 1, current.Length - (checkingmultiply + 1));
                            double calculated_value = double.Parse(split1) * double.Parse(split2);
                            textBox2.Text = calculated_value.ToString();
                            textBox1.Text = textBox2.Text;
                            textBox2.Text += divide.Text;
                        }
                        else if (checkingminus != -1)
                        {
                            string split1 = current.Substring(0, checkingminus);
                            string split2 = current.Substring(checkingminus + 1, current.Length - (checkingminus + 1));
                            double calculated_value = double.Parse(split1) - double.Parse(split2);
                            textBox2.Text = calculated_value.ToString();
                            textBox1.Text = textBox2.Text;
                            textBox2.Text += divide.Text;
                        }
                        else
                        {
                            textBox1.Text = textBox2.Text;
                            textBox2.Text += divide.Text;
                        }

                    }
                    else
                    {
                        string split1 = current.Substring(0, checkingdivide);
                        string split2 = current.Substring(checkingdivide + 1, current.Length - (checkingdivide + 1));
                        double calculated_value = double.Parse(split1) / double.Parse(split2);
                        textBox2.Text = calculated_value.ToString();
                        textBox1.Text = textBox2.Text;
                        textBox2.Text += divide.Text;

                    }
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            bool findplus, findminus, findmultiply, finddivide;
            string current = textBox2.Text;
            findplus = current.EndsWith("+");
            findminus = current.EndsWith("-");
            findmultiply = current.EndsWith("*");
            finddivide = current.EndsWith("/");


            if (findplus == true || findmultiply == true || finddivide == true)
            {
                int currentlen = textBox2.TextLength;
                textBox2.Text = current.Substring(0, currentlen - 1) + "-";
            }
            else
            {
                if (findminus == false)
                {
                    int checkingminus = current.LastIndexOf("-");
                    int checkingplus = current.LastIndexOf("+");
                    int checkingdivide = current.LastIndexOf("/");
                    int checkingmultiply = current.LastIndexOf("*");

                    if (checkingminus == -1)
                    {
                        if (checkingplus != -1)
                        {
                            string split1 = current.Substring(0, checkingplus);
                            string split2 = current.Substring(checkingplus + 1, current.Length - (checkingplus + 1));
                            double calculated_value = double.Parse(split1) + double.Parse(split2);
                            textBox2.Text = calculated_value.ToString();
                            textBox1.Text = textBox2.Text;
                            textBox2.Text += minus.Text;
                        }

                        else if (checkingdivide != -1)
                        {
                            string split1 = current.Substring(0, checkingdivide);
                            string split2 = current.Substring(checkingdivide + 1, current.Length - (checkingdivide + 1));
                            double calculated_value = double.Parse(split1) / double.Parse(split2);
                            textBox2.Text = calculated_value.ToString();
                            textBox1.Text = textBox2.Text;
                            textBox2.Text += minus.Text;
                        }
                        else if (checkingmultiply != -1)
                        {
                            string split1 = current.Substring(0, checkingmultiply);
                            string split2 = current.Substring(checkingmultiply + 1, current.Length - (checkingmultiply + 1));
                            double calculated_value = double.Parse(split1) * double.Parse(split2);
                            textBox2.Text = calculated_value.ToString();
                            textBox1.Text = textBox2.Text;
                            textBox2.Text += minus.Text;
                        }
                        else
                        {
                            textBox1.Text = textBox2.Text;
                            textBox2.Text += minus.Text;
                        }

                    }
                    else
                    {//here
                        string currents = textBox2.Text;
                        bool check_beginning = currents.StartsWith("-");
                        if (check_beginning == true)
                        {
                            int checkingplus_again = currents.LastIndexOf("+");
                            int checkingdivide_again = currents.IndexOf("/");
                            int checkingmultiply_again = currents.IndexOf("*");
                            int checkingminus_again = currents.LastIndexOf("-");


                            if (checkingminus_again != -1)
                            {
                                string split1 = currents.Substring(0, checkingminus_again);
                                string split2 = currents.Substring(checkingminus_again + 1, currents.Length - (checkingminus_again + 1));
                                //MessageBox.Show(split1, split2, MessageBoxButtons.OK);
                                double calculated_value = double.Parse(split1) - double.Parse(split2);
                                textBox2.Text = calculated_value.ToString();
                                textBox1.Text = textBox2.Text;
                                textBox2.Text += minus.Text;
                            }
                            else if (checkingmultiply_again != -1)
                            {
                                string split1 = currents.Substring(0, checkingmultiply_again);
                                string split2 = currents.Substring(checkingmultiply_again + 1, currents.Length - (checkingmultiply_again + 1));
                                //MessageBox.Show(split1, split2, MessageBoxButtons.OK);
                                double calculated_value = double.Parse(split1) * double.Parse(split2);
                                textBox2.Text = calculated_value.ToString();
                                textBox1.Text = textBox2.Text;
                                textBox2.Text += minus.Text;
                            }
                            else if (checkingdivide_again!=-1)
                            {
                                string split1 = currents.Substring(0, checkingdivide_again);
                                string split2 = currents.Substring(checkingdivide_again + 1, currents.Length - (checkingdivide_again + 1));
                                //MessageBox.Show(split1, split2, MessageBoxButtons.OK);
                                double calculated_value = double.Parse(split1) / double.Parse(split2);
                                textBox2.Text = calculated_value.ToString();
                                textBox1.Text = textBox2.Text;
                                textBox2.Text += minus.Text;
                            }
                            else if (checkingplus_again != -1)
                            {
                                string split1 = currents.Substring(0, checkingplus_again);
                                string split2 = currents.Substring(checkingplus_again + 1, currents.Length - (checkingplus_again + 1));
                               // MessageBox.Show(split1, split2, MessageBoxButtons.OK);
                                double calculated_value = double.Parse(split1) + double.Parse(split2);
                                textBox2.Text = calculated_value.ToString();
                                textBox1.Text = textBox2.Text;
                                textBox2.Text += minus.Text;
                            }
                        }
                        else
                        {
                            

                            string split3 = current.Substring(0, checkingminus);
                            string split4 = current.Substring(checkingminus + 1, current.Length - (checkingminus + 1));
                            //MessageBox.Show(split3, split4, MessageBoxButtons.OK);
                            double calculated_value = double.Parse(split3) - double.Parse(split4);
                            textBox2.Text = calculated_value.ToString();
                            textBox1.Text = textBox2.Text;
                            textBox2.Text += minus.Text;
                        }



                    }







                }

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bool findplus, findminus, findmultiply, finddivide;
            string current = textBox2.Text;
            findplus = current.EndsWith("+");
            findminus = current.EndsWith("-");
            findmultiply = current.EndsWith("*");
            finddivide = current.EndsWith("/");


            if (findplus == true || finddivide == true || findminus == true)
            {
                int currentlen = textBox2.TextLength;
                textBox2.Text = current.Substring(0, currentlen - 1) + "*";

            }
            else
            {
                if (findmultiply == false)
                {
                    int checkingminus = current.LastIndexOf("-");
                    int checkingplus = current.LastIndexOf("+");
                    int checkingdivide = current.LastIndexOf("/");
                    int checkingmultiply = current.LastIndexOf("*");

                    if (checkingmultiply == -1)
                    {
                        if (checkingplus != -1)
                        {
                            string split1 = current.Substring(0, checkingplus);
                            string split2 = current.Substring(checkingplus + 1, current.Length - (checkingplus + 1));
                            double calculated_value = double.Parse(split1) + double.Parse(split2);
                            textBox2.Text = calculated_value.ToString();
                            textBox1.Text = textBox2.Text;
                            textBox2.Text += multiply.Text;
                        }

                        else if (checkingdivide != -1)
                        {
                            string split1 = current.Substring(0, checkingdivide);
                            string split2 = current.Substring(checkingdivide + 1, current.Length - (checkingdivide + 1));
                            double calculated_value = double.Parse(split1) / double.Parse(split2);
                            textBox2.Text = calculated_value.ToString();
                            textBox1.Text = textBox2.Text;
                            textBox2.Text += multiply.Text;
                        }
                        else if (checkingminus != -1)
                        {
                            string split1 = current.Substring(0, checkingminus);
                            string split2 = current.Substring(checkingminus + 1, current.Length - (checkingminus + 1));
                            double calculated_value = double.Parse(split1) - double.Parse(split2);
                            textBox2.Text = calculated_value.ToString();
                            textBox1.Text = textBox2.Text;
                            textBox2.Text += multiply.Text;
                        }
                        else
                        {
                            textBox1.Text = textBox2.Text;
                            textBox2.Text += multiply.Text;
                        }

                    }
                    else
                    {
                        string split1 = current.Substring(0, checkingmultiply);
                        string split2 = current.Substring(checkingmultiply + 1, current.Length - (checkingmultiply + 1));
                        double calculated_value = double.Parse(split1) * double.Parse(split2);
                        textBox2.Text = calculated_value.ToString();
                        textBox1.Text = textBox2.Text;
                        textBox2.Text += multiply.Text;

                    }
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength > 0 || textBox1.TextLength > 0)
            {
                textBox2.Clear();
                textBox1.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "NaN")
            {
                
                textBox1.Text = "Math Error";


            }



        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "Math Error")
            {
                textBox1.Clear();

            }
            string current = textBox2.Text;
                int findplus = current.LastIndexOf("+");
                int findminus= current.LastIndexOf("-");
                int finddivide= current.LastIndexOf("/");
                int findmultiply = current.LastIndexOf("*");
            if (findplus != -1 )
                {
                    
                    string before = current.Substring(findplus+1,current.Length-(findplus+1));
                    int checksign_of_before = before.IndexOf(".");

                    if (checksign_of_before == -1)
                    {
                        textBox2.Text += button11.Text;
                    }

                }
            else if (findminus != -1)
            {

                string before = current.Substring(findminus + 1, current.Length - (findminus + 1));
                int checksign_of_before = before.IndexOf(".");

                if (checksign_of_before == -1)
                {
                    textBox2.Text += button11.Text;
                }

            }
            else if (finddivide != -1)
            {

                string before = current.Substring(finddivide + 1, current.Length - (finddivide + 1));
                int checksign_of_before = before.IndexOf(".");

                if (checksign_of_before == -1)
                {
                    textBox2.Text += button11.Text;
                }

            }
            else if (findmultiply != -1)
            {

                string before = current.Substring(findmultiply + 1, current.Length - (findmultiply + 1));
                int checksign_of_before = before.IndexOf(".");

                if (checksign_of_before == -1)
                {
                    textBox2.Text += button11.Text;
                }

            }

            else
                {
                    string before = current.Substring(0, current.Length);
                    int checksign_of_before = before.IndexOf(".");
                    if (checksign_of_before == -1)
                    {
                        textBox2.Text += button11.Text;
                    }
                    else
                    {
                        
                    }
                }

            
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            string current = textBox2.Text;
            int currentlen = textBox2.TextLength;
            if (currentlen > 0)
            {
                textBox2.Text = current.Substring(0, currentlen - 1);
                textBox1.Clear();
            }


        }

        private void button15_Click(object sender, EventArgs e)
        {
            string current = textBox2.Text;
            bool check_plus = current.EndsWith("+");
            bool check_minus = current.EndsWith("-");
            bool check_divide = current.EndsWith("/");
            bool check_multiply = current.EndsWith("*");
            bool check_point = current.EndsWith(".");

            if (check_plus==true || check_minus == true || check_divide == true || check_multiply == true || check_point==true)
            {
                textBox1.Text = "Math Error";
            }

            else
            {
                textBox1.Text = textBox2.Text;
                bool check_minus_again = current.StartsWith("-");
                if (check_minus_again==true)
                {
                    int findsign_type1 = current.LastIndexOf("+");
                    int findsign_type2 = current.LastIndexOf("-");
                    int findsign_type3 = current.IndexOf("/");
                    int findsign_type4 = current.IndexOf("*");

                     if (findsign_type2 != -1)
                    {
                        string currents = textBox2.Text;

                        int checkingplus_again = currents.LastIndexOf("+");
                        int checkingdivide_again = currents.IndexOf("/");
                        int checkingmultiply_again = currents.IndexOf("*");
                        int checkingminus_again = currents.LastIndexOf("-");

                                   
                        if (checkingminus_again != -1)
                        {
                            string split1 = currents.Substring(0, checkingminus_again);
                            string split2 = currents.Substring(checkingminus_again + 1, currents.Length - (checkingminus_again + 1));
                            //MessageBox.Show(split1, split2, MessageBoxButtons.OK);
                            double calculated_value = double.Parse(split1) - double.Parse(split2);
                            textBox1.Text = calculated_value.ToString();

                        }
                        else if (checkingmultiply_again != -1)
                        {
                            string split1 = currents.Substring(0, checkingmultiply_again);
                            string split2 = currents.Substring(checkingmultiply_again + 1, currents.Length - (checkingmultiply_again + 1));
                            //MessageBox.Show(split1, split2, MessageBoxButtons.OK);
                            double calculated_value = double.Parse(split1) * double.Parse(split2);
                            textBox1.Text = calculated_value.ToString();
                            
                        }
                        else if (checkingdivide_again != -1)
                        {
                            string split1 = currents.Substring(0, checkingdivide_again);
                            string split2 = currents.Substring(checkingdivide_again + 1, currents.Length - (checkingdivide_again + 1));
                            //MessageBox.Show(split1, split2, MessageBoxButtons.OK);
                            double calculated_value = double.Parse(split1) / double.Parse(split2);
                            textBox1.Text = calculated_value.ToString();
                            
                        }
                        else if (checkingplus_again != -1)
                        {
                            string split1 = currents.Substring(0, checkingplus_again);
                            string split2 = currents.Substring(checkingplus_again + 1, currents.Length - (checkingplus_again + 1));
                            double calculated_value = double.Parse(split1) + double.Parse(split2);
                            textBox1.Text = calculated_value.ToString();

                        }
                    }


                    else if (findsign_type1 != -1)
                    {
                        string split1 = current.Substring(0, findsign_type1);
                        string split2 = current.Substring(findsign_type1 + 1, current.Length - (findsign_type1 + 1));
                        double calculated_value = double.Parse(split1) + double.Parse(split2);
                        textBox1.Text = calculated_value.ToString();


                    }
                    else if (findsign_type3 != -1)
                    {
                        string sign = current.Substring(findsign_type3, 1);
                        string split1 = current.Substring(0, findsign_type3);
                        string split2 = current.Substring(findsign_type3 + 1, current.Length - (findsign_type3 + 1));
                        double calculated_value = double.Parse(split1) / double.Parse(split2);
                        textBox1.Text = calculated_value.ToString();
                        

                    }
                    else if (findsign_type4 != -1)
                    {
                        string sign = current.Substring(findsign_type4, 1);
                        string split1 = current.Substring(0, findsign_type4);
                        string split2 = current.Substring(findsign_type4 + 1, current.Length - (findsign_type4 + 1));
                        double calculated_value = double.Parse(split1) * double.Parse(split2);
                        textBox1.Text = calculated_value.ToString();
                        

                    }

                }
                else
                {

                    int findsign_type1 = current.LastIndexOf("+");
                    int findsign_type2 = current.LastIndexOf("-");
                    int findsign_type3 = current.IndexOf("/");
                    int findsign_type4 = current.IndexOf("*");

                    if (findsign_type1 != -1)
                    {
                        string split1 = current.Substring(0, findsign_type1);
                        string split2 = current.Substring(findsign_type1 + 1, current.Length - (findsign_type1 + 1));
                       MessageBox.Show(split1, split2,MessageBoxButtons.OK  );
                            //double calculated_value = double.Parse(split1) + double.Parse(split2);
                            //textBox1.Text = calculated_value.ToString();
                        

                    }
                   else if (findsign_type2 != -1)
                    {
                        string split1 = current.Substring(0, findsign_type2);
                        string split2 = current.Substring(findsign_type2 + 1, current.Length - (findsign_type2 + 1));
                        double calculated_value = double.Parse(split1) - double.Parse(split2);
                        textBox1.Text = calculated_value.ToString();
                        
                    }
                    else if (findsign_type3 != -1)
                    {
                        string sign = current.Substring(findsign_type3, 1);
                        string split1 = current.Substring(0, findsign_type3);
                        string split2 = current.Substring(findsign_type3 + 1, current.Length - (findsign_type3 + 1));
                        double calculated_value = double.Parse(split1) / double.Parse(split2);
                        textBox1.Text = calculated_value.ToString();
                        

                    }
                    else if (findsign_type4 != -1)
                    {
                        string sign = current.Substring(findsign_type4, 1);
                        string split1 = current.Substring(0, findsign_type4);
                        string split2 = current.Substring(findsign_type4 + 1, current.Length - (findsign_type4 + 1));
                        double calculated_value = double.Parse(split1) * double.Parse(split2);
                        textBox1.Text = calculated_value.ToString();
                        

                    }

                }

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutEvansToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
