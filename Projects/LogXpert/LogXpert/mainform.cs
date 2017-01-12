using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Net.Mail;
using System.Xml.XPath;
using System.Runtime.InteropServices;

namespace LogXpert
{
    public partial class mainform : Form
    {

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int val);
        public mainform()
        {
            InitializeComponent();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void mainform_Load(object sender, EventArgs e)
        {




            //

            int count = dataGridView1.Rows.Count;
            if (File.Exists("useraccount.xml"))
            {
                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");
                XmlNodeList xl = xd.SelectNodes("//user");

                foreach (XmlNode node in xl)
                {
                    string first = node.SelectSingleNode("FirstName").InnerText;
                    textBox1.Text = first;
                    string last = node.SelectSingleNode("LastName").InnerText;
                    textBox2.Text = last;
                    string gender = node.SelectSingleNode("Gender").InnerText;
                    if (gender == "Male")
                    {
                        radioButton1.Checked = true;
                        tabPage1.ImageIndex = 35;
                    }
                    else if (gender == "Female")
                    {
                        radioButton2.Checked = true;
                        tabPage1.ImageIndex = 34;
                    }

                    string verifier = node.SelectSingleNode("VerificationNotifier").InnerText;
                    if (verifier == "On")
                    {
                        checkBox1.Checked = true;
                    }
                    else if (verifier == "Off")
                    {
                        checkBox1.Checked = false;
                    }
                    string email = node.SelectSingleNode("Email").InnerText;
                    textBox3.Text = email;

                    string autologin = node.SelectSingleNode("AutoLogin").InnerText;
                    if (autologin == "On")
                    {
                        checkBox3.Checked = true;
                    }
                    else if (autologin == "Off")
                    {
                        checkBox3.Checked = false;
                    }

                    string maskpassword = node.SelectSingleNode("MaskPassword").InnerText;
                    if (maskpassword == "True")
                    {
                        checkBox4.Checked = true;

                        checkBox4.Text = "Unmask Passwords";
                    }
                    else if (maskpassword == "False")
                    {
                        checkBox4.Checked = false;

                        checkBox4.Text = "Mask Passwords";
                    }

                    string maskpassworddialog = node.SelectSingleNode("MaskPasswordDialog").InnerText;
                    if (maskpassworddialog == "On")
                    {
                        checkBox5.Checked = true;

                        checkBox5.Text = "Disable Mask Password Dialog";
                    }
                    else if (maskpassworddialog == "Off")
                    {
                        checkBox5.Checked = false;

                        checkBox5.Text = "Enable Mask Password Dialog";
                    }

                    string unmaskingauth = node.SelectSingleNode("UnmaskingAuthentication").InnerText;
                    if (unmaskingauth == "On")
                    {
                        checkBox6.Checked = true;

                        checkBox6.Text = "Deauthenticate Password Unmasking";
                    }
                    else if (unmaskingauth == "Off")
                    {
                        checkBox6.Checked = false;

                        checkBox6.Text = "Authenticate Password Unmasking";
                    }



                }

            }



            //Messages

            if (File.Exists("messages.xml"))
            {
                DataSet dss = new DataSet();
                dss.ReadXml("messages.xml");

                DataView dvs = new DataView(dss.Tables[0]);
                dvs.Sort = "DateTime Desc";
                dataGridView2.DataSource = dvs;
                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

                XmlDocument xd = new XmlDocument();
                xd.Load("messages.xml");
                XmlNodeList xl = xd.SelectNodes("messages/message");

                int coun = 0;
                foreach (XmlNode node in xl)
                {

                    if (node.SelectSingleNode("Status").InnerText == "Unread")
                    {
                        coun = coun + 1;
                        tabPage2.Text = "Notifications(" + coun + ")";
                    }



                }
            }


            timer1.Enabled = true;
            timer1.Start();
            timer2.Start();
            timer3.Start();

            XmlDocument xds = new XmlDocument();
            xds.Load("useraccount.xml");
            XmlNodeList xls = xds.SelectNodes("//user");
            foreach (XmlNode node in xls)
            {
                string name = node.SelectSingleNode("FirstName").InnerText;
                int counts = dataGridView1.Rows.Count;
                tabPage1.Text = name + "'s " + "(" + counts.ToString() + ")";

                if (counts > 0)
                {

                    textBox4.Enabled = true;
                    checkBox4.Enabled = true;
                    groupBox5.Location = new Point(19, 6);
                    groupBox5.Height = 55;
                }
                else
                {

                }

                textBox4.Enabled = false;
                checkBox4.Enabled = false;
                groupBox5.Location = new Point(19, 120);
                groupBox5.Height = 89;
            }



            if (File.Exists("accounts.xml"))
            {
                DataSet ds = new DataSet();
                ds.ReadXml("accounts.xml");

                DataView dv = new DataView(ds.Tables[0]);
                dv.Sort = "Id Desc";

                dataGridView1.DataSource = dv;

                dataGridView1.Columns[0].Visible = false;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");
                XmlNodeList xl = xd.SelectNodes("//user");
                int i;
                int coun = dataGridView1.Rows.Count;
                foreach (XmlNode node in xl)
                {
                    string name = node.SelectSingleNode("FirstName").InnerText;
                    tabPage1.Text = name + "'s" + "(" + coun.ToString() + ")";
                }

                if (coun > 0)
                {

                    textBox4.Enabled = true;
                    checkBox4.Enabled = true;
                    groupBox5.Location = new Point(19, 6);
                    groupBox5.Height = 55;
                }
                else
                {

                    textBox4.Enabled = false;
                    checkBox4.Enabled = false;
                    groupBox5.Location = new Point(19, 120);
                    groupBox5.Height = 89;
                }

                foreach (XmlNode node in xl)
                {
                    if (node.SelectSingleNode("MaskPassword").InnerText == "True")
                    {

                        for (i = 0; i <= coun - 1; i++)
                        {
                            if (dataGridView1.Rows[i].Cells[3].Value.ToString() != "<Nil>")
                            {
                                dataGridView1.Rows[i].Cells[3].Value = "*******";
                            }
                        }
                    }
                }




            }



            if (File.Exists("todo.xml"))
            {
                DataSet ds = new DataSet();
                ds.ReadXml("todo.xml");


                dataGridView3.DataSource = "";

                DataView dv = new DataView(ds.Tables[0]);
                dataGridView3.DataSource = dv;
                dv.Sort = "Status Desc";
                //dataGridView3.Columns[3].Visible = false;
                dataGridView3.Columns[2].Visible = false;
                dataGridView3.Columns[4].Visible = false;
                dataGridView3.Columns[6].Visible = false;
                dataGridView3.Columns[5].Visible = false;
                dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;


                int countin = 0;
                XmlDocument xdss = new XmlDocument();
                xdss.Load("todo.xml");
                XmlNodeList xlss = xdss.SelectNodes("todolist/todo");
                foreach (XmlNode node in xlss)
                {
                    if (node.SelectSingleNode("Status").InnerText == "Undone")
                    {
                        countin = countin + 1;
                        tabPage4.Text = "ToDo(" + countin + ")";
                    }
                    else
                    {
                        tabPage4.Text = "ToDo";
                    }
                }


            }

        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            XmlDocument xdis = new XmlDocument();
            xdis.Load("useraccount.xml");

            XmlNodeList xlx = xdis.SelectNodes("//user");

            foreach (XmlNode node in xlx)
            {
                string active = node.SelectSingleNode("Activated").InnerText;
                string remaining = node.SelectSingleNode("Remaining").InnerText;

                if (active == "No")
                {

                    groupBox8.Enabled = true;
                    pictureBox16.Show();

                    button7.Text = "Activate";

                    label13.Show();
                    pictureBox16.Show();
                    if (int.Parse(remaining) > 1)
                    {
                        label13.Text = remaining + " Trials Remaining";
                    }

                    else
                    {
                        label13.Text = remaining + " Trial Remaining";
                    }
                }
                else
                {

                    textBox5.Text = "081319842081234";
                    textBox5.UseSystemPasswordChar = true;
                    button7.Text = "Activated";
                    groupBox8.Enabled = false;
                    checkBox7.Checked = true;
                    label13.Hide();
                    pictureBox16.Hide();
                    checkBox7.Checked = true;
                }


            }



            int Out;
            if (InternetGetConnectedState(out Out, 0) == true)
            {
                // MessageBox.Show("Connected !");
                pictureBox15.Show();
                label12.Show();
                pictureBox13.Hide();
                label11.Hide();


            }
            else
            {
                // MessageBox.Show("Not Connected !");
                pictureBox13.Show();
                label11.Show();
                pictureBox15.Hide();
                label12.Hide();

            }

            if (File.Exists("useraccount.xml"))
            {
                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");
                XmlNodeList xl = xd.SelectNodes("//user");

                foreach (XmlNode node in xl)
                {
                    string first = node.SelectSingleNode("FirstName").InnerText;
                    textBox1.Text = first;
                    string last = node.SelectSingleNode("LastName").InnerText;
                    textBox2.Text = last;
                    string email = node.SelectSingleNode("Email").InnerText;
                    textBox3.Text = email;



                    string notification = node.SelectSingleNode("VerificationNotifier").InnerText;
                    if (notification == "On")
                    {
                        checkBox1.Checked = true;
                        checkBox1.Text = "Turn Off Verification Notifier";

                    }
                    else
                    {
                        checkBox1.Checked = false;
                        checkBox1.Text = "Turn On Verification Notifier";
                    }


                    string auto = node.SelectSingleNode("AutoLogin").InnerText;
                    if (auto == "On")
                    {
                        checkBox3.Checked = true;
                        checkBox3.Text = "Turn Off AutoLogin";

                    }
                    else
                    {
                        checkBox3.Checked = false;
                        checkBox3.Text = "Turn On AutoLogin";
                    }

                    string passdialogue = node.SelectSingleNode("MaskPasswordDialog").InnerText;
                    if (passdialogue == "On")
                    {
                        checkBox5.Checked = true;
                        checkBox5.Text = "Disable Mask Password Dialog";

                    }
                    else
                    {
                        checkBox5.Checked = false;
                        checkBox5.Text = "Enable Mask Password Dialog";
                    }

                    string unmask = node.SelectSingleNode("UnmaskingAuthentication").InnerText;
                    if (unmask == "On")
                    {
                        checkBox6.Checked = true;
                        checkBox6.Text = "Deauthenticate Password Unmasking ";

                    }
                    else
                    {
                        checkBox6.Checked = false;
                        checkBox6.Text = "Authenticate Password Unmasking ";
                    }

                    string verfiysent = node.SelectSingleNode("VerificationSent").InnerText;

                    string verify = node.SelectSingleNode("Verification").InnerText;
                    if (verify == "True")
                    {
                        linkLabel2.Hide();
                        linkLabel3.Show();
                        pictureBox4.Show();
                        linkLabel3.ForeColor = Color.LawnGreen;
                    }
                    else
                    {
                        linkLabel3.Hide();
                        pictureBox4.Hide();
                        linkLabel2.Show();
                    }

                }

            }


            if (File.Exists("messages.xml"))
            {
                button3.Visible = true;

                button4.Visible = false;
            }
            else
            {
                button3.Visible = false;

                button4.Visible = true;
            }


            if (File.Exists("todo.xml"))
            {
                //groupBox6.Hide();
                groupBox6.Location = new Point(26, 10);
                groupBox6.Size = new Size(711, 50);
                button6.Location = new Point(302, 15);



            }
            else
            {
                //groupBox6.Show();
                groupBox6.Location = new Point(26, 130);
                groupBox6.Size = new Size(711, 95);
                button6.Location = new Point(302, 35);
            }

            if (File.Exists("accounts.xml"))
            {
                textBox4.Enabled = true;
                checkBox4.Enabled = true;
                dataGridView1.Visible = true;
                groupBox5.Location = new Point(19, 6);
                groupBox5.Height = 55;
            }
            else
            {

                textBox4.Enabled = false;
                checkBox4.Enabled = false;
                dataGridView1.Visible = false;
                groupBox5.Location = new Point(19, 120);
                groupBox5.Height = 89;

            }



        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Cursor = Cursors.AppStarting;
            pictureBox2.Cursor = Cursors.Hand;
            string last = textBox2.Text;
            Form7 frm = new Form7(last);
            frm.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Cursor = Cursors.AppStarting;
            pictureBox3.Cursor = Cursors.Hand;
            string email = textBox3.Text;
            Form8 frm = new Form8(email);
            frm.ShowDialog();
        }




        private void button1_Click_1(object sender, EventArgs e)
        {



            AddAccounts frm = new AddAccounts();
            DialogResult res = frm.ShowDialog();
            if (res == DialogResult.OK)
            {


                if (File.Exists("accounts.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml("accounts.xml");

                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = "Id Desc";

                    dataGridView1.DataSource = dv;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

                    XmlDocument xd = new XmlDocument();
                    xd.Load("useraccount.xml");
                    XmlNodeList xl = xd.SelectNodes("//user");
                    int i;
                    int coun = dataGridView1.Rows.Count;
                    foreach (XmlNode node in xl)
                    {
                        string name = node.SelectSingleNode("FirstName").InnerText;
                        int counts = dataGridView1.Rows.Count;
                        tabPage1.Text = name + "'s " + "(" + counts.ToString() + ")";
                    }

                    foreach (XmlNode node in xl)
                    {
                        if (node.SelectSingleNode("MaskPassword").InnerText == "True")
                        {

                            for (i = 0; i <= coun - 1; i++)
                            {
                                if (dataGridView1.Rows[i].Cells[3].Value.ToString() != "<Nil>")
                                {
                                    dataGridView1.Rows[i].Cells[3].Value = "*******";
                                }
                            }
                        }
                    }




                }
            }
        }


        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "Filter Out Account")
            {
                textBox1.TextAlign = HorizontalAlignment.Left;
                textBox4.Clear();
                textBox4.ForeColor = Color.Black;

            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() == "")
            {
                textBox4.Text = "Filter Out Account";
                textBox4.ForeColor = Color.Silver;
                textBox1.TextAlign = HorizontalAlignment.Center;
            }
        }





        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dataGridView1.Rows[e.RowIndex].Selected = true;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1];


                string url = this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                if (url == "<http://>")
                {
                    visitURLToolStripMenuItem.Text = "";
                    visitURLToolStripMenuItem.Visible = false;

                }
                else
                {
                    if (url.Length > 21)
                    {
                        string urls = url.Substring(0, 20);
                        visitURLToolStripMenuItem.Text = "Visit " + urls + "...";
                        visitURLToolStripMenuItem.Visible = true;
                    }
                    else
                    {
                        visitURLToolStripMenuItem.Text = "Visit " + url;
                        visitURLToolStripMenuItem.Visible = true;
                    }

                }



                string urlss = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
                string username = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                string password = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                string desc = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();

                if (urlss == "<http://>")
                {
                    urlToolStripMenuItem.Text = "";
                    urlToolStripMenuItem.Visible = false;
                    toolStripSeparator6.Visible = false;
                    
                }
                else
                {
                    urlToolStripMenuItem.Text = "URL";
                    urlToolStripMenuItem.Visible = true;
                    toolStripSeparator6.Visible = true;
                }
                

                if (username == "<Nil>")
                {
                    userNameToolStripMenuItem.Text = "";
                    userNameToolStripMenuItem.Visible = false;
                    toolStripSeparator4.Visible = false;
                }
                else
                {
                    userNameToolStripMenuItem.Text = "Username";
                    userNameToolStripMenuItem.Visible =true;
                    toolStripSeparator4.Visible = true;
                }

                if (password == "<Nil>")
                {
                    passwordToolStripMenuItem.Text = "";
                    passwordToolStripMenuItem.Visible = false;
                    toolStripSeparator5.Visible = false;
                }
                else
                {
                    passwordToolStripMenuItem.Text = "Password";
                    passwordToolStripMenuItem.Visible = true;
                    toolStripSeparator5.Visible = true; ;
                }

                if (desc == "<Nil>")
                {
                    descriptionToolStripMenuItem.Text = "";
                    descriptionToolStripMenuItem.Visible = false;
                    
                }
                else
                {
                    descriptionToolStripMenuItem.Text = "Description";
                    descriptionToolStripMenuItem.Visible = true;
                    
                }


                CellMenu.Show(Cursor.Position);

            }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            string account = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string username = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            string password = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            string url = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString();
            string desc = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString();
            Edit_Account frm = new Edit_Account(id, account, username, password, url, desc);

            DialogResult res = frm.ShowDialog();
            if (res == DialogResult.OK)
            {

                if (File.Exists("accounts.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml("accounts.xml");

                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = "Id Desc";

                    dataGridView1.DataSource = dv;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

                    XmlDocument xd = new XmlDocument();
                    xd.Load("useraccount.xml");
                    XmlNodeList xl = xd.SelectNodes("//user");
                    int i;
                    int coun = dataGridView1.Rows.Count;

                    foreach (XmlNode node in xl)
                    {
                        string name = node.SelectSingleNode("FirstName").InnerText;
                        int counts = dataGridView1.Rows.Count;
                        tabPage1.Text = name + "'s " + "(" + counts.ToString() + ")";
                    }

                    foreach (XmlNode node in xl)
                    {
                        if (node.SelectSingleNode("MaskPassword").InnerText == "True")
                        {

                            for (i = 0; i <= coun - 1; i++)
                            {
                                if (dataGridView1.Rows[i].Cells[3].Value.ToString() != "<Nil>")
                                {
                                    dataGridView1.Rows[i].Cells[3].Value = "*******";
                                }
                            }
                        }
                    }




                }
            }





        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {



            deleteconfirmation frm = new deleteconfirmation();
            DialogResult res = frm.ShowDialog();


            if (res == DialogResult.Yes)
            {



                int counts = dataGridView1.Rows.Count;

                if (counts > 1)
                {

                    string id = this.dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();

                    XmlDocument xd = new XmlDocument();
                    xd.Load("accounts.xml");

                    XmlNodeList xl = xd.SelectNodes("accounts/account");
                    foreach (XmlNode node in xl)
                    {
                        string dbid = node.SelectSingleNode("Id").InnerText;
                        if (dbid == id)
                        {
                            node.ParentNode.RemoveChild(node);
                            xd.Save("accounts.xml");

                        }


                    }





                    DataSet ds = new DataSet();
                    ds.ReadXml("accounts.xml");

                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = "Id Desc";
                    dataGridView1.DataSource = dv;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
                    dataGridView1.Columns[0].Visible = false;

                    int i;
                    int coun = dataGridView1.Rows.Count;






                    XmlDocument xds = new XmlDocument();
                    xds.Load("useraccount.xml");
                    XmlNodeList xls = xds.SelectNodes("//user");
                    foreach (XmlNode nodes in xls)
                    {
                        string name = nodes.SelectSingleNode("FirstName").InnerText;
                        tabPage1.Text = name + "'s " + "(" + coun.ToString() + ")";
                        if (nodes.SelectSingleNode("MaskPassword").InnerText == "True")
                        {

                            for (i = 0; i <= coun - 1; i++)
                            {
                                if (dataGridView1.Rows[i].Cells[3].Value.ToString() != "<Nil>")
                                {
                                    dataGridView1.Rows[i].Cells[3].Value = "*******";
                                }
                            }
                        }
                    }




                    groupBox5.Location = new Point(19, 6);
                    groupBox5.Height = 55;

                }
                else if (counts == 1)
                {



                    XmlDocument xd = new XmlDocument();
                    xd.Load("useraccount.xml");
                    XmlNodeList xl = xd.SelectNodes("//user");
                    foreach (XmlNode node in xl)
                    {
                        string name = node.SelectSingleNode("FirstName").InnerText;

                        tabPage1.Text = name + "'s " + "(0)";

                    }
                    dataGridView1.Rows.RemoveAt(0);
                    File.Delete("accounts.xml");
                }
            }

        }



        private void checkBox4_Click(object sender, EventArgs e)
        {


            if (checkBox4.Checked == true)
            {
                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");

                XmlNodeList xl = xd.SelectNodes("//user");

                foreach (XmlNode node in xl)
                {

                    if (node.SelectSingleNode("MaskPasswordDialog").InnerText == "On")
                    {

                        maskpassword frm = new maskpassword();
                        DialogResult res = frm.ShowDialog();
                        if (res == DialogResult.OK)
                        {
                            int coun = dataGridView1.Rows.Count;
                            int i;

                            for (i = 0; i <= coun - 1; i++)
                            {
                                if (dataGridView1.Rows[i].Cells[3].Value.ToString() != "<Nil>")
                                {
                                    dataGridView1.Rows[i].Cells[3].Value = "*******";
                                }
                            }

                            checkBox4.Text = "Unmask Passwords";




                            node.SelectSingleNode("MaskPassword").InnerText = "True";
                        }


                    }
                    else
                    {
                        int coun = dataGridView1.Rows.Count;
                        int i;

                        for (i = 0; i <= coun - 1; i++)
                        {
                            if (dataGridView1.Rows[i].Cells[3].Value.ToString() != "<Nil>")
                            {
                                dataGridView1.Rows[i].Cells[3].Value = "*******";
                            }
                        }

                        checkBox4.Text = "Unmask Passwords";




                        node.SelectSingleNode("MaskPassword").InnerText = "True";
                    }
                    xd.Save("useraccount.xml");
                }
            }
            else
            {

                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");

                XmlNodeList xl = xd.SelectNodes("//user");
                //auth code
                foreach (XmlNode node in xl)
                {
                    string auth = node.SelectSingleNode("UnmaskingAuthentication").InnerText;
                    if (auth == "On")
                    {
                        unmaskauth frm = new unmaskauth();
                        DialogResult res = frm.ShowDialog();
                        if (res == DialogResult.OK)
                        {


                            if (File.Exists("accounts.xml"))
                            {
                                DataSet ds = new DataSet();
                                ds.ReadXml("accounts.xml");

                                DataView dv = new DataView(ds.Tables[0]);
                                dv.Sort = "Id Desc";
                                dataGridView1.DataSource = dv;
                                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
                                dataGridView1.Columns[0].Visible = false;
                            }

                            checkBox4.Text = "Mask Passwords";
                            node.SelectSingleNode("MaskPassword").InnerText = "False";

                            xd.Save("useraccount.xml");


                        }
                        else if (res == DialogResult.Cancel)
                        {
                            string auths = node.SelectSingleNode("MaskPassword").InnerText;
                            if (auths == "False")
                            {
                                checkBox4.Text = "Mask Passwords";
                                checkBox4.Checked = false;


                            }
                            else
                            {
                                checkBox4.Text = "UnMask Passwords";
                                checkBox4.Checked = true;
                            }


                        }
                    }
                    else
                    {


                        if (File.Exists("accounts.xml"))
                        {
                            DataSet ds = new DataSet();
                            ds.ReadXml("accounts.xml");

                            DataView dv = new DataView(ds.Tables[0]);
                            dv.Sort = "Id Desc";
                            dataGridView1.DataSource = dv;
                            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
                            dataGridView1.Columns[0].Visible = false;
                        }

                        checkBox4.Text = "Mask Passwords";
                        node.SelectSingleNode("MaskPassword").InnerText = "True";

                        xd.Save("useraccount.xml");

                    }
                }






            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {


            if (textBox4.Text != "Filter Out Account")
            {
                if (textBox4.TextLength > 0)
                {
                    pictureBox5.Show();
                }

                if (File.Exists("accounts.xml"))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml("accounts.xml");

                    DataView dv = new DataView(ds.Tables[0]);
                    dv.Sort = "Id Desc";
                    dv.RowFilter = "Account like '" + textBox4.Text.Trim() + "%'";
                    dataGridView1.DataSource = dv;

                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

                    XmlDocument xd = new XmlDocument();
                    xd.Load("useraccount.xml");
                    XmlNodeList xl = xd.SelectNodes("//user");
                    int i;
                    int coun = dataGridView1.Rows.Count;
                    foreach (XmlNode node in xl)
                    {
                        string name = node.SelectSingleNode("FirstName").InnerText;
                        tabPage1.Text = name + "'s" + "(" + coun.ToString() + ")";
                    }


                    foreach (XmlNode node in xl)
                    {
                        if (node.SelectSingleNode("MaskPassword").InnerText == "True")
                        {

                            for (i = 0; i <= coun - 1; i++)
                            {
                                if (dataGridView1.Rows[i].Cells[3].Value.ToString() != "<Nil>")
                                {
                                    dataGridView1.Rows[i].Cells[3].Value = "*******";
                                }
                            }
                        }
                    }




                }


            }
            else
            {
                pictureBox5.Hide();
            }
        }

        private void tabPage2_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


            deleteconfirmation frm = new deleteconfirmation();
            DialogResult res = frm.ShowDialog();


            if (res == DialogResult.Yes)
            {

                File.Delete("messages.xml");
                dataGridView2.DataSource = "";
                tabPage2.Text = "Notifications";
            }
        }

        private void tabPage2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView2.Rows[e.RowIndex].Selected = true;
                this.dataGridView2.CurrentCell = this.dataGridView2.Rows[e.RowIndex].Cells[1];
                contextMenuStrip2.Show(Cursor.Position);
            }
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {


            XmlDocument xd = new XmlDocument();
            xd.Load("messages.xml");

            XmlNodeList xl = xd.SelectNodes("messages/message");
            int coun = dataGridView2.Rows.Count;

            if (coun > 1)
            {
                string unique = this.dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[1].Value.ToString();
                foreach (XmlNode node in xl)
                {

                    string dbunique = node.SelectSingleNode("DateTime").InnerText;

                    if (unique == dbunique)
                    {

                        node.ParentNode.RemoveChild(node);
                        xd.Save("messages.xml");

                    }

                }

                DataSet ds = new DataSet();
                ds.ReadXml("messages.xml");

                DataView dv = new DataView(ds.Tables[0]);
                dv.Sort = "DateTime Desc";
                dataGridView2.DataSource = dv;
                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;


                int count = 0;
                foreach (XmlNode node in xl)
                {

                    if (node.SelectSingleNode("Status").InnerText == "Unread")
                    {
                        count = count + 1;
                        tabPage2.Text = "Notifications(" + count + ")";
                    }
                    else
                    {
                        tabPage2.Text = "Notifications";
                    }




                }

            }
            else
            {
                dataGridView2.DataSource = "";
                File.Delete("messages.xml");
            }







        }



        private void dataGridView2_MouseLeave(object sender, EventArgs e)
        {



            if (File.Exists("messages.xml"))
            {

                XmlDocument xd = new XmlDocument();
                xd.Load("messages.xml");
                XmlNodeList xl = xd.SelectNodes("messages/message");

                foreach (XmlNode node in xl)
                {

                    node.SelectSingleNode("Status").InnerText = "Read";


                }

                xd.Save("messages.xml");

                DataSet dss = new DataSet();
                dss.ReadXml("messages.xml");

                DataView dvs = new DataView(dss.Tables[0]);
                dvs.Sort = "DateTime Desc";
                dataGridView2.DataSource = dvs;
                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;


                int coun = 0;
                foreach (XmlNode node in xl)
                {

                    if (node.SelectSingleNode("Status").InnerText == "Unread")
                    {
                        coun = coun + 1;
                        tabPage2.Text = "Notifications(" + coun + ")";
                    }
                    else
                    {
                        tabPage2.Text = "Notifications";
                    }




                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {


            todo frm = new todo();
            DialogResult res = frm.ShowDialog(this);
            if (DialogResult.OK == res)
            {
                if (File.Exists("todo.xml"))
                {

                    XmlDocument xd = new XmlDocument();
                    xd.Load("todo.xml");

                    XmlNodeList xl = xd.SelectNodes("todolist/todo");

                    DataSet ds = new DataSet();
                    ds.ReadXml("todo.xml");


                    dataGridView3.DataSource = "";

                    DataView dv = new DataView(ds.Tables[0]);
                    dataGridView3.DataSource = dv;
                    dv.Sort = "Status Desc";
                    //dataGridView3.Columns[3].Visible = false;
                    dataGridView3.Columns[2].Visible = false;
                    dataGridView3.Columns[4].Visible = false;
                    dataGridView3.Columns[6].Visible = false;
                    dataGridView3.Columns[5].Visible = false;
                    dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;


                    int count = 0;
                    foreach (XmlNode node in xl)
                    {

                        if (node.SelectSingleNode("Status").InnerText == "Undone")
                        {
                            count = count + 1;
                            tabPage4.Text = "ToDo(" + count + ")";
                        }
                        else
                        {
                            tabPage4.Text = "ToDo";
                        }




                    }

                }

            }
        }

        private void dataGridView3_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView3.Rows[e.RowIndex].Selected = true;
                this.dataGridView3.CurrentCell = this.dataGridView3.Rows[e.RowIndex].Cells[1];
                contextMenuStrip3.Show(Cursor.Position);
            }

        }

        private void removeTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {


            XmlDocument xd = new XmlDocument();
            xd.Load("todo.xml");

            XmlNodeList xl = xd.SelectNodes("todolist/todo");
            int coun = dataGridView3.Rows.Count;


            if (coun > 1)
            {
                string unique = this.dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[6].Value.ToString();
                foreach (XmlNode node in xl)
                {

                    string dbunique = node.SelectSingleNode("Id").InnerText;

                    if (unique == dbunique)
                    {

                        node.ParentNode.RemoveChild(node);
                        xd.Save("todo.xml");

                    }

                }

                DataSet ds = new DataSet();
                ds.ReadXml("todo.xml");

                DataView dv = new DataView(ds.Tables[0]);
                dv.Sort = "Status Desc";
                dataGridView3.DataSource = dv;
                dataGridView3.Columns[2].Visible = false;
                dataGridView3.Columns[4].Visible = false;
                dataGridView3.Columns[5].Visible = false;
                dataGridView3.Columns[6].Visible = false;
                dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;


                int count = dataGridView3.Rows.Count;
                tabPage4.Text = "ToDo(" + count + ")";





            }
            else
            {
                dataGridView3.DataSource = "";
                File.Delete("todo.xml");
                tabPage4.Text = "ToDo";
            }






        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //todo alert


            if (File.Exists("todo.xml"))
            {
                XmlDocument xdss = new XmlDocument();
                xdss.Load("todo.xml");
                XmlNodeList xlss = xdss.SelectNodes("todolist/todo");

                foreach (XmlNode node in xlss)
                {

                    string time = node.SelectSingleNode("HiddenTime").InnerText;
                    string date = node.SelectSingleNode("HiddenDate").InnerText;

                    if (DateTime.Parse(time).Hour.ToString() == DateTime.Now.Hour.ToString() &&
                                DateTime.Parse(time).Minute.ToString() == DateTime.Now.Minute.ToString() &&
                                DateTime.Parse(date).Month.ToString() == DateTime.Now.Month.ToString() &&
                                DateTime.Parse(date).Year.ToString() == DateTime.Now.Year.ToString() &&
                                DateTime.Parse(date).Day.ToString() == DateTime.Now.Day.ToString())
                    {
                        string text = node.SelectSingleNode("Task").InnerText;
                        if (text != "")
                        {
                            notifyIcon1.BalloonTipText = text;
                        }
                        else
                        {
                            notifyIcon1.BalloonTipText = "No Task";
                        }

                        notifyIcon1.ShowBalloonTip(100000);

                        timer2.Stop();
                    }


                }

            }
        }

        private void notifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {
            timer2.Start();
        }


        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {
            dataGridView1.ScrollBars = ScrollBars.Both;
        }

        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {
            dataGridView1.ScrollBars = ScrollBars.None;
        }

        private void dataGridView2_MouseEnter(object sender, EventArgs e)
        {
            dataGridView2.ScrollBars = ScrollBars.Both;
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string copied = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            Clipboard.SetText(copied);
            MessageBox.Show("Copied!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void userNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string copied = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            Clipboard.SetText(copied);
            MessageBox.Show("Copied!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void passwordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string copied = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Clipboard.SetText(copied);
            MessageBox.Show("Copied!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void urlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string copied = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            Clipboard.SetText(copied);
            MessageBox.Show("Copied!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void descriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string copied = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            Clipboard.SetText(copied);
            MessageBox.Show("Copied!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

            DialogResult res = MessageBox.Show("You are about viewing my facebook profile", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("https://web.facebook.com/hillarynnamdi/about");
            }

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("You are about visiting my blog", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("http://hillarynnamdi.blogspot.com.ng");
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My mobile phone number is +234-813-1-984-208", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form12 frm = new Form12();
            frm.ShowDialog();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {


            if (File.Exists("useraccount.xml"))
            {
                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");


                XmlNodeList xl = xd.SelectNodes("//user");

                foreach (XmlNode node in xl)
                {
                    string verify = node.SelectSingleNode("Verification").InnerText;
                    string email = node.SelectSingleNode("Email").InnerText;
                    string last = node.SelectSingleNode("LastBackUp").InnerText;

                    if (verify == "False")
                    {
                        button8.Hide();
                        label9.Text = email + " (unverified)";
                        button5.Show();
                    }
                    else
                    {
                        button5.Hide();
                        button8.Show();
                        label9.Text = email + " (verified)";
                    }

                    if (last == "")
                    {
                        label10.Text = "Never";
                    }
                    else
                    {
                        label10.Text = last;
                    }


                }

            }
        }

        private void button5_Click_2(object sender, EventArgs e)
        {


            verifieralert frm = new verifieralert();
            DialogResult res = frm.ShowDialog();
            if (res == DialogResult.OK)
            {
                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");

                XmlNodeList xl = xd.SelectNodes("//user");
                foreach (XmlNode node in xl)
                {
                    string emails = node.SelectSingleNode("Email").InnerText;

                    string verifysent = node.SelectSingleNode("VerificationSent").InnerText;

                    string verify = node.SelectSingleNode("Verification").InnerText;

                    if (verify == "False" && verifysent == "Yes")
                    {

                        emailverifier frms = new emailverifier();
                        DialogResult rest = frms.ShowDialog();
                        if (rest == DialogResult.OK)
                        {
                            verifyemail2 frmss = new verifyemail2(emails, "");
                            frmss.ShowDialog();
                        }
                    }
                    else if (verify == "False" && verifysent == "No")
                    {
                        verifyemail2 frmss = new verifyemail2(emails, "");
                        frmss.ShowDialog();
                    }
                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (File.Exists("accounts.xml"))
            {

                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");

                XmlNodeList xl = xd.SelectNodes("//user");

                foreach (XmlNode nodess in xl)
                {
                    string email = nodess.SelectSingleNode("Email").InnerText.ToLower();


                    char[] splitchar = { '@' };
                    string[] strArr = email.Split(splitchar);

                    if (strArr[1].Contains("yahoo") || strArr[1].Contains("ymail"))
                    {
                        yahoo_temp frm = new yahoo_temp(email);
                        DialogResult res = frm.ShowDialog();
                        if (res == DialogResult.OK)
                        {
                            //message
                            if (File.Exists("messages.xml"))
                            {

                                XmlDocument xdmsg = new XmlDocument();
                                xdmsg.Load("messages.xml");

                                XmlElement xe = xdmsg.CreateElement("message");

                                XmlDocument xdss = new XmlDocument();
                                xdss.Load("useraccount.xml");
                                XmlNodeList xlss = xd.SelectNodes("//user");

                                foreach (XmlNode nodes in xlss)
                                {

                                    string name = nodes.SelectSingleNode("LastName").InnerText;


                                    XmlElement messages = xdmsg.CreateElement("Notification");
                                    messages.InnerText = "Hi " + name + ",Backup was successfully!";





                                    xe.AppendChild(messages);

                                }

                                XmlElement date = xdmsg.CreateElement("DateTime");
                                date.InnerText = DateTime.Now.ToString();
                                xe.AppendChild(date);

                                XmlElement type = xdmsg.CreateElement("Type");
                                type.InnerText = "Backup & Restore";
                                xe.AppendChild(type);

                                XmlElement status = xdmsg.CreateElement("Status");
                                status.InnerText = "Unread";
                                xe.AppendChild(status);

                                xdmsg.DocumentElement.AppendChild(xe);

                                xdmsg.Save("messages.xml");

                                DataSet set = new DataSet();
                                set.ReadXml("messages.xml");

                                DataView dview = new DataView(set.Tables[0]);
                                dview.Sort = "DateTime Desc";
                                dataGridView2.DataSource = dview;
                                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

                                tabPage2.Text = "Notification(new)";

                            }
                            else
                            {

                                XmlWriterSettings setting = new XmlWriterSettings();
                                setting.Indent = true;
                                XmlWriter xwriter = XmlWriter.Create("messages.xml", setting);

                                xwriter.WriteStartDocument(true);
                                xwriter.WriteStartElement("messages");
                                xwriter.WriteStartElement("message");

                                XmlDocument xdmsg = new XmlDocument();
                                xdmsg.Load("useraccount.xml");

                                XmlElement xe = xdmsg.CreateElement("message");

                                XmlNodeList xlss = xdmsg.SelectNodes("//user");

                                foreach (XmlNode nodes in xlss)
                                {
                                    string name = nodes.SelectSingleNode("FirstName").InnerText;
                                    string msg = "Hi " + name + ",Backup was successfully!";
                                    xwriter.WriteElementString("Notification", msg);
                                }




                                xwriter.WriteElementString("DateTime", DateTime.Now.ToString());
                                xwriter.WriteElementString("Type", "Backup & Restore");
                                xwriter.WriteElementString("Status", "Unread");
                                xwriter.WriteEndElement();
                                xwriter.WriteEndElement();
                                xwriter.WriteEndDocument();
                                xwriter.Close();

                                DataSet set = new DataSet();
                                set.ReadXml("messages.xml");

                                DataView dview = new DataView(set.Tables[0]);
                                dview.Sort = "DateTime Desc";
                                dataGridView2.DataSource = dview;
                                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

                                tabPage2.Text = "Notification(new)";

                            }

                            XmlDocument xds = new XmlDocument();
                            xds.Load("useraccount.xml");

                            XmlNodeList xls = xd.SelectNodes("//user");
                            foreach (XmlNode node in xls)
                            {
                                node.SelectSingleNode("LastBackUp").InnerText = DateTime.Now.ToString();
                                xd.Save("useraccount.xml");

                            }
                        }
                    }
                    else if (strArr[1].Contains("gmail"))
                    {
                        gmail_temp frms = new gmail_temp(email);
                        DialogResult res = frms.ShowDialog();
                        if (res == DialogResult.OK)
                        {
                            //message
                            if (File.Exists("messages.xml"))
                            {

                                XmlDocument xdmsg = new XmlDocument();
                                xdmsg.Load("messages.xml");

                                XmlElement xe = xdmsg.CreateElement("message");

                                XmlDocument xdss = new XmlDocument();
                                xdss.Load("useraccount.xml");
                                XmlNodeList xlss = xd.SelectNodes("//user");

                                foreach (XmlNode nodes in xlss)
                                {

                                    string name = nodes.SelectSingleNode("LastName").InnerText;


                                    XmlElement messages = xdmsg.CreateElement("Notification");
                                    messages.InnerText = "Hi " + name + ",Backup was successfully!";





                                    xe.AppendChild(messages);

                                }

                                XmlElement date = xdmsg.CreateElement("DateTime");
                                date.InnerText = DateTime.Now.ToString();
                                xe.AppendChild(date);

                                XmlElement type = xdmsg.CreateElement("Type");
                                type.InnerText = "Backup & Restore";
                                xe.AppendChild(type);

                                XmlElement status = xdmsg.CreateElement("Status");
                                status.InnerText = "Unread";
                                xe.AppendChild(status);

                                xdmsg.DocumentElement.AppendChild(xe);

                                xdmsg.Save("messages.xml");

                                DataSet set = new DataSet();
                                set.ReadXml("messages.xml");

                                DataView dview = new DataView(set.Tables[0]);
                                dview.Sort = "DateTime Desc";
                                dataGridView2.DataSource = dview;
                                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

                                tabPage2.Text = "Notification(new)";

                            }
                            else
                            {

                                XmlWriterSettings setting = new XmlWriterSettings();
                                setting.Indent = true;
                                XmlWriter xwriter = XmlWriter.Create("messages.xml", setting);

                                xwriter.WriteStartDocument(true);
                                xwriter.WriteStartElement("messages");
                                xwriter.WriteStartElement("message");

                                XmlDocument xdmsg = new XmlDocument();
                                xdmsg.Load("useraccount.xml");

                                XmlElement xe = xdmsg.CreateElement("message");

                                XmlNodeList xlss = xdmsg.SelectNodes("//user");

                                foreach (XmlNode nodes in xlss)
                                {
                                    string name = nodes.SelectSingleNode("FirstName").InnerText;
                                    string msg = "Hi " + name + ",Backup was successfully!";
                                    xwriter.WriteElementString("Notification", msg);
                                }




                                xwriter.WriteElementString("DateTime", DateTime.Now.ToString());
                                xwriter.WriteElementString("Type", "Backup & Restore");
                                xwriter.WriteElementString("Status", "Unread");
                                xwriter.WriteEndElement();
                                xwriter.WriteEndElement();
                                xwriter.WriteEndDocument();
                                xwriter.Close();

                                DataSet set = new DataSet();
                                set.ReadXml("messages.xml");

                                DataView dview = new DataView(set.Tables[0]);
                                dview.Sort = "DateTime Desc";
                                dataGridView2.DataSource = dview;
                                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

                                tabPage2.Text = "Notification(new)";

                            }

                            XmlDocument xds = new XmlDocument();
                            xds.Load("useraccount.xml");

                            XmlNodeList xls = xd.SelectNodes("//user");
                            foreach (XmlNode node in xls)
                            {
                                node.SelectSingleNode("LastBackUp").InnerText = DateTime.Now.ToString();
                                xd.Save("useraccount.xml");

                            }
                        }
                    }
                    else if (strArr[1].Contains("hotmail") || strArr[1].Contains("outlook") || strArr[1].Contains("live"))
                    {
                        outlook frm = new outlook(email);
                        DialogResult res = frm.ShowDialog();
                        if (res == DialogResult.OK)
                        {
                            //message
                            if (File.Exists("messages.xml"))
                            {

                                XmlDocument xdmsg = new XmlDocument();
                                xdmsg.Load("messages.xml");

                                XmlElement xe = xdmsg.CreateElement("message");

                                XmlDocument xdss = new XmlDocument();
                                xdss.Load("useraccount.xml");
                                XmlNodeList xlss = xd.SelectNodes("//user");

                                foreach (XmlNode nodes in xlss)
                                {

                                    string name = nodes.SelectSingleNode("LastName").InnerText;


                                    XmlElement messages = xdmsg.CreateElement("Notification");
                                    messages.InnerText = "Hi " + name + ",Backup was successfully!";





                                    xe.AppendChild(messages);

                                }

                                XmlElement date = xdmsg.CreateElement("DateTime");
                                date.InnerText = DateTime.Now.ToString();
                                xe.AppendChild(date);

                                XmlElement type = xdmsg.CreateElement("Type");
                                type.InnerText = "Backup & Restore";
                                xe.AppendChild(type);

                                XmlElement status = xdmsg.CreateElement("Status");
                                status.InnerText = "Unread";
                                xe.AppendChild(status);

                                xdmsg.DocumentElement.AppendChild(xe);

                                xdmsg.Save("messages.xml");

                                DataSet set = new DataSet();
                                set.ReadXml("messages.xml");

                                DataView dview = new DataView(set.Tables[0]);
                                dview.Sort = "DateTime Desc";
                                dataGridView2.DataSource = dview;
                                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

                                tabPage2.Text = "Notification(new)";

                            }
                            else
                            {

                                XmlWriterSettings setting = new XmlWriterSettings();
                                setting.Indent = true;
                                XmlWriter xwriter = XmlWriter.Create("messages.xml", setting);

                                xwriter.WriteStartDocument(true);
                                xwriter.WriteStartElement("messages");
                                xwriter.WriteStartElement("message");

                                XmlDocument xdmsg = new XmlDocument();
                                xdmsg.Load("useraccount.xml");

                                XmlElement xe = xdmsg.CreateElement("message");

                                XmlNodeList xlss = xdmsg.SelectNodes("//user");

                                foreach (XmlNode nodes in xlss)
                                {
                                    string name = nodes.SelectSingleNode("FirstName").InnerText;
                                    string msg = "Hi " + name + ",Backup was successfully!";
                                    xwriter.WriteElementString("Notification", msg);
                                }




                                xwriter.WriteElementString("DateTime", DateTime.Now.ToString());
                                xwriter.WriteElementString("Type", "Backup & Restore");
                                xwriter.WriteElementString("Status", "Unread");
                                xwriter.WriteEndElement();
                                xwriter.WriteEndElement();
                                xwriter.WriteEndDocument();
                                xwriter.Close();

                                DataSet set = new DataSet();
                                set.ReadXml("messages.xml");

                                DataView dview = new DataView(set.Tables[0]);
                                dview.Sort = "DateTime Desc";
                                dataGridView2.DataSource = dview;
                                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

                                tabPage2.Text = "Notification(new)";

                            }

                            XmlDocument xds = new XmlDocument();
                            xds.Load("useraccount.xml");

                            XmlNodeList xls = xd.SelectNodes("//user");
                            foreach (XmlNode node in xls)
                            {
                                node.SelectSingleNode("LastBackUp").InnerText = DateTime.Now.ToString();
                                xd.Save("useraccount.xml");

                            }
                        }
                    }

                    else
                    {
                        MessageBox.Show("nothing");
                    }




                }
            }
            else
            {
                MessageBox.Show("No accounts to back up","Notification",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {


            DialogResult res = openFileDialog1.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                try
                {
                    XmlDocument xd = new XmlDocument();
                    xd.Load(openFileDialog1.FileName);
                    string last = xd.DocumentElement.ParentNode.LastChild.Name;
                    string first = xd.DocumentElement.ParentNode.FirstChild.Name;


                    if (last != "accounts" || first != "xml")
                    {
                        MessageBox.Show("Restore Failed: Invalid File Content");
                    }
                    else if (last == "accounts" && first == "xml")
                    {
                        bool children = xd.DocumentElement.ParentNode.LastChild.HasChildNodes;
                        if (children == true)
                        {
                            XmlNodeList xl = xd.SelectNodes("accounts/account");
                            int counting = xl.Count;
                            int nodecount = 0;

                            foreach (XmlNode node in xl)
                            {

                                int coun = node.ChildNodes.Count;

                                if (coun == 7)
                                {
                                    int i;
                                    for (i = 0; i <= coun - 1; i++)
                                    {
                                        string chidnode = node.ChildNodes[i].Name;
                                        if (chidnode != "Account" && chidnode != "Id" && chidnode != "URL" &&
                                            chidnode != "Saved" && chidnode != "Username" && chidnode != "Password" && chidnode != "Description"

                                            )
                                        {
                                            MessageBox.Show("Restore Failed: Invalid File Content");
                                            break;
                                        }
                                        else
                                        {

                                            if (chidnode == "Id")
                                            {

                                                string id = node.ChildNodes[i].InnerText;
                                                int ids;
                                                bool isint = int.TryParse(id, out ids);

                                                if (id == "" || isint == false)
                                                {
                                                    MessageBox.Show("Restore Failed: Invalid File Content");
                                                    break;
                                                }
                                            }
                                            else if (chidnode == "Account")
                                            {
                                                string acct = node.ChildNodes[i].InnerText;
                                                if (acct == "")
                                                {
                                                    MessageBox.Show("Restore Failed: Invalid File Content");
                                                    break;
                                                }
                                            }
                                            else if (chidnode == "Saved")
                                            {
                                                string saved = node.ChildNodes[i].InnerText;
                                                DateTime outdates;
                                                bool isdatetime = DateTime.TryParse(saved, out outdates);

                                                if (saved == "" || isdatetime == false)
                                                {
                                                    MessageBox.Show("Restore Failed: Invalid File Content");
                                                    break;
                                                }
                                                nodecount = nodecount + 1;
                                                if (nodecount == counting)
                                                {
                                                    File.Copy(openFileDialog1.FileName, "accounts.xml", true);
                                                    timer4.Start();
                                                    Form13 frm = new Form13();
                                                    frm.ShowDialog(this);



                                                }



                                            }




                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Restore Failed: Invalid File Content");
                                    break;
                                }




                            }
                        }
                        else
                        {
                            MessageBox.Show("Restore Failed: Invalid File Content");
                        }
                    }


                }
                catch (XmlException)
                {
                    MessageBox.Show("Restore Failed: Invalid File Content");
                }


            }



        }

        private void mainform_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult res = MessageBox.Show("Are you sure you want to Close LogXpert?", "Quit LogXpert", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }


        }

        private void timer4_Tick(object sender, EventArgs e)
        {

            if (File.Exists("accounts.xml"))
            {
                DataSet ds = new DataSet();
                ds.ReadXml("accounts.xml");

                DataView dv = new DataView(ds.Tables[0]);
                dv.Sort = "Id Desc";

                dataGridView1.DataSource = dv;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");
                XmlNodeList xl = xd.SelectNodes("//user");
                int i;
                int coun = dataGridView1.Rows.Count;
                foreach (XmlNode node in xl)
                {
                    string name = node.SelectSingleNode("FirstName").InnerText;
                    int counts = dataGridView1.Rows.Count;
                    tabPage1.Text = name + "'s " + "(" + counts.ToString() + ")";
                }

                foreach (XmlNode node in xl)
                {
                    if (node.SelectSingleNode("MaskPassword").InnerText == "True")
                    {

                        for (i = 0; i <= coun - 1; i++)
                        {
                            if (dataGridView1.Rows[i].Cells[3].Value.ToString() != "<Nil>")
                            {
                                dataGridView1.Rows[i].Cells[3].Value = "*******";
                            }
                        }
                    }
                }




            }

            //message


            if (File.Exists("messages.xml"))
            {

                XmlDocument xdmsg = new XmlDocument();
                xdmsg.Load("messages.xml");

                XmlElement xe = xdmsg.CreateElement("message");

                XmlDocument xds = new XmlDocument();
                xds.Load("useraccount.xml");
                XmlNodeList xls = xds.SelectNodes("//user");

                foreach (XmlNode nodes in xls)
                {

                    string name = nodes.SelectSingleNode("LastName").InnerText;


                    XmlElement messages = xdmsg.CreateElement("Notification");
                    messages.InnerText = "Hi " + name + ",accounts restoration was successfully!";





                    xe.AppendChild(messages);

                }

                XmlElement date = xdmsg.CreateElement("DateTime");
                date.InnerText = DateTime.Now.ToString();
                xe.AppendChild(date);

                XmlElement type = xdmsg.CreateElement("Type");
                type.InnerText = "Backup & Restore";
                xe.AppendChild(type);

                XmlElement status = xdmsg.CreateElement("Status");
                status.InnerText = "Unread";
                xe.AppendChild(status);

                xdmsg.DocumentElement.AppendChild(xe);

                xdmsg.Save("messages.xml");

            }
            else
            {


                XmlWriterSettings setting = new XmlWriterSettings();
                setting.Indent = true;
                XmlWriter xwriter = XmlWriter.Create("messages.xml", setting);

                xwriter.WriteStartDocument(true);
                xwriter.WriteStartElement("messages");
                xwriter.WriteStartElement("message");

                XmlDocument xdmsg = new XmlDocument();
                xdmsg.Load("useraccount.xml");

                XmlElement xe = xdmsg.CreateElement("message");

                XmlNodeList xls = xdmsg.SelectNodes("//user");

                foreach (XmlNode nodes in xls)
                {
                    string name = nodes.SelectSingleNode("FirstName").InnerText;
                    string msg = "Hi " + name + ",accounts restoration was successfully!";
                    xwriter.WriteElementString("Notification", msg);
                }




                xwriter.WriteElementString("DateTime", DateTime.Now.ToString());
                xwriter.WriteElementString("Type", "Backup & Restore");
                xwriter.WriteElementString("Status", "Unread");
                xwriter.WriteEndElement();
                xwriter.WriteEndElement();
                xwriter.WriteEndDocument();
                xwriter.Close();
            }


            DataSet set = new DataSet();
            set.ReadXml("messages.xml");

            DataView dview = new DataView(set.Tables[0]);
            dview.Sort = "DateTime Desc";
            dataGridView2.DataSource = dview;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            tabPage2.Text = "Notification(new)";


            timer4.Stop();










        }


        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text.Trim() == "Enter License Key")
            {
                textBox5.Clear();
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {


            if (textBox5.Text == "1112131415161718")
            {
                textBox5.UseSystemPasswordChar = true;
                button7.Text = "Activated";
                groupBox8.Enabled = false;
                checkBox7.Checked = true;
                label13.Hide();
                pictureBox16.Hide();

                MessageBox.Show("Activated!", "License Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);


                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");

                XmlNodeList xl = xd.SelectNodes("//user");

                foreach (XmlNode node in xl)
                {
                    node.SelectSingleNode("Activated").InnerText = "Yes";
                    xd.Save("useraccount.xml");
                }

                if (File.Exists("messages.xml"))
                {

                    XmlDocument xdmsg = new XmlDocument();
                    xdmsg.Load("messages.xml");

                    XmlElement xe = xdmsg.CreateElement("message");

                    XmlDocument xds = new XmlDocument();
                    xds.Load("useraccount.xml");
                    XmlNodeList xls = xd.SelectNodes("//user");

                    foreach (XmlNode node in xls)
                    {
                        string name = node.SelectSingleNode("LastName").InnerText;

                        XmlElement messages = xdmsg.CreateElement("Notification");
                        messages.InnerText = "Hi " + name + ",this software was activated successfully!";
                        xe.AppendChild(messages);

                    }

                    XmlElement date = xdmsg.CreateElement("DateTime");
                    date.InnerText = DateTime.Now.ToString();
                    xe.AppendChild(date);

                    XmlElement type = xdmsg.CreateElement("Type");
                    type.InnerText = "Activion Status";
                    xe.AppendChild(type);

                    XmlElement status = xdmsg.CreateElement("Status");
                    status.InnerText = "Unread";
                    xe.AppendChild(status);

                    xdmsg.DocumentElement.AppendChild(xe);

                    xdmsg.Save("messages.xml");

                }
                else
                {

                    XmlWriterSettings setting = new XmlWriterSettings();
                    setting.Indent = true;
                    XmlWriter xwriter = XmlWriter.Create("messages.xml", setting);

                    xwriter.WriteStartDocument(true);
                    xwriter.WriteStartElement("messages");
                    xwriter.WriteStartElement("message");

                    XmlDocument xdmsg = new XmlDocument();
                    xdmsg.Load("useraccount.xml");

                    XmlElement xe = xdmsg.CreateElement("message");

                    XmlNodeList xls = xdmsg.SelectNodes("//user");

                    foreach (XmlNode node in xls)
                    {
                        string name = node.SelectSingleNode("LastName").InnerText;
                        string msg = "Hi " + name + ",this software was activated successfully!";
                        xwriter.WriteElementString("Notification", msg);
                    }




                    xwriter.WriteElementString("DateTime", DateTime.Now.ToString());
                    xwriter.WriteElementString("Type", "Activation Status");
                    xwriter.WriteElementString("Status", "Unread");
                    xwriter.WriteEndElement();
                    xwriter.WriteEndElement();
                    xwriter.WriteEndDocument();
                    xwriter.Close();
                }



                if (File.Exists("messages.xml"))
                {
                    DataSet dss = new DataSet();
                    dss.ReadXml("messages.xml");

                    DataView dvs = new DataView(dss.Tables[0]);
                    dvs.Sort = "DateTime Desc";
                    dataGridView2.DataSource = dvs;
                    dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

                    XmlDocument xdh = new XmlDocument();
                    xdh.Load("messages.xml");
                    XmlNodeList xlh = xdh.SelectNodes("messages/message");

                    int coun = 0;
                    foreach (XmlNode node in xlh)
                    {

                        if (node.SelectSingleNode("Status").InnerText == "Unread")
                        {
                            coun = coun + 1;
                            tabPage2.Text = "Notifications(" + coun + ")";
                        }



                    }
                }



            }


            else if (textBox5.TextLength == 16 && textBox5.Text != "1112131415161718")
            {
                MessageBox.Show("Incorrect License Key,please contact +234-813-198-4-208", "License Manager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {


            if (checkBox7.Checked == true)
            {
                if (textBox5.Text == "Enter License Key")
                {
                    textBox5.Clear();
                    textBox5.Focus();
                    textBox5.ForeColor = Color.Black;
                    textBox5.UseSystemPasswordChar = true;
                }
                else
                {
                    textBox5.Focus();
                    textBox5.ForeColor = Color.Black;
                    textBox5.UseSystemPasswordChar = true;
                }
            }
            else if (checkBox7.Checked == false)
            {
                textBox5.UseSystemPasswordChar = false;
                textBox5.ForeColor = Color.Black;


            }





        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            Form16 frm = new Form16();
            DialogResult res = frm.ShowDialog();
            if (res == DialogResult.OK)
            {
                changepassword frms = new changepassword();
                DialogResult rest = frms.ShowDialog();
                if (rest == DialogResult.OK)
                {
                    if (File.Exists("messages.xml"))
                    {
                        DataSet dss = new DataSet();
                        dss.ReadXml("messages.xml");

                        DataView dvs = new DataView(dss.Tables[0]);
                        dvs.Sort = "DateTime Desc";
                        dataGridView2.DataSource = dvs;
                        dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

                        XmlDocument xd = new XmlDocument();
                        xd.Load("messages.xml");
                        XmlNodeList xl = xd.SelectNodes("messages/message");

                        int coun = 0;
                        foreach (XmlNode node in xl)
                        {

                            if (node.SelectSingleNode("Status").InnerText == "Unread")
                            {
                                coun = coun + 1;
                                tabPage2.Text = "Notifications(" + coun + ")";
                            }



                        }
                    }
                }
            }
        }



        private void checkBox1_Click(object sender, EventArgs e)
        {


            if (checkBox1.Checked == true)
            {
                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");
                XmlNodeList xl = xd.SelectNodes("//user");
                foreach (XmlNode node in xl)
                {
                    node.SelectSingleNode("VerificationNotifier").InnerText = "On";
                    xd.Save("useraccount.xml");
                }
            }
            else if (checkBox1.Checked == false)
            {
                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");
                XmlNodeList xl = xd.SelectNodes("//user");
                foreach (XmlNode node in xl)
                {
                    node.SelectSingleNode("VerificationNotifier").InnerText = "Off";
                    xd.Save("useraccount.xml");
                }
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            XmlDocument xd = new XmlDocument();
            xd.Load("useraccount.xml");

            XmlNodeList xnl = xd.SelectNodes("//user");

            string pass = textBox2.Text.ToLower().Trim();
            foreach (XmlNode node in xnl)
            {

                string emails = node.SelectSingleNode("Email").InnerText;

                string verifysent = node.SelectSingleNode("VerificationSent").InnerText;
                string verify = node.SelectSingleNode("Verification").InnerText;

                if (verify == "False" && verifysent == "Yes")
                {

                    emailverifier frms = new emailverifier();
                    DialogResult rest = frms.ShowDialog();
                    if (rest == DialogResult.OK)
                    {

                        verifyemail2 frmss = new verifyemail2(emails, "");
                        frmss.ShowDialog();
                    }
                }
                else if (verify == "False" && verifysent == "No")
                {
                    verifyemail2 frmss = new verifyemail2(emails, "");
                    frmss.ShowDialog();
                }
            }
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {


            if (checkBox3.Checked == true)
            {
                unmaskauth frm = new unmaskauth();
                DialogResult res = frm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    XmlDocument xd = new XmlDocument();
                    xd.Load("useraccount.xml");
                    XmlNodeList xl = xd.SelectNodes("//user");
                    foreach (XmlNode node in xl)
                    {
                        node.SelectSingleNode("AutoLogin").InnerText = "On";
                        xd.Save("useraccount.xml");
                    }
                }
            }
            else if (checkBox3.Checked == false)
            {
                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");
                XmlNodeList xl = xd.SelectNodes("//user");
                foreach (XmlNode node in xl)
                {
                    node.SelectSingleNode("AutoLogin").InnerText = "Off";
                    xd.Save("useraccount.xml");
                }
            }
        }

        private void checkBox5_Click(object sender, EventArgs e)
        {


            if (checkBox5.Checked == true)
            {
                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");
                XmlNodeList xl = xd.SelectNodes("//user");
                foreach (XmlNode node in xl)
                {
                    node.SelectSingleNode("MaskPasswordDialog").InnerText = "On";
                    xd.Save("useraccount.xml");
                }
            }
            else if (checkBox5.Checked == false)
            {
                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");
                XmlNodeList xl = xd.SelectNodes("//user");
                foreach (XmlNode node in xl)
                {
                    node.SelectSingleNode("MaskPasswordDialog").InnerText = "Off";
                    xd.Save("useraccount.xml");
                }
            }
        }

        private void checkBox6_Click(object sender, EventArgs e)
        {


            if (checkBox6.Checked == true)
            {



                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");
                XmlNodeList xl = xd.SelectNodes("//user");
                foreach (XmlNode node in xl)
                {
                    node.SelectSingleNode("UnmaskingAuthentication").InnerText = "On";
                    xd.Save("useraccount.xml");
                }

            }
            else if (checkBox6.Checked == false)
            {
                unmaskauth frm = new unmaskauth();
                DialogResult res = frm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    XmlDocument xd = new XmlDocument();
                    xd.Load("useraccount.xml");
                    XmlNodeList xl = xd.SelectNodes("//user");
                    foreach (XmlNode node in xl)
                    {
                        node.SelectSingleNode("UnmaskingAuthentication").InnerText = "Off";
                        xd.Save("useraccount.xml");
                    }
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {


            pictureBox1.Cursor = Cursors.AppStarting;
            pictureBox1.Cursor = Cursors.Hand;
            string first = textBox1.Text;
            Form6 frm = new Form6(first);
            DialogResult res = frm.ShowDialog();
            if (res == DialogResult.OK)
            {
                XmlDocument xd = new XmlDocument();
                xd.Load("useraccount.xml");
                XmlNodeList xl = xd.SelectNodes("//user");

                foreach (XmlNode node in xl)
                {
                    string name = node.SelectSingleNode("FirstName").InnerText;
                    int counts = dataGridView1.Rows.Count;
                    tabPage1.Text = name + "'s " + "(" + counts.ToString() + ")";


                }
            }
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {


            XmlDocument xd = new XmlDocument();
            xd.Load("useraccount.xml");
            XmlNodeList xl = xd.SelectNodes("//user");
            foreach (XmlNode node in xl)
            {
                node.SelectSingleNode("Gender").InnerText = "Female";
                xd.Save("useraccount.xml");
                tabPage1.ImageIndex = 34;
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {


            XmlDocument xd = new XmlDocument();
            xd.Load("useraccount.xml");
            XmlNodeList xl = xd.SelectNodes("//user");
            foreach (XmlNode node in xl)
            {
                node.SelectSingleNode("Gender").InnerText = "Male";
                xd.Save("useraccount.xml");

                tabPage1.ImageIndex = 35;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox4.Text = "Filter Out Account";
            textBox4.ForeColor = Color.Silver;
            textBox1.TextAlign = HorizontalAlignment.Center;
            button1.Focus();


        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void visitURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            DialogResult res = MessageBox.Show("You are about visiting " + url, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(url);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            XmlDocument xd = new XmlDocument();
            xd.Load("useraccount.xml");

            XmlNodeList xl = xd.SelectNodes("//user");

            foreach (XmlNode node in xl)
            {
                string email = node.SelectSingleNode("Email").InnerText.ToLower();


                char[] splitchar = { '@' };
                string[] strArr = email.Split(splitchar);

                if (strArr[1].Contains("yahoo"))
                {
                    yahoo_temp frm = new yahoo_temp(email);
                    frm.ShowDialog();
                }
                else if (strArr[1].Contains("gmail"))
                {
                    gmail_temp frms = new gmail_temp(email);
                    frms.ShowDialog();
                }
                else if (strArr[1].Contains("hotmail") || strArr[1].Contains("outlook") || strArr[1].Contains("live"))
                {
                    outlook frm = new outlook(email);
                    frm.ShowDialog();
                }

                else
                {
                    MessageBox.Show("Unrecognised E-mail Server.Please use either Gmail,Yahoo! or Outlook(Hotmail,Live) only");
                }








            }
        }

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1];


            
        }
    }
}







