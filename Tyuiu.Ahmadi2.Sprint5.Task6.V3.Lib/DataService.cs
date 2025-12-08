using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Ahmadi2.Sprint5.Task6.V3.Lib
{
    public class DataService :ISprint5Task6V3
    {
        public int LoadFromDataFile(string path)
        {
            int count = 0;
            string content = File.ReadAllText(path);

            foreach (char ch in content)
            {
                if ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z'))
                {
                    count++;
                }
            }
            return count;
        }
    }
}