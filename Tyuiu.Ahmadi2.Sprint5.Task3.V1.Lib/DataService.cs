using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Ahmadi2.Sprint5.Task3.V1.Lib
{
    public class DataService :ISprint5Task3V1
    {
        public double Calculate(int x)
        {
            if (x == 0)
                throw new DivideByZeroException("Деление на ноль невозможно");

            double numerator = Math.Pow(x, 3);
            double denominator = 2 * Math.Pow(x, 2);

            double result = numerator / denominator;
            return Math.Round(result, 3);
        }

        public string SaveToFile(int x)
        {
            double result = Calculate(x);
            string tempPath = Path.GetTempPath();
            string filePath = Path.Combine(tempPath, "OutPutFileTask3.bin");

            // Сохранение в бинарный файл
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                writer.Write(result);
            }

            return filePath;
        }

        public double LoadFromFile(string filePath)
        {
            double result;
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                result = reader.ReadDouble();
            }
            return result;
        }

        public double LoadFromDataFile(string path)
        {
            throw new NotImplementedException();
        }

        public string SaveToFileTextData(int x)
        {
            throw new NotImplementedException();
        }
    }
}