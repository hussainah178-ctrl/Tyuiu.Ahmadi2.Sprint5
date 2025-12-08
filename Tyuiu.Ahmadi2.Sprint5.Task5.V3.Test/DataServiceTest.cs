using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.Ahmadi2.Sprint5.Task5.V3.Lib;

namespace Tyuiu.Ahmadi2.Sprint5.Task5.V3.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadFromDataFile()
        {
            DataService ds = new DataService();

            string path = @"C:\DataSprint\3\3.txt";

            if (!File.Exists(path))
            {
                // Create test file if original doesn't exist
                path = Path.GetTempFileName();
                string testData = "10\n15.5\n20\n3.14159\n7\n8.888\n";
                File.WriteAllText(path, testData);
            }

            double res = ds.LoadFromDataFile(path);
            double wait = 10 + Math.Round(15.5, 3) + 20 + Math.Round(3.14159, 3) + 7 + Math.Round(8.888, 3);
            wait = Math.Round(wait, 3);

            Assert.AreEqual(wait, res);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InvalidFileLoadFromDataFile()
        {
            DataService ds = new DataService();
            string path = @"C:\NonExistentFolder\NonExistentFile.txt";
            double res = ds.LoadFromDataFile(path);
        }
    }
}