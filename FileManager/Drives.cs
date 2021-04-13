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
            currentDrive = drivesName[0];
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
        //public void Display()
        //{
        //    foreach (var drive in drivesName)
        //    {
        //        if (drive == currentDrive)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine(drive);
        //            Console.ForegroundColor = ConsoleColor.White;
        //        }
        //        else
        //            Console.WriteLine($"{drive}");
        //    }
        //}
    }
}