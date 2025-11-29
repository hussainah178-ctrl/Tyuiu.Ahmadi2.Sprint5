using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Ahmadi2.Sprint5.Task4.V25.Lib
{
    public class DataService : ISprint5Task4V25
    {
        public double LoadFromDataFile(string path)
        {
            // Read the value from file
            string strX = File.ReadAllText(path);

            // Convert to double (handle culture-specific formatting)
            double x = Convert.ToDouble(strX);

            // Calculate the formula: y = (x^4 + cos(x)) * sin(x)
            double y = (Math.Pow(x, 4) + Math.Cos(x)) * Math.Sin(x);

            // Round to 3 decimal places
            return Math.Round(y, 3);
        }
    }
}