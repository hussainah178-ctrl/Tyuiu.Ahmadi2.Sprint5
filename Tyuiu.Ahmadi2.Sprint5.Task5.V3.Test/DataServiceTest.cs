using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Tyuiu.Ahmadi2.Sprint5.Task5.V3.Lib;

namespace Tyuiu.Ahmadi2.Sprint5.Task5.V3.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidCalculateFromDataFile()
        {
            string tempPath = Path.GetTempFileName();
            string testContent = "10 20.5 30 40.1234 50.678";
            File.WriteAllText(tempPath, testContent);

            DataService ds = new DataService();
            double result = ds.CalculateFromDataFile(tempPath);

            // 10 + 20.5 + 30 + 40.123 + 50.678 = 151.301
            double wait = 151.301;

            File.Delete(tempPath);

            Assert.AreEqual(wait, result);
        }

        [TestMethod]
        public void ValidCalculateWithNegativeNumbers()
        {
            string tempPath = Path.GetTempFileName();
            string testContent = "-5 10.25 -3.456 7";
            File.WriteAllText(tempPath, testContent);

            DataService ds = new DataService();
            double result = ds.CalculateFromDataFile(tempPath);

            // -5 + 10.25 + (-3.456) + 7 = 8.794
            double wait = 8.794;

            File.Delete(tempPath);

            Assert.AreEqual(wait, result);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void InvalidPathTest()
        {
            DataService ds = new DataService();
            ds.CalculateFromDataFile(@"C:\NonExistentFolder\NonExistentFile.txt");
        }
    }
}