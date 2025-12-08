using System;
using System.IO;
using System.Text.RegularExpressions;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Ahmadi2.Sprint5.Task5.V3.Lib
{
    public class DataService :ISprint5Task5V3
    {
        public double CalculateFromDataFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Файл не найден: {path}");
            }

            string content = File.ReadAllText(path);
            double sum = 0;

            // Regex для поиска всех целых и вещественных чисел
            MatchCollection matches = Regex.Matches(content, @"[-+]?\d*\.?\d+");

            foreach (Match match in matches)
            {
                if (double.TryParse(match.Value.Replace('.', ','), out double number))
                {
                    // Если число целое, добавляем как есть
                    // Если вещественное, округляем до 3 знаков
                    if (Math.Abs(number - Math.Round(number)) < 0.0000001)
                    {
                        sum += number;
                    }
                    else
                    {
                        sum += Math.Round(number, 3);
                    }
                }
            }

            // Округляем итоговую сумму до 3 знаков
            return Math.Round(sum, 3);
        }

        public double LoadFromDataFile(string path)
        {
            throw new NotImplementedException();
        }
    }
}