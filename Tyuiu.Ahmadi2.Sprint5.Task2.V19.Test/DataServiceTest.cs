using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Ahmadi2.Sprint5.Task2.V19.Lib;
using System.IO;

namespace Tyuiu.Ahmadi2.Sprint5.Task2.V19.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidGetMatrix()
        {
            DataService ds = new DataService();

            int[,] inputMatrix = {
                {9, 2, 5},
                {8, 8, 2},
                {7, 4, 8}
            };

            int[,] expectedMatrix = {
                {0, 2, 0},
                {8, 8, 2},
                {0, 4, 8}
            };

            int[,] resultMatrix = ds.GetMatrix(inputMatrix);

            CollectionAssert.AreEqual(expectedMatrix, resultMatrix);
        }

        [TestMethod]
        public void ValidSaveToFile()
        {
            DataService ds = new DataService();

            int[,] matrix = {
                {0, 2, 0},
                {8, 8, 2},
                {0, 4, 8}
            };

            string filePath = ds.SaveToFile(matrix);

            // Проверяем что файл создан
            Assert.IsTrue(File.Exists(filePath));

            // Проверяем содержимое файла
            string[] fileLines = File.ReadAllLines(filePath);
            Assert.AreEqual(3, fileLines.Length);
            Assert.AreEqual("0;2;0", fileLines[0]);
            Assert.AreEqual("8;8;2", fileLines[1]);
            Assert.AreEqual("0;4;8", fileLines[2]);

            // Очистка
            File.Delete(filePath);
        }

        [TestMethod]
        public void ValidMatrixToString()
        {
            DataService ds = new DataService();

            int[,] matrix = {
                {0, 2, 0},
                {8, 8, 2},
                {0, 4, 8}
            };

            string result = ds.MatrixToString(matrix);
            string expected = " 0; 2; 0\r\n 8; 8; 2\r\n 0; 4; 8";

            Assert.AreEqual(expected, result);
        }
    }
}