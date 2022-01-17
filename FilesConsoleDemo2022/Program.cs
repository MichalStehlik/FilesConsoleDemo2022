using System;
using System.IO;

namespace FilesConsoleDemo2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // drives
            string[] drives = Directory.GetLogicalDrives();
            foreach (string d in drives)
            {
                Console.WriteLine(d);
            }
            // directories
            Console.WriteLine(Directory.GetCurrentDirectory()); // aktuální adresář
            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Console.WriteLine(docPath);
            Console.WriteLine(Directory.GetDirectoryRoot(docPath));
            // list
            string[] dirList = Directory.GetDirectories(docPath);
            foreach (string dir in dirList)
            {
                Console.WriteLine(dir);
            }
            Console.WriteLine();
            string[] fileList = Directory.GetFiles(docPath);
            foreach (string file in fileList)
            {
                Console.WriteLine(file);
            }
            Console.WriteLine();
            string[] dirList2 = Directory.GetDirectories(docPath, "My*", SearchOption.TopDirectoryOnly);
            foreach (string dir in dirList2)
            {
                Console.WriteLine(dir);
            }
            Console.WriteLine();
            Console.WriteLine("Create:" + Directory.GetCreationTime(docPath));
            Console.WriteLine("Access:" + Directory.GetLastAccessTime(docPath));
            Console.WriteLine("Write: " + Directory.GetLastWriteTime(docPath));
            Console.WriteLine("");
            long size = 0;
            var dirInfo = new DirectoryInfo(docPath);
            foreach (FileInfo fi in dirInfo.GetFiles("*", SearchOption.AllDirectories))
            {
                size += fi.Length;
            }
            Console.WriteLine(size);
            string newDir = Path.Combine(docPath, "Special", "Documents", "School");
            Console.WriteLine(newDir);
            if (Directory.Exists(newDir))
            {
                Console.WriteLine("It exists");
                // Directory.Delete(newDir);
            }
            else
            {
                Console.WriteLine("It is not here.");
                try
                {
                    DirectoryInfo di = Directory.CreateDirectory(newDir);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            string newFile = Path.Combine(newDir,"data.txt");
            StreamWriter sw;
            if (File.Exists(newFile))
            {
                Console.WriteLine("There is such file.");
                using (sw = File.AppendText(newFile))
                {
                    sw.WriteLine("Adding a new line.");
                }
            }
            else
            {
                Console.WriteLine("Ooops");
                using (sw = File.CreateText(newFile))
                {
                    sw.WriteLine("This is new file.");
                }
            }
            using (StreamReader sr = File.OpenText(newFile))
            {
                string s;
                while ((s = sr.ReadLine()) != null) {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
