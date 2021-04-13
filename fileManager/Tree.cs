﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace fileManager
{
    class Tree
    {
        private string currentDrive;
        private string root;
        //private string currentDirectory;
        //private string currentFile;
        ////конструктор вызывается, если на диске есть файл с сохраненными параметрами
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

        ////Вывод на консоль доступных директорий и файлов. 
        //public void Display()
        //{
        //    Console.Clear();
        //    Drives drives = new Drives(currentDrive);
        //    Directories directories = new Directories(currentDrive, currentDirectory);
        //    Files files = new Files(currentDrive, currentFile);
        //    drives.Display();
        //    directories.Display();
        //    files.Display();
        //    Console.SetCursorPosition(0, 0);
        //}


        public Tree() //десериализация пустая
        {
            Drives drives = new Drives();
            currentDrive = drives.GetCurrentDrive();
        }
        public void Display()
        {
            Console.Clear();
            Directories currectDirectories = new Directories(currentDrive);
            root = currectDirectories.GetRoot();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"| {root}");
            Console.ForegroundColor = ConsoleColor.White;
            Directories rootDirectories = new Directories(root);
            rootDirectories.Display("\t");
            Files files = new Files(root);
            files.Display();
            currectDirectories.Display();
        }
    }
}
