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

            // خواندن تمام خطوط فایل
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                if (string.IsNullOrEmpty(trimmedLine))
                    continue;

                // امتحان کردن انواع فرمت‌های عددی
                if (double.TryParse(trimmedLine,
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out double number))
                {
                    // بررسی آیا عدد صحیح است (بدون اعشار)
                    if (Math.Abs(number - Math.Truncate(number)) < 0.0000001)
                    {
                        sum += number;
                    }
                }
            }

            return sum;
        }
    }
}