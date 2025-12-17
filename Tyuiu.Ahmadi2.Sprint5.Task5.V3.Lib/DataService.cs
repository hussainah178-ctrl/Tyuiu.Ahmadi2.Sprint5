using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Ahmadi2.Sprint5.Task5.V3.Lib
{
    public class DataService : ISprint5Task5V3
    {
        public double LoadFromDataFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"File not found: {path}");

            string text = File.ReadAllText(path);

            int count = 0;

            foreach (char ch in text)
            {
                if ((ch >= 'A' && ch <= 'Z') ||
                    (ch >= 'a' && ch <= 'z'))
                {
                    count++;
                }
            }

            // интерфейс, скорее всего, требует double, поэтому приводим
            return count;
        }
    }
}
