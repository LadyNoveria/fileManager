using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
namespace fileManager
{
    class Files
    {
        private NodeLinkedList StartFiles;
        public Files(NodeLinkedList directory)
        {
            GetListOfFiles(directory);
        }

        private void GetListOfFiles(NodeLinkedList directory)
        {
            var path = directory.StartNode.Value;
            string[] allFiles = Directory.GetFiles(path);
            var node = new NodeLinkedList();
            for (int i = 0; i < allFiles.Length; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(allFiles[i]);
                if ((dir.Attributes & FileAttributes.Hidden) == 0)
                    node.AddNode(allFiles[i]);
            }
            StartFiles = node;
        }
        public NodeLinkedList GetFiles()
        {
            return StartFiles;
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