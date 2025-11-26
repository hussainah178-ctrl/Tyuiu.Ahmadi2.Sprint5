using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Ahmadi2.Sprint5.Task2.V19.Lib
{
    public class DataService : ISprint5Task2V19
    {
        public int[,] GetMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] resultMatrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] % 2 != 0) // если нечетное
                    {
                        resultMatrix[i, j] = 0;
                    }
                    else
                    {
                        resultMatrix[i, j] = matrix[i, j];
                    }
                }
            }
            return resultMatrix;
        }

        public string SaveToFile(int[,] matrix)
        {
            string tempPath = Path.GetTempPath();
            string filePath = Path.Combine(tempPath, "OutPutFileTask2.csv");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        writer.Write(matrix[i, j]);
                        if (j < cols - 1)
                            writer.Write(";");
                    }
                    if (i < rows - 1)
                        writer.WriteLine();
                }
            }

            return filePath;
        }

        public string MatrixToString(int[,] matrix)
        {
            string result = "";
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result += matrix[i, j];
                    if (j < cols - 1)
                        result += ";";
                }
                if (i < rows - 1)
                    result += "\\n";
            }

            return result;
        }

        public string SaveToFileTextData(int[,] matrix)
        {
            throw new NotImplementedException();
        }
    }
}