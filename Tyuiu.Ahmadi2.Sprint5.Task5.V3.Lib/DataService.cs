using System;
using System.IO;
using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Ahmadi2.Sprint5.Task5.V3.Lib
{
    public class DataService : ISprint5Task5V3
    {
        public double LoadFromDataFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"File not found: {path}");

            double sum = 0;

            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (string.IsNullOrEmpty(line))
                        continue;

                    // اگر خط فقط شامل عدد است
                    if (double.TryParse(line, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                    {
                        // بررسی آیا عدد صحیح است (بدون جزء اعشاری)
                        if (Math.Abs(value % 1) <= double.Epsilon * 100)
                        {
                            sum += (int)value; // یا sum += value
                        }
                    }
                }
            }

            return sum;
        }
    }
}