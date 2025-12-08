using System;
using System.IO;
using Tyuiu.Ahmadi2.Sprint5.Task7.V28.Lib;

namespace Tyuiu.Ahmadi2.Sprint5.Task7.V28
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();

            Console.Title = "Спринт #5 | Выполнил: Ахмади Х.Х. | СМАРТб-23-1";
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Обработка текстовых файлов                                        *");
            Console.WriteLine("* Задание #7                                                              *");
            Console.WriteLine("* Вариант #28                                                             *");
            Console.WriteLine("* Выполнил: Ахмади Х.Х. | СМАРТб-23-1                                     *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Заменить все пробелы, идущие подряд более одного, на один пробел.       *");
            Console.WriteLine("* Результат сохранить в файл OutPutDataFileTask7V28.txt.                  *");
            Console.WriteLine("*                                                                         *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            string path = @"C:\DataSprint5\InPutDataFileTask7V28.txt";
            Console.WriteLine("Данные находятся в файле: " + path);

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            string outputPath = ds.LoadDataAndSave(path);
            Console.WriteLine("Результат сохранен в файле: " + outputPath);

            // نمایش содержимое результата
            if (File.Exists(outputPath))
            {
                string result = File.ReadAllText(outputPath);
                Console.WriteLine("Содержимое файла результата:");
                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}