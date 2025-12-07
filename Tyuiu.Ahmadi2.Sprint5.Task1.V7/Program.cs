using System;
using Tyuiu.Ahmadi2.Sprint5.Task1.V7.Lib;

namespace Tyuiu.Ahmadi2.Sprint5.Task1.V7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Спринт #5 | Выполнил: Ахмади | СМАРТб-23-1";
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Спринт #5                                                               *");
            Console.WriteLine("* Тема: Класс File. Запись набора данных в текстовый файл                *");
            Console.WriteLine("* Задание #1                                                              *");
            Console.WriteLine("* Вариант #7                                                              *");
            Console.WriteLine("* Выполнил: Ахмади | СМАРТб-23-1                                         *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* УСЛОВИЕ:                                                                *");
            Console.WriteLine("* Дана функция: F(x) = sin(x)/(x+1.2) - sin(x)*2 - 2*x                    *");
            Console.WriteLine("* Произвести табулирование f(x) на диапазоне [-5; 5] с шагом 1.          *");
            Console.WriteLine("* При делении на ноль вернуть 0. Сохранить в файл и вывести в таблицу.   *");
            Console.WriteLine("*                                                                         *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                        *");
            Console.WriteLine("***************************************************************************");

            DataService ds = new DataService();

            double startValue = -5;
            double stopValue = 5;

            Console.WriteLine($"Старт шага = {startValue}");
            Console.WriteLine($"Конец шага = {stopValue}");

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                              *");
            Console.WriteLine("***************************************************************************");

            // Получаем матрицу значений
            double[,] matrix = ds.GetMatrix(startValue, stopValue);

            // Выводим таблицу в консоль
            Console.WriteLine("Табулирование функции F(x) = sin(x)/(x+1.2) - sin(x)*2 - 2*x");
            Console.WriteLine($"Диапазон: [{startValue}; {stopValue}]");
            Console.WriteLine("Шаг: 1");
            Console.WriteLine();
            Console.WriteLine("x\t\tF(x)");
            Console.WriteLine("---------------------");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine($"{matrix[i, 0]}\t\t{matrix[i, 1]}");
            }

            // Сохраняем в файл
            string path = ds.SaveToFileTextData(startValue, stopValue);

            Console.WriteLine("***************************************************************************");
            Console.WriteLine($"* Данные сохранены в файл: {path} *");
            Console.WriteLine("***************************************************************************");

            // Показываем содержимое файла
            Console.WriteLine("\nСодержимое файла:");
            Console.WriteLine("-----------------");
            Console.WriteLine(System.IO.File.ReadAllText(path));

            Console.ReadKey();
        }
    }
}