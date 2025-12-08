using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Tyuiu.Ahmadi2.Sprint5.Task7.V28.Lib;

namespace Tyuiu.Ahmadi2.Sprint5.Task7.V28.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadDataAndSave()
        {
            string path = @"C:\DataSprint5\InPutDataFileTask7V28.txt";

           
            if (!File.Exists(path))
            {
                string testData = "Hello     World    This    is    a    test.";
                string directory = Path.GetDirectoryName(path);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                File.WriteAllText(path, testData);
            }

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(path);

            string result = File.ReadAllText(outputPath);
            string expected = "Hello World This is a test.";

            Assert.AreEqual(expected, result);
        }
    }
}