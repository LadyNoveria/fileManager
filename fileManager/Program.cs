﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
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

            
            string lastWay = @"path.json";
            Catalog catalog;
            //если десериализация не пустая:
            if (File.Exists(lastWay))
            {
                catalog = new Catalog(lastWay);
            }
            //если десериализация пустая:
            else
            {
                catalog = new Catalog();
            }
            catalog.Display();
            Windows windows = new Windows();
        }
    }

}
