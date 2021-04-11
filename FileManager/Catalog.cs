using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace fileManager
{
    internal class Catalog
    {
        public List<string> drivesName = new List<string>(); //список дисков
        List<string> listOfDir = new List<string>(); //список директорий
        List<string> listOfFiles = new List<string>(); //список файлов
        string currentDirectory = "";
        /*при вызове пустого конструктора класса Catalog получаем список доступных 
         дисков и заполняем список каталогов и файлов директориями и файлами, 
        содержащихся на этих дисках*/
        public Catalog()
        {
            //получаем список доступных дисков на устройстве
            GetDrives();
            int index = 0;
            //получаем список директорий и файлов для дисков
            (listOfDir, listOfFiles) = WalkTree(listOfDir, listOfFiles, drivesName, index);
            currentDirectory = drivesName[1];
        }
        public Catalog(string path)
        {
            //если на диске есть файл с именем path - десириализируем и получаем путь до последнего посещенного каталога
            if (File.Exists(path))
            {
                currentDirectory = Deserialize(path);
            }
            //если файла на диске нет - переданный путь становится текущим
            else
                currentDirectory = path;
        }
        //Десериализация файла json
        private string Deserialize(string path)
        {
            string json = File.ReadAllText(path);
            string currentPath = JsonSerializer.Deserialize<string>(json);
            return currentPath;
        }
        public void Save()
        {

        }
        private (List<string>, List<string>) WalkTree(List<string> dir, List<string> files, List<string> paths, int index)
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
                    files.Add(allFiles[i]);
                }
            }
            catch
            {
                dir.Add("Access denied");
            }

            if (index == paths.Count - 1)
                return (dir, files);
            else
                return WalkTree(dir, files, paths, index + 1);
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
        internal void Display()
        {
            Console.Clear();
            foreach (var disk in drivesName)
            {
                Console.WriteLine(disk);
                if (disk == currentDirectory)
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
                    foreach (var file in listOfFiles)
                    {
                        if (file.Contains(disk))
                        {
                            DirectoryInfo checkDir = new DirectoryInfo(file);
                            if ((checkDir.Attributes & FileAttributes.Hidden) == 0)
                                Console.WriteLine($"\t {file}");
                        }       
                    }
                }
            }
        }
    }
}