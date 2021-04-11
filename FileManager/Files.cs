using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
namespace fileManager
{
    class Files
    {
        private List<string> files;
        public Files(string path)
        {
            files = new List<string>();
            string[] allFiles = Directory.GetFiles(path);
            for (int i = 0; i < allFiles.Length; i++)
            {
                files.Add(allFiles[i]);
            }
        }
        //public List<string> GetFiles()
        //{
        //    return files;
        //}
        public void Display(int mapWidth)
        {
            int y = 0;
            foreach (var file in files)
            {
                int x = (mapWidth / 3) * 2;
                Console.SetCursorPosition(x, y);
                Console.WriteLine($"{file}");
                y++;
            }
        }
    }
}