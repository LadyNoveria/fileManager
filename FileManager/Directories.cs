using System;
using System.Collections.Generic;
using System.IO;

namespace fileManager
{
    class Directories
    {
        private List<string> directories;
        private string currentDirectory;
        public Directories(string drive)
        {
            directories = new List<string>();
            string[] allDirectories = Directory.GetDirectories(drive);
            for (int i = 0; i < allDirectories.Length; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(allDirectories[i]);
                if ((dir.Attributes & FileAttributes.Hidden) == 0)
                    directories.Add(allDirectories[i]);
            }
            if (directories.Count != 0) 
                currentDirectory = directories[0];
        }
        public Directories(string root, int index)
        {
            GetRootSubDir(root, index);
        }
        public string GetRoot()
        {
            return currentDirectory;
        }
        public void Display()
        {
            foreach (var dir in directories)
            {
                if(dir != currentDirectory)
                    Console.WriteLine($"{dir}");
            }
        }
        public void GetRootSubDir(string root, int index)
        {
            DirectoryInfo rootDir = new DirectoryInfo(root);
            DirectoryInfo[] rootroot = rootDir.GetDirectories();
            string indent = "\t";
            for (int i = 0; i < index; i++)
            {
                indent += "\t";
            }
            foreach (var dir in rootroot)
            {
                directories.Add($"{indent}{dir}");
                GetRootSubDir(dir.ToString(), index + 1);
            }
        } 
    }
}
