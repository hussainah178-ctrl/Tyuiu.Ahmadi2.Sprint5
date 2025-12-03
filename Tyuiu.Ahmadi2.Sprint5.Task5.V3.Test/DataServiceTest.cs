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
            string path = Path.GetTempFileName();

            try
            {
                // Test case 1: Mixed integers and real numbers
                string[] testData1 = {
                    "10",      // integer
                    "3.14159", // real
                    "5",       // integer  
                    "2.71828", // real
                    "7"        // integer
                };

                File.WriteAllLines(path, testData1);

                // Expected: 10 + 3.142 + 5 + 2.718 + 7 = 27.86
                double expected1 = 10 + Math.Round(3.14159, 3) + 5 + Math.Round(2.71828, 3) + 7;
                expected1 = Math.Round(expected1, 3);
                double result1 = ds.LoadFromDataFile(path);
                Assert.AreEqual(expected1, result1, 0.001);

                // Test case 2: Only integers
                string[] testData2 = { "1", "2", "3", "4", "5" };
                File.WriteAllLines(path, testData2);

                double expected2 = 15; // 1+2+3+4+5
                double result2 = ds.LoadFromDataFile(path);
                Assert.AreEqual(expected2, result2);

                // Test case 3: Only real numbers
                string[] testData3 = { "1.234", "2.345", "3.456" };
                File.WriteAllLines(path, testData3);

                double expected3 = Math.Round(1.234, 3) + Math.Round(2.345, 3) + Math.Round(3.456, 3);
                expected3 = Math.Round(expected3, 3);
                double result3 = ds.LoadFromDataFile(path);
                Assert.AreEqual(expected3, result3, 0.001);

                // Test case 4: Empty lines and spaces
                string[] testData4 = { " 10 ", "", "  5.678  ", "  ", "3" };
                File.WriteAllLines(path, testData4);

                double expected4 = 10 + Math.Round(5.678, 3) + 3;
                expected4 = Math.Round(expected4, 3);
                double result4 = ds.LoadFromDataFile(path);
                Assert.AreEqual(expected4, result4, 0.001);

                // Test case 5: Negative numbers
                string[] testData5 = { "-10", "3.5", "-2", "-1.333" };
                File.WriteAllLines(path, testData5);

                double expected5 = -10 + Math.Round(3.5, 3) + (-2) + Math.Round(-1.333, 3);
                expected5 = Math.Round(expected5, 3);
                double result5 = ds.LoadFromDataFile(path);
                Assert.AreEqual(expected5, result5, 0.001);
            }
            finally
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileNotFoundLoadFromDataFile()
        {
            DataService ds = new DataService();
            string path = @"C:\NonExistentPath\NonExistentFile.txt";
            ds.LoadFromDataFile(path);
        }
    }
}