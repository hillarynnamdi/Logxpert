using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LogXpert
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Directory.SetCurrentDirectory(Path.Combine(Environment.GetFolderPath(
               //Environment.SpecialFolder.ApplicationData), "LogXpert"));

            if (File.Exists(Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "LogXpert/useraccount.xml")))
            {
                Directory.SetCurrentDirectory(Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "LogXpert"));
                Application.Run(new Form1(""));
            }
            else
            {
                                
                Application.Run(new Form3());

            }

            


        }
    }
}
