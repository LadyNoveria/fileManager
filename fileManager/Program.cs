using System;
using System.IO;
using System.Collections.Generic;
namespace fileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Требуется создать консольный файловый менеджер начального уровня, который покрывает минимальный набор 
             * функционала по работе с файлами.
             * Просмотр файловой структуры
            - Поддержка копирование файлов, каталогов
            - Поддержка удаление файлов, каталогов
            - Получение информации о размерах, системных атрибутов файла, каталога
            - Вывод файловой структуры должен быть постраничным
            - В конфигурационном файле должна быть настройка вывода количества элементов на страницу
            - При выходе должно сохраняться, последнее состояние
            - Должны быть комментарии в коде
            - Должна быть документация к проекту в формате md
            - Приложение должно обрабатывать непредвиденные ситуации (не падать)
            - При успешном выполнение предыдущих пунктов – реализовать сохранение ошибки в текстовом файле в каталоге 
                errors/random_name_exception.txt
            - При успешном выполнение предыдущих пунктов – реализовать движение по истории команд (стрелочки вверх, вниз)
            - Команды должны быть консольного типа, как, например, консоль в Unix или Windows. Соответственно требуется 
                создать парсер команд, который по минимуму использует стандартные методы по строкам.
             */

            //если десериализация пустая:
            List<string> drivesName = new List<string>();
            //получаем список дисков
            var drives = DriveInfo.GetDrives();

            for (int i = 0; i < drives.Length; i++)
            {
                drivesName.Add(drives[i].RootDirectory.Name);
            }
            //Console.WriteLine("подключенные диски");
            //foreach (var name in drivesName)
            //{
            //    Console.WriteLine(name);
            //}
            //получаем список каталогов для каждого диска
            int index = 0;
            List<string> listOfDir = new List<string>();
            listOfDir = WalkTree(listOfDir, drivesName, index);
            string currentDisk = drivesName[0];
            Display(drivesName, listOfDir, currentDisk);
            currentDisk = drivesName[1];
            Display(drivesName, listOfDir, currentDisk);
            currentDisk = drivesName[2];
            Display(drivesName, listOfDir, currentDisk);
        }

        private static void Display(List<string> drivesName, List<string> listOfDir, string currentDisk)
        {
            Console.Clear();
            foreach (var disk in drivesName)
            {
                Console.WriteLine(disk);
                if (disk == currentDisk)
                {
                    foreach (var dir in listOfDir)
                    {
                        if (dir.Contains(disk))
                        {
                            DirectoryInfo checkDir = new DirectoryInfo(dir);
                            if ((checkDir.Attributes & FileAttributes.Hidden) == 0)
                                Console.WriteLine($"\t {dir}");
                        }
                    }
                }
            }
        }

        public static List<string> WalkTree(List<string> dir, List<string> paths, int index)
        {
            string currentDir = paths[index];
            try
            {
                string[] allDirectories = Directory.GetDirectories(currentDir);
                for (int i = 0; i < allDirectories.Length; i++)
                {
                    dir.Add(allDirectories[i]);
                }
            }
            catch
            {
                dir.Add("Access denied");
            }

            if (index == paths.Count - 1)
                return dir;
            else
                return WalkTree(dir, paths, index + 1);
        }
    }
}
