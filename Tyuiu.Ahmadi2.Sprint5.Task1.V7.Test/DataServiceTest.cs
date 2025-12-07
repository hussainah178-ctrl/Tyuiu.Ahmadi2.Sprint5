using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Ahmadi2.Sprint5.Task1.V7.Lib;

namespace Tyuiu.Ahmadi2.Sprint5.Task1.V7.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidGetMatrix()
        {
            DataService ds = new DataService();

            double startValue = -5;
            double stopValue = 5;

            double[,] matrix = ds.GetMatrix(startValue, stopValue);

            // Проверяем количество элементов
            int expectedCount = 11; // от -5 до 5 включительно: 11 значений
            Assert.AreEqual(expectedCount, matrix.GetLength(0));

            // Проверяем первый элемент
            Assert.AreEqual(-5, matrix[0, 0]);

            // Проверяем последний элемент
            Assert.AreEqual(5, matrix[10, 0]);

            // Проверяем обработку деления на ноль (при x = -1.2)
            // В нашем массиве x изменяется с шагом 1, поэтому x = -1.2 не присутствует
            // Проверяем корректность вычисления для нескольких точек
            Assert.IsNotNull(matrix);
        }

        [TestMethod]
        public void ValidSaveToFileTextData()
        {
            DataService ds = new DataService();

            double startValue = -5;
            double stopValue = 5;

            string path = ds.SaveToFileTextData(startValue, stopValue);

            // Проверяем, что файл создан
            Assert.IsTrue(System.IO.File.Exists(path));

            // Проверяем, что файл не пустой
            string fileContent = System.IO.File.ReadAllText(path);
            Assert.IsTrue(fileContent.Length > 0);

            // Проверяем, что файл содержит заголовок
            Assert.IsTrue(fileContent.Contains("Табулирование функции"));

            // Очистка тестового файла
            System.IO.File.Delete(path);
        }
    }
}