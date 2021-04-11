using System;
using System.Collections.Generic;
using System.IO;

namespace fileManager
{
    class Directories
    {
        List<string> directories;

        public Directories(string path)
        {
            directories = new List<string>();
            string[] allDirectories = Directory.GetDirectories(path);
            for (int i = 0; i < allDirectories.Length; i++)
            {
                directories.Add(allDirectories[i]);
            }
        }
        public void Display(int mapWidth) {
            int y = 0;
            foreach (var file in directories)
            {
                //int x = mapWidth / 3;
                Console.SetCursorPosition(10, y);
                Console.WriteLine($"{file}");
                y++;
            }
        }
    }
}
