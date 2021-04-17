using System;
using System.Collections.Generic;
using System.IO;

namespace fileManager
{
    class Directories
    {
        private NodeLinkedList StartDirectory;
        //private string currentDirectory;
        private NodeLinkedList subDirectories;
        public Directories(NodeLinkedList drive)
        {
            GetDirectories(drive);
        }

        private void GetDirectories(NodeLinkedList drive)
        {
            var path = drive.StartNode.Value;
            var allDirectories = Directory.GetDirectories(path);
            var node = new NodeLinkedList();
            for (int i = 0; i < allDirectories.Length; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(allDirectories[i]);
                if ((dir.Attributes & FileAttributes.Hidden) == 0)
                    node.AddNode(allDirectories[i]);
            }
            StartDirectory = node;
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
            var root = Directory.GetDirectories(path);
            var node = new NodeLinkedList();
            foreach (var dir in root)
            {
                DirectoryInfo info = new DirectoryInfo(dir);
                if ((info.Attributes & FileAttributes.Hidden) == 0)
                {
                    node.AddNode(dir);
                    GetSubDirs(dir.ToString(), index + 1);
                }
            }
            subDirectories = node;
        }

        public NodeLinkedList GetDirectoryNames()
        {
            return StartDirectory;
        }
        public NodeLinkedList GetSubDirectories(string path)
        {
            GetSubDirs(path, 0);
            return subDirectories;
        }
    }
}
