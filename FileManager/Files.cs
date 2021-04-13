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
                int x = (Console.BufferWidth / 3) * 2;
                Console.SetCursorPosition(x, y);
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