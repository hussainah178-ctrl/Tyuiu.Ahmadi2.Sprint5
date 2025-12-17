using System;
using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Ahmadi2.Sprint5.Task0.V22.Lib
{
    public class DataService : ISprint5Task0V22
    {
        public double Calculate(int x)
        {
            if (x == 0)
                throw new DivideByZeroException("Деление на ноль невозможно при x=0");

            double numerator = Math.Pow(1 - x, 2);
            double denominator = -3 * x;

            double result = numerator / denominator;
            return Math.Round(result, 3);
        }

        public string SaveToFile(int x)
        {
            double result = Calculate(x);

            string tempPath = System.IO.Path.GetTempPath();
            string filePath = System.IO.Path.Combine(tempPath, "OutPutFileTask0.txt");

            string formattedResult = result.ToString("F3", CultureInfo.GetCultureInfo("de-DE"));

            System.IO.File.WriteAllText(filePath, formattedResult);

            Console.WriteLine($"Результат: {formattedResult}");
            Console.WriteLine($"Файл сохранен: {filePath}");

            return filePath;
        }

        public string SaveToFileTextData(int x)
        {
            throw new NotImplementedException();
        }
    }
}