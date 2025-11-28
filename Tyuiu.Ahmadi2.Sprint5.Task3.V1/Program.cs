using System;
using System.IO;
using Tyuiu.Ahmadi2.Sprint5.Task3.V1.Lib;

namespace Tyuiu.Ahmadi2.Sprint5.Task3.V1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Спринт #5 | Выполнил: Ахмади | АССОиУб-25-1";
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Потоковый метод записи данных в бинарный файл                    *");
            Console.WriteLine("* Задание #3                                                              *");
            Console.WriteLine("* Вариант #1                                                              *");
            Console.WriteLine("* Выполнил: Ахмади |  АССОиУб-25-1                                        *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дано выражение вычислить его значение при x = 3, результат сохранить   *");
            Console.WriteLine("* в бинарный файл OutPutFileTask3.bin и вывести на консоль.              *");
            Console.WriteLine("* Округлить до трёх знаков после запятой.                                *");
            Console.WriteLine("*                                                                         *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            int x = 3;
            Console.WriteLine($"x = {x}");

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            try
            {
                DataService ds = new DataService();

                // Вычисление результата
                double result = ds.Calculate(x);
                Console.WriteLine($"Результат вычисления: {result:F3}");

                // Сохранение в бинарный файл
                string filePath = ds.SaveToFile(x);
                Console.WriteLine($"Файл сохранен: {filePath}");

                // Чтение из бинарного файла и вывод
                double fileResult = ds.LoadFromFile(filePath);
                Console.WriteLine($"Результат из файла: {fileResult:F3}");

                // Дополнительная информация о файле
                FileInfo fileInfo = new FileInfo(filePath);
                Console.WriteLine($"Размер файла: {fileInfo.Length} байт");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}