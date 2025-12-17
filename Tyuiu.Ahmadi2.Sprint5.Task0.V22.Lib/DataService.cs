using System;
using System.Globalization;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Ahmadi2.Sprint5.Task0.V22.Lib
{
    public class DataService : ISprint5Task0V22
    {
        // вычисление y(x) = (1 - x)^2 / (-3x)
        public double Calculate(int x)
        {
            double numerator = Math.Pow(1 - x, 2);
            double denominator = -3 * x;

            if (denominator == 0)
                throw new DivideByZeroException("Деление на ноль невозможно при x = 0");

            double result = numerator / denominator;

            // округление до трёх знаков
            return Math.Round(result, 3);
        }

        // сохранение результата в файл OutPutFileTask0.txt
        public string SaveToFile(int x)
        {
            double result = Calculate(x);

            string tempPath = Path.GetTempPath();
            string filePath = Path.Combine(tempPath, "OutPutFileTask0.txt");

            // строго три знака после запятой и точка как разделитель
            // затем меняем точку на запятую, чтобы получить "-0,444"
            string formattedResult = result
                .ToString("F3", CultureInfo.InvariantCulture)
                .Replace('.', ',');

            File.WriteAllText(filePath, formattedResult);

            return filePath;
        }

        // если интерфейс требует, можно продублировать логику здесь
        public string SaveToFileTextData(int x)
        {
            return SaveToFile(x);
        }
    }
}
