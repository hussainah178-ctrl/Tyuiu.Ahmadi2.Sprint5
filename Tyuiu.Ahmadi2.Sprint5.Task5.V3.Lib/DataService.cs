using System;
using System.IO;
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
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Trim();
                        if (!string.IsNullOrEmpty(line))
                        {
                            line = line.Replace('.', ',');

                            if (double.TryParse(line, out double number))  
                            {
                                if (number == (int)number)
                                {
                                    sum += number;
                                }
                                else
                                {
                                    sum += Math.Round(number, 3);
                                }
                            }
                        }
                    }
                }

                return Math.Round(sum, 3);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading file: {ex.Message}");
            }
        }
    }
}