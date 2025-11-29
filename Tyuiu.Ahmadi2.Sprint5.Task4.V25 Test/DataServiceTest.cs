using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.Ahmadi2.Sprint5.Task4.V25.Lib;

namespace Tyuiu.Ahmadi2.Sprint5.Task4.V25.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadFromDataFile()
        {
            DataService ds = new DataService();

            // Create temporary file with test data
            string path = @"C:\DataSprint5\InPutDataFileTask4V0.txt";

            // Test case 1: Positive number
            File.WriteAllText(path, "2.5");
            double wait1 = (Math.Pow(2.5, 4) + Math.Cos(2.5)) * Math.Sin(2.5);
            wait1 = Math.Round(wait1, 3);
            double res1 = ds.LoadFromDataFile(path);
            Assert.AreEqual(wait1, res1);

            // Test case 2: Negative number
            File.WriteAllText(path, "-1.8");
            double wait2 = (Math.Pow(-1.8, 4) + Math.Cos(-1.8)) * Math.Sin(-1.8);
            wait2 = Math.Round(wait2, 3);
            double res2 = ds.LoadFromDataFile(path);
            Assert.AreEqual(wait2, res2);

            // Test case 3: Zero
            File.WriteAllText(path, "0");
            double wait3 = (Math.Pow(0, 4) + Math.Cos(0)) * Math.Sin(0);
            wait3 = Math.Round(wait3, 3);
            double res3 = ds.LoadFromDataFile(path);
            Assert.AreEqual(wait3, res3);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileNotFoundLoadFromDataFile()
        {
            DataService ds = new DataService();
            string path = @"C:\NonExistentPath\NonExistentFile.txt";
            ds.LoadFromDataFile(path);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InvalidFormatLoadFromDataFile()
        {
            DataService ds = new DataService();
            string path = @"C:\DataSprint5\InPutDataFileTask4V0.txt";
            File.WriteAllText(path, "invalid_number");
            ds.LoadFromDataFile(path);
        }
    }
}