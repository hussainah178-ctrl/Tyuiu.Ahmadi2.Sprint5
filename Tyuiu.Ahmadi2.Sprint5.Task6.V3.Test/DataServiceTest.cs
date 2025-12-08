using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tyuiu.Ahmadi2.Sprint5.Task6.V3.Lib;
using System.IO;

namespace Tyuiu.Ahmadi2.Sprint5.Task6.V3.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidLoadFromDataFile()
        {
            string path = @"C:\DataSprint5\InPutDataFileTask6V3.txt";

            DataService ds = new DataService();
            int res = ds.LoadFromDataFile(path);

            int wait = 10;
            Assert.AreEqual(wait, res);
        }
    }
}