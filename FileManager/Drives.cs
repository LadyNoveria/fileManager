using System;
using System.Collections.Generic;
using System.IO;
namespace fileManager
{
    internal class Drives
    {
        private List<string> drivesName; //список дисков
        public string currentDrive;

        public Drives()
        {
            drivesName = new List<string>();
            GetDrives();
            currentDrive = drivesName[1];
        }
        public string GetCurrentDrive()
        {
            return currentDrive;
        }
        //Получение доступных дисков
        private void GetDrives()
        {
            var drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                if (drives[i].IsReady)
                {
                    drivesName.Add(drives[i].RootDirectory.Name);
                }
            }
        }
    }
}