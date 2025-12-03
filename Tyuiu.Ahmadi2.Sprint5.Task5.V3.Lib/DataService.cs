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
            double sum = 0;

            try
            {
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    string trimmedLine = line.Trim();

                    if (string.IsNullOrEmpty(trimmedLine))
                        continue;

                    if (double.TryParse(trimmedLine, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                    {
                        // Check if it's an integer
                        if (Math.Abs(number - Math.Round(number)) < 0.000001)
                        {
                            sum += number;
                        }
                        else
                        {
                            // For real numbers, round to 3 decimal places before adding
                            sum += Math.Round(number, 3);
                        }
                    }
                }

                return sum;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading file: {ex.Message}");
            }
        }
    }
}