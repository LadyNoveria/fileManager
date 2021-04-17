using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
namespace fileManager
{
    class Files
    {
        private NodeLinkedList Files;
        public Files(NodeLinkedList directory)
        {
            GetListOfFiles(directory);
        }

        private static void GetListOfFiles(NodeLinkedList directory)
        {
            var path = directory.StartNode.Value;
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
        public List<string> GetFiles()
        {
            return files;
        }
    }
}