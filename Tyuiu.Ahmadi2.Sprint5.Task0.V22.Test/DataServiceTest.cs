using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Ahmadi2.Sprint5.Task0.V22.Lib;
using System.IO;

namespace Tyuiu.Ahmadi2.Sprint5.Task0.V22.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidCalculate()
        {
            DataService ds = new DataService();
            int x = 3;
            double wait = 0.444;
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
            string fileContent = File.ReadAllText(filePath);
            string expected = "0.444";
            Assert.AreEqual(expected, fileContent);

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
    }
}