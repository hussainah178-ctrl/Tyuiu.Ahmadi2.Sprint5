using System;
using System.IO;
using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Ahmadi2.Sprint5.Task4.V25.Lib
{
    public class DataService : ISprint5Task4V25
    {
        public double LoadFromDataFile(string path)
        {
            try
            {
                string strX = File.ReadAllText(path).Trim();

                double x = double.Parse(strX, CultureInfo.InvariantCulture);

                double y = (Math.Pow(x, 4) + Math.Cos(x)) * Math.Sin(x);

                return Math.Round(y, 3);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading file: {ex.Message}");
            }
        }
    }
}