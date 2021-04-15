using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace fileManager
{
    class Tree
    {
        private string currentDrive;
        private string root;
        List<string> allDirectories;
        Directories currectDirectories;
        Directories rootDirectories;
        Files allFiles;

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
            Drives drives = new Drives();
            currentDrive = drives.GetCurrentDrive();
            currectDirectories = new Directories(currentDrive);
            root = currectDirectories.GetRoot();
            rootDirectories = new Directories(root);
            
            allFiles = new Files(root);
        }
        public void Display()
        {
            Console.Clear();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{root}");
            Console.ForegroundColor = ConsoleColor.White;
            
            rootDirectories.Display(root, 0);
            allFiles.Display();
            currectDirectories.Display();
        }

        internal void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.DownArrow)
            {

            }
        }
    }
}
