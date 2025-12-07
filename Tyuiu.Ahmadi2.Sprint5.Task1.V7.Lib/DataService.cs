using System;

namespace Tyuiu.Ahmadi2.Sprint5.Task1.V7.Lib
{
    public class DataService
    {
        public double[,] GetMatrix(double startValue, double stopValue)
        {
            int size = (int)Math.Ceiling((stopValue - startValue)) + 1;
            double[,] result = new double[size, 2];

            for (int i = 0; i < size; i++)
            {
                double x = startValue + i;
                double y;

                // Проверка деления на ноль
                if (Math.Abs(x + 1.2) < 0.0001) // Проверка на ноль с учетом погрешности
                {
                    y = 0;
                }
                else
                {
                    y = Math.Sin(x) / (x + 1.2) - Math.Sin(x) * 2 - 2 * x;
                    y = Math.Round(y, 2);
                }

                result[i, 0] = x;
                result[i, 1] = y;
            }

            return result;
        }

        public string SaveToFileTextData(double startValue, double stopValue)
        {
            string path = System.IO.Path.GetTempFileName();

            double[,] matrix = GetMatrix(startValue, stopValue);

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path))
            {
                writer.WriteLine("Табулирование функции F(x) = sin(x)/(x+1.2) - sin(x)*2 - 2*x");
                writer.WriteLine($"Диапазон: [{startValue}; {stopValue}]");
                writer.WriteLine("Шаг: 1");
                writer.WriteLine();
                writer.WriteLine("x\t\tF(x)");
                writer.WriteLine("---------------------");

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    writer.WriteLine($"{matrix[i, 0]}\t\t{matrix[i, 1]}");
                }
            }

            return path;
        }
    }
}