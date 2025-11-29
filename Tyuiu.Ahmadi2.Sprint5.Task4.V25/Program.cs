using System;
using Tyuiu.Ahmadi2.Sprint5.Task4.V25.Lib;

namespace Tyuiu.Ahmadi2.Sprint5.Task4.V25
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();

            string path = @"C:\DataSprint5\InPutDataFileTask4V0.txt";

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine($"* Файл: {path}");
            Console.WriteLine("* Формула: y = (x^4 + cos(x)) * sin(x)");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                             *");
            Console.WriteLine("***************************************************************************");

            try
            {
                double result = ds.LoadFromDataFile(path);
                Console.WriteLine($"* y = {result}");
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