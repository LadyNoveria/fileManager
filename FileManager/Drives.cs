using System;
using System.Collections.Generic;
using System.IO;
namespace fileManager
{
    internal class Drives
    {
        private NodeLinkedList StartDrive; //список дисков

        public Drives()
        {
            GetDrives();
        }
        public NodeLinkedList GetDriveNames()
        {
            return StartDrive;
        } 
        //Получение доступных дисков
        private void GetDrives()
        {
            var drives = DriveInfo.GetDrives();
            NodeLinkedList node = new NodeLinkedList();
            for (int i = 0; i < drives.Length; i++)
            {
                node.AddNode(drives[i].RootDirectory.Name);
            }
            StartDrive = node;
        }
        public NodeLinkedList GetCurrentList(Directories directories)
        {

        }
    }
}