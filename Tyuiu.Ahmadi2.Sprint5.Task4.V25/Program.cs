using System;
using System.IO;
using Tyuiu.Ahmadi2.Sprint5.Task4.V25.Lib;

namespace Tyuiu.Ahmadi2.Sprint5.Task4.V25
{
    class Program
    {
        static void Main(string[] args)
        {
            DataService ds = new DataService();

            string tempPath = Path.GetTempPath();
            string path = Path.Combine(tempPath, "InPutDataFileTask4V0.txt");

            if (!File.Exists(path))
            {
                File.WriteAllText(path, "2.5");
            }

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