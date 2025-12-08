using System;
using System.IO;
using Tyuiu.Ahmadi2.Sprint5.Task5.V3.Lib;

namespace Tyuiu.Ahmadi2.Sprint5.Task5.V3
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();

            Console.Title = "Спринт #5 | Выполнил: Ахмади Х.Х. | СМАРТб-23-1";
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Чтение данных из текстового файла                                 *");
            Console.WriteLine("* Задание #5                                                              *");
            Console.WriteLine("* Вариант #3                                                              *");
            Console.WriteLine("* Выполнил: Ахмади Х.Х. | СМАРТб-23-1                                     *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дан файл, в котором есть набор значений. Найти сумму всех целых чисел  *");
            Console.WriteLine("* в файле. У вещественных значений округлить до трёх знаков после запятой.*");
            Console.WriteLine("* Полученный результат вывести на консоль.                                *");
            Console.WriteLine("*                                                                         *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            try
            {
                string inputPath = @"C:\DataSprint5\InPutDataFileTask5V3.txt";

                if (!File.Exists(inputPath))
                {
                    string tempDataDir = Path.Combine(Path.GetTempPath(), "DataSprint5");
                    if (!Directory.Exists(tempDataDir))
                    {
                        Directory.CreateDirectory(tempDataDir);
                    }

                    inputPath = Path.Combine(tempDataDir, "InPutDataFileTask5V3.txt");
                    string testData = "15 25.5 30.123 45 50.789 60.456";
                    File.WriteAllText(inputPath, testData);
                    Console.WriteLine("Создан тестовый файл: " + inputPath);
                }

                Console.WriteLine("Данные находятся в файле: " + inputPath);

                Console.WriteLine("***************************************************************************");
                Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
                Console.WriteLine("***************************************************************************");

                double result = ds.CalculateFromDataFile(inputPath);
                Console.WriteLine("Сумма всех чисел (с округлением вещественных до 3 знаков) = " + result);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"ОШИБКА: {ex.Message}");
                Console.WriteLine("Убедитесь, что файл InPutDataFileTask5V3.txt существует!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ОШИБКА: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}