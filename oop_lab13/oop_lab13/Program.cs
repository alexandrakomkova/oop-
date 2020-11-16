using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_lab13
{
    public class KAVLog 
    {
        StreamWriter sw = new StreamWriter(@"D:\Саша Комкова\oop\oop_lab13\kavlog.txt", true);
        public void Log()
        {
        }

    }
    public static class KAVDriveInfo
    {
        public static void DriveInfoWrite() 
        {
            StreamWriter sw = new StreamWriter(@"D:\Саша Комкова\oop\oop_lab13\kavlog.txt", true);
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"название: {drive.Name}");
                Console.WriteLine($"тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"объем диска: {drive.TotalSize}");
                    Console.WriteLine($"свободное пространство: {drive.TotalFreeSpace}");
                    Console.WriteLine($"метка: {drive.VolumeLabel}");
                }
                Console.WriteLine();
            }
        }
       


    }
    public static class KAVFileInfo
    {
        public static void FileInfoWrite()
        { 
           //StreamWriter sw = new StreamWriter(@"D:\Саша Комкова\oop\oop_lab13\kavlog.txt", true);
            string path = @"D:\Саша Комкова\oop\oop_lab13\kavlog.txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                Console.WriteLine("полный путь: {0}", fileInf.DirectoryName);
                Console.WriteLine("размер: {0}", fileInf.Length);
                Console.WriteLine("расширение: {0}", fileInf.Extension);
                Console.WriteLine("имя файла: {0}", fileInf.Name);
                Console.WriteLine("время создания: {0}", fileInf.CreationTime);
                Console.WriteLine("время изменения: {0}", fileInf.LastWriteTime);

            }

        }



    }
    public static class KAVDirInfo
    {
        public static void DirInfoWrite()
        {
            StreamWriter sw = new StreamWriter(@"D:\Саша Комкова\oop\oop_lab13\kavlog.txt", true);
            string dirName = @"D:\Саша Комкова\oop";
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("подкаталоги:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("файлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                Console.WriteLine($"родительский каталог: {dirInfo.Parent}");
                Console.WriteLine($"время создания: {dirInfo.CreationTime}");

            }

        }



    }

    class Program
    {
        static void Main(string[] args)
        {
            KAVDriveInfo.DriveInfoWrite();
            KAVFileInfo.FileInfoWrite();
            KAVDirInfo.DirInfoWrite();



            Console.ReadKey();
        }

    }
}
