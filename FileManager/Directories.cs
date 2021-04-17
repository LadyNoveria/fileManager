using System;
using System.Collections.Generic;
using System.IO;

namespace fileManager
{
    class Directories
    {
        private List<string> directories;
        private string currentDirectory;
        private List<string> subDirectories;
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
        public void GetSubDirs(string path, int index)
        {
            //string indent = "\t";
            //for (int i = 0; i < index; i++)
            //{
            //    indent += "\t";
            //}
            subDirectories = new List<string>();
            var rootroot = Directory.GetDirectories(path);
            foreach (var dir in rootroot)
            {
                DirectoryInfo info = new DirectoryInfo(dir);
                if ((info.Attributes & FileAttributes.Hidden) == 0)
                {
                    subDirectories.Add($"{dir}");
                    GetSubDirs(dir.ToString(), index + 1);
                }
            }
        }

        public List<string> GetDirectoryNames()
        {
            return directories;
        }
        public List<string> GetSubDirectories()
        {
            return;
        }
    }
}
