using System.Globalization;

namespace Tyuiu.Ahmadi2.Sprint5.Task5.V3.Lib
{
    public class DataServiceBase
    {
        public double LoadFromDataFile(string path)
        {
            double sum = 0;
            int count = 0;

            try
            {
                string allText = File.ReadAllText(path);
                string[] numbers = allText.Split(
                    new char[] { ' ', '\t', '\n', '\r', ',', ';', ':', '|' },
                    StringSplitOptions.RemoveEmptyEntries
                );

                foreach (string numStr in numbers)
                {
                    if (double.TryParse(numStr,
                        NumberStyles.Any,
                        CultureInfo.InvariantCulture,
                        out double number))
                    {

                        double rounded = Math.Round(number);
                        double diff = Math.Abs(number - rounded);

                        if (diff < 0.0000001)
                        {
                            sum += rounded;
                            count++;
                        }
                    }

                    if (count == 0)
                    {
                        Console.WriteLine($"Warning: No integers found in file. Total numbers processed: {numbers.Length}");
                    }

                    return sum;
                }
            catch (FileNotFoundException)
            {
                throw new Exception($"File not found at path: {path}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading file: {ex.Message}");
            }
        }
    }
}