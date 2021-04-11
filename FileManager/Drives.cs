using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
namespace fileManager
{
    internal class Drives
    {
        public List<string> drivesName; //список дисков
        string currentDrive;
        /*при вызове пустого конструктора класса Catalog получаем список доступных 
         дисков и заполняем список каталогов и файлов директориями и файлами, 
        содержащихся на этих дисках*/
        public Drives()
        {
            drivesName = new List<string>();
            GetDrives();
            currentDrive = drivesName[0];
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
        public Drives(string path)
        {
            //если на диске есть файл с именем path - десириализируем и получаем путь до последнего посещенного каталога
            if (File.Exists(path))
            {
                currentDrive = Deserialize(path);
            }
            //если файла на диске нет - переданный путь становится текущим
            else
                currentDrive = path;
        }
        //Десериализация файла json
        private string Deserialize(string path)
        {
            string json = File.ReadAllText(path);
            string currentPath = JsonSerializer.Deserialize<string>(json);
            return currentPath;
        }

        //Вывод на консоль доступных директорий и файлов. 
        public void Display(int mapWidth, int mapHeight)
        {
            Console.Clear();
            foreach (var drive in drivesName)
            {
                if (drive == currentDrive)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(drive);
                    Console.ForegroundColor = ConsoleColor.White;
                    Directories directories = new Directories(drive);
                    Files files = new Files(drive);
                    directories.Display(mapWidth);
                    files.Display(mapWidth);
                }
                else
                    Console.WriteLine(drive);
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}