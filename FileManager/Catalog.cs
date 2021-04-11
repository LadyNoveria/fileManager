using System;
using System.Collections.Generic;
using System.IO;
namespace fileManager
{
    internal class Catalog
    {
        public List<string> drivesName = new List<string>();
        List<string> listOfDir = new List<string>();
        /*при вызове пустого конструктора класса Catalog получаем список доступных 
         дисков и заполняем список каталогов и файлов директориями и файлами, 
        содержащихся на этих дисках*/
        public Catalog()
        {
            //получаем список доступных дисков на устройстве
            GetDrives();
            int index = 0;
            //получаем список директорий и файлов для дисков
            WalkTree(listOfDir, drivesName, index);
        }
        private List<string> WalkTree(List<string> dir, List<string> paths, int index)
        {
            string currentDir = paths[index];
            try
            {
                string[] allDirectories = Directory.GetDirectories(currentDir);
                for (int i = 0; i < allDirectories.Length; i++)
                {
                    dir.Add(allDirectories[i]);
                }
                string[] allFiles = Directory.GetFiles(currentDir);
                for (int i = 0; i < allFiles.Length; i++)
                {
                    dir.Add(allFiles[i]);
                }
            }
            catch
            {
                dir.Add("Access denied");
            }

            if (index == paths.Count - 1)
                return dir;
            else
                return WalkTree(dir, paths, index + 1);
        }
        //Получение доступных дисков
        private void GetDrives()
        {
            var drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                if (drives[i].IsReady)
                {
                    drivesName.Add(drives[i].RootDirectory.Name);
                }
            }
        }
        //Вывод на консоль доступных директорий и файлов. 
        //Метод без параметров выводит по умолчанию дерево для первого в списке диска 
        internal void Display()
        {
            Console.Clear();
            string currentDisk = drivesName[0];
            foreach (var disk in drivesName)
            {
                Console.WriteLine(disk);
                if (disk == currentDisk)
                {
                    foreach (var dir in listOfDir)
                    {
                        if (dir.Contains(disk))
                        {
                            DirectoryInfo checkDir = new DirectoryInfo(dir);
                            if ((checkDir.Attributes & FileAttributes.Hidden) == 0)
                                Console.WriteLine($"\t {dir}");
                        }
                    }
                }
            }
        }
        //Метод принимает на вход строку с путем к директории, которую нужно вывести
        public void Display(string path)
        {

        }
    }
}