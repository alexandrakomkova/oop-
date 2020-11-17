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
           // StreamWriter sw = new StreamWriter(@"D:\Саша Комкова\oop\oop_lab13\kavlog.txt", true);
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

    public static class KAVFileManager
    {
        public static void FileManager()
        {
           // StreamWriter sw = new StreamWriter(@"D:\Саша Комкова\oop\oop_lab13\kavlog.txt", true);
            string dirName = @"D:\Саша Комкова\oop\oop_lab13";
            string KAVInspect = @"D:\Саша Комкова\oop\oop_lab13\KAVInspect";
            string KAVFiles = @"D:\Саша Комкова\oop\oop_lab13\KAVFiles";
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
                DirectoryInfo dirNew = new DirectoryInfo(KAVInspect);
                string KAVdirinfo = @"D:\Саша Комкова\oop\oop_lab13\KAVInspect\KAVdirinfo.txt";
                string KAVdirinfo_new = @"D:\KAVdirinfo.txt";
                FileInfo fileInf = new FileInfo(KAVdirinfo);
                
                if (!dirNew.Exists)
                {
                    
                    dirNew.Create();
                    Console.WriteLine("директория создана");
                    fileInf.Create();
                    Console.WriteLine("файл создана");
                }
                if (fileInf.Exists)
                {
                    File.Copy(KAVdirinfo, KAVdirinfo_new, true);
                    fileInf.Delete();
                    dirNew.Delete();
                }
            }
            string KAVcopy_from = @"C:\Users\Саша Комкова\Desktop\UNI\оси\*txt";
            
            DirectoryInfo dirFiles = new DirectoryInfo(KAVFiles);
            if (!dirFiles.Exists)
            {

                dirFiles.Create();
                Console.WriteLine("директория создана");
                File.Copy(KAVcopy_from, KAVFiles, true);
                Console.WriteLine("файлы скопированы");
            }
            if (dirFiles.Exists && Directory.Exists(KAVInspect) == false)
            {
                dirFiles.MoveTo(KAVInspect);
            }
        }
        

    }
    class Program
    {
        static void Main(string[] args)
        {
           // KAVDriveInfo.DriveInfoWrite();
           // KAVFileInfo.FileInfoWrite();
           // KAVDirInfo.DirInfoWrite();
            KAVFileManager.FileManager();


            Console.ReadKey();
        }

    }
}
