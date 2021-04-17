using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace fileManager
{
    class Tree
    {
        NodeLinkedList Drives; //диски, готовые к работе
        NodeLinkedList Directories; //директории выбранного диска
        NodeLinkedList SubDirectories; //поддиректории
        NodeLinkedList Files; //файлы
        NodeLinkedList currentDirectory;//директория, для которой показываются фалйы и папки

        NodeLinkedList CurrentList;
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
            Drives = drives.GetDriveNames();

            
            //директорией по-умолчанию для отображения назначаем первый диск
            currentDirectory = Drives; 

            //получаем список директорий
            Directories directories = new Directories(currentDirectory);
            Directories = directories.GetDirectoryNames();
            CurrentList = drives.GetCurrentList(directories);
            //получаем список поддиректорий 
            //SubDirectories = directories.GetSubDirectories();

            //получаем список файлов выбранного диска listOfDrives[0]
            Files files = new Files(currentDirectory);
            Files = files.GetFiles();
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
        }

        internal void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.DownArrow)
            {
                if (SubDirectories != null)
                {
                    Directories directories = new Directories(currentDirectory);
                    SubDirectories = directories.GetSubDirectories();

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
