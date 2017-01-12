using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using Microsoft.VisualBasic.FileIO;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {


            string maindir = "c:/app";
            string mainfolder = Path.Combine(maindir, "subfolders");
            string mainfolderfile = Path.Combine(maindir, "subfolders/text.txt");
            string copyingfolder = Path.Combine(maindir, "copied");
            string copyingfile = Path.Combine(maindir, "copied/text.txt");


            if (!Directory.Exists(mainfolder)){
                Directory.CreateDirectory(mainfolder);
                Directory.CreateDirectory(copyingfolder);
                File.Create(mainfolderfile);
                File.Create(copyingfile);

                FileSystem.CopyDirectory(copyingfolder, mainfolder, UIOption.AllDialogs);
                ZipFile.CreateFromDirectory(mainfolder, mainfolder + ".zip", CompressionLevel.Fastest, true);

                Console.WriteLine("copied and zipped");


            }
            else
            {
                FileSystem.CopyDirectory(copyingfolder, mainfolder,UIOption.AllDialogs,UICancelOption.DoNothing);
                ZipFile.CreateFromDirectory(mainfolder, mainfolder+".zip", CompressionLevel.Fastest, true);

                Console.WriteLine("copied and zipped");
                Console.WriteLine("sent");
            }









            Console.ReadKey();
        }
    }
}
