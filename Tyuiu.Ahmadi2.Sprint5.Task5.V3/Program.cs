using System;
using System.IO;
using Tyuiu.Ahmadi2.Sprint5.Task5.V3.Lib;

namespace Tyuiu.Ahmadi2.Sprint5.Task5.V3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sprint #5 | Completed by: Ahmad T. | SMARTb-23-1";
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* Sprint #5                                                               *");
            Console.WriteLine("* Topic: Reading data from text file                                      *");
            Console.WriteLine("* Task #5                                                                 *");
            Console.WriteLine("* Variant #3                                                              *");
            Console.WriteLine("* Completed by: Ahmad T. | SMARTb-23-1                                    *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* TASK:                                                                   *");
            Console.WriteLine("* Given a file with values. Find sum of all integers in file.             *");
            Console.WriteLine("* Round real numbers to three decimal places.                             *");
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* INPUT DATA:                                                             *");
            Console.WriteLine("***************************************************************************");

            string path = @"C:\DataSprint\3\3.txt";

            Console.WriteLine($"Data file: {path}");

            if (!File.Exists(path))
            {
                Console.WriteLine("File not found!");
                Console.WriteLine("Create folder C:\\DataSprint\\3 and copy file 3.txt there");
                Console.ReadKey();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* RESULT:                                                                 *");
            Console.WriteLine("***************************************************************************");

            try
            {
                DataService ds = new DataService();
                double result = ds.LoadFromDataFile(path);

                Console.WriteLine($"Sum of integers (with real numbers rounded): {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}