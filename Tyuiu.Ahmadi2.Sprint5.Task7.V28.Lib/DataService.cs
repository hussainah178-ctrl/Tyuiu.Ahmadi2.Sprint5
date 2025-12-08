using System;
using System.IO;
using System.Text.RegularExpressions;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Ahmadi2.Sprint5.Task7.V28.Lib
{
    public class DataService :ISprint5Task7V28
    {
        public string LoadDataAndSave(string path)
        {
            string content = File.ReadAllText(path);

            
            string result = Regex.Replace(content, @"\s+", " ");

            string outputPath = Path.Combine(Path.GetDirectoryName(path), "OutPutDataFileTask7V28.txt");
            File.WriteAllText(outputPath, result);

            return outputPath;
        }
    }
}