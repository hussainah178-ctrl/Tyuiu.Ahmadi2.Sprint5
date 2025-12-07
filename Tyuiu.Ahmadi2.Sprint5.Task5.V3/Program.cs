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

            // Use temp directory as suggested
            string tempPath = Path.GetTempPath();
            string path = Path.Combine(tempPath, "InPutDataFileTask5V3.txt");

            // Create sample file if it doesn't exist
            if (!File.Exists(path))
            {
                string[] sampleData = {
                    "10",
                    "3.14159",
                    "5",
                    "2.71828",
                    "7",
                    "1.61803"
                };
                File.WriteAllLines(path, sampleData);
            }

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine($"* Файл: {path}");
            Console.WriteLine("* Необходимо найти сумму всех целых чисел в файле.");
            Console.WriteLine("* У вещественных значений округлить до трёх знаков после запятой.");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                             *");
            Console.WriteLine("***************************************************************************");

            try
            {
                double result = ((global::tyuiu.cources.programming.interfaces.Sprint5.ISprint5Task5V3)ds).LoadFromDataFile(path);
                Console.WriteLine($"* Сумма = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"* Ошибка: {ex.Message}");
            }

            Console.WriteLine("***************************************************************************");
            Console.ReadKey();
        }
    }
}