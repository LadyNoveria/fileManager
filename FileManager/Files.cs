using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
namespace fileManager
{
    class Files
    {
        private List<string> files;
        private string currentFile;
        public Files(string directory, string fileName)
        {
            files = new List<string>();
            string[] allFiles = Directory.GetFiles(directory);
            for (int i = 0; i < allFiles.Length; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(allFiles[i]);
                if ((dir.Attributes & FileAttributes.Hidden) == 0) 
                files.Add(allFiles[i]);
            }
            if (fileName != null)
            {
                currentFile = fileName;
            }
        }
        public void Display()
        {
            int y = 0;
            foreach (var file in files)
            {
                Console.SetCursorPosition(35, y);
                if (file == currentFile)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(file);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                    Console.WriteLine($"{file}");
                y++;
            }
        }
    }
}