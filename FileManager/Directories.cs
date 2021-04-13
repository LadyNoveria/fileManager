using System;
using System.Collections.Generic;
using System.IO;

namespace fileManager
{
    class Directories
    {
        private List<string> directories;
        private string currentDirectory;

        public Directories(string drive, string directory)
        {
            directories = new List<string>();
            string[] allDirectories = Directory.GetDirectories(drive);
            for (int i = 0; i < allDirectories.Length; i++)
            {
                directories.Add(allDirectories[i]);
            }
            if (directory != null)
            {
                currentDirectory = directory;
            }
        }
        public void Display() {
            int y = 0;
            foreach (var dir in directories)
            {
                Console.SetCursorPosition(10, y);
                if (dir == currentDirectory)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(dir);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine($"{dir}");
                y++;
            }
        }
    }
}
