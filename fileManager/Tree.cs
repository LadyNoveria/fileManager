using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace fileManager
{
    class Tree
    {
        List<string> listOfDrives; //диски, готовые к работе
        Queue<string> listOfDirectories; //директории выбранного диска
        Queue<string> listOfSubDirectories; //поддиректории
        List<string> listOfFiles; //файлы
        string currentDirectory;

        //public Tree(string path)
        //{
        //    string[] currentPaths = Deserialize(path);
        //    currentDrive = currentPaths[0];
        //    currentDirectory = currentPaths[1];
        //    currentFile = currentPaths[2];
        //}
        ////конструктор вызывается, если на диске нет файла с сохраненными параметрами
        //public Tree()
        //{
        //    Drives drives = new Drives(currentDrive);
        //    currentDrive = drives.currentDrive;

        //}
        ////Десериализация файла json
        //private string[] Deserialize(string path)
        //{
        //    string json = File.ReadAllText(path);
        //    string[] currentPaths = JsonSerializer.Deserialize<string[]>(json);
        //    return currentPaths;
        //}


        public Tree() //десериализация пустая
        {
            //получаем список дисков
            Drives drives = new Drives();
            listOfDrives = drives.GetDriveNames();

            //директорией по-умолчанию для отображения назначаем первый диск
            currentDirectory = listOfDrives[0]; 

            //получаем список директорий
            Directories directories = new Directories(currentDirectory);
            listOfDirectories = directories.GetDirectoryNames();

            //получаем список поддиректорий 
            listOfSubDirectories = directories.GetSubDirectories();
            //получаем список файлов выбранного диска listOfDrives[0]
            Files files = new Files(currentDirectory);
            listOfFiles = files.GetFiles();

        }
        public void Display()
        {
            Console.Clear();
            //выводим выбранную по-умолчанию директорию
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{currentDirectory}");
            Console.ForegroundColor = ConsoleColor.White;

            //выводим поддиректории
            Directories directories = new Directories(currentDirectory);
            directories.Display();
            //выводим файлы
            Files files = new Files(currentDirectory);
            files.Display();
            //rootDirectories.Display(root, 0);
            //allFiles.Display();
            //currectDirectories.Display();
        }

        internal void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.DownArrow)
            {
                if (listOfSubDirectories != null)
                {
                    currentDirectory = listOfSubDirectories.Dequeue();
                    this.Display();
                }
                else
                {
                    currentDirectory = listOfDirectories.Dequeue();
                    this.Display();
                }
            }
        }
    }
}
