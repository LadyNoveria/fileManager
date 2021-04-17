using System;
using System.Collections.Generic;
using System.IO;
namespace fileManager
{
    internal class Drives
    {
        private List<string> driveNames; //список дисков
        public string currentDrive;

        public Drives()
        {
            driveNames = new List<string>();
            GetDrives();
            currentDrive = driveNames[1];
        }
        public string GetCurrentDrive()
        {
            return currentDrive;
        }
        public List<string> GetDriveNames()
        {
            return driveNames;
        } 
        //Получение доступных дисков
        private void GetDrives()
        {
            var drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                if (drives[i].IsReady)
                {
                    driveNames.Add(drives[i].RootDirectory.Name);
                }
            }
        }
    }
}