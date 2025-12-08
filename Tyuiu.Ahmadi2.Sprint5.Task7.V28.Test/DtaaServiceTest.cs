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
            string tempPath = Path.GetTempFileName();
            string testContent = "Hello     World    This    is    a    test.";
            File.WriteAllText(tempPath, testContent);

            DataService ds = new DataService();
            string outputPath = ds.LoadDataAndSave(tempPath);

            string result = File.ReadAllText(outputPath);
            string expected = "Hello World This is a test.";

            File.Delete(tempPath);
            File.Delete(outputPath);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void InvalidPathTest()
        {
            DataService ds = new DataService();
            ds.LoadDataAndSave(@"C:\NonExistentFolder\NonExistentFile.txt");
        }
    }
}