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

            // Regex для поиска всех чисел
            string pattern = @"[-]?\d+(?:[.,]\d+)?";
            MatchCollection matches = Regex.Matches(content, pattern);

            foreach (Match match in matches)
            {
                // Заменяем точку на запятую для правильного парсинга
                string numberStr = match.Value.Replace('.', ',');
                if (double.TryParse(numberStr, out double number))
                {
                    // Округляем до 3 знаков для всех чисел
                    sum += Math.Round(number, 3);
                }
            }

            return Math.Round(sum, 3);
        }

        public double LoadFromDataFile(string path)
        {
            throw new NotImplementedException();
        }
    }
}