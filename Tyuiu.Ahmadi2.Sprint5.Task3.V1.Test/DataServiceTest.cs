using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Ahmadi2.Sprint5.Task3.V1.Lib;
using System.IO;

namespace Tyuiu.Ahmadi2.Sprint5.Task3.V1.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidCalculate()
        {
            DataService ds = new DataService();
            int x = 3;
            double wait = 1.5; // 3³ / (2 * 3²) = 27 / 18 = 1.5
            double result = ds.Calculate(x);
            Assert.AreEqual(wait, result);
        }

        [TestMethod]
        public void ValidSaveToFile()
        {
            DataService ds = new DataService();
            int x = 3;
            string filePath = ds.SaveToFile(x);

            // Проверяем что файл создан
            Assert.IsTrue(File.Exists(filePath));

            // Проверяем содержимое файла
            double fileContent;
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                fileContent = reader.ReadDouble();
            }

            double expected = 1.5;
            Assert.AreEqual(expected, fileContent);

            // Очистка
            File.Delete(filePath);
        }

        [TestMethod]
        public void ValidLoadFromFile()
        {
            DataService ds = new DataService();

            // Создаем временный файл для теста
            string tempPath = Path.GetTempPath();
            string filePath = Path.Combine(tempPath, "test.bin");

            double testValue = 1.5;
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                writer.Write(testValue);
            }

            double result = ds.LoadFromFile(filePath);
            Assert.AreEqual(testValue, result);

            // Очистка
            File.Delete(filePath);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void InvalidCalculate()
        {
            DataService ds = new DataService();
            int x = 0;
            ds.Calculate(x);
        }

        [TestMethod]
        public void ValidCalculateWithDifferentValues()
        {
            DataService ds = new DataService();

            // Тест с x = 2
            int x1 = 2;
            double expected1 = 1.0; // 8 / 8 = 1
            double result1 = ds.Calculate(x1);
            Assert.AreEqual(expected1, result1);

            // Тест с x = 4
            int x2 = 4;
            double expected2 = 2.0; // 64 / 32 = 2
            double result2 = ds.Calculate(x2);
            Assert.AreEqual(expected2, result2);

            // Тест с x = 5
            int x3 = 5;
            double expected3 = 2.5; // 125 / 50 = 2.5
            double result3 = ds.Calculate(x3);
            Assert.AreEqual(expected3, result3);
        }
    }
}