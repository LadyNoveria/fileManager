using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
namespace fileManager
{
    class Files
    {
        private List<string> files;
        public Files(string directory)
        {
            files = new List<string>();
            string[] allFiles = Directory.GetFiles(directory);
            for (int i = 0; i < allFiles.Length; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(allFiles[i]);
                if ((dir.Attributes & FileAttributes.Hidden) == 0) 
                files.Add(allFiles[i]);
            }
        }
        public void Display()
        {
            foreach (var file in files)
            {
                Console.WriteLine($"\t{file}");
            }
        }
    }
}