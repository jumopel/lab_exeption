using System;
using System.IO;
using System.Drawing;
namespace lab_exeption


{
    internal class Program
    {
        private List<int> products;
        public Program()
        {
            products = new List<int>();
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.ReadeFile();
            p.Averege();

        }
        public void ReadeFile()
        {
            List<string> noFile = new();
            List<string> badData = new();
            List<string> overflow = new();
            for (int i = 10; i <= 29; i++)
            {
                try
                {
                    string[] lines = File.ReadAllLines($"{i}.txt");

                    string n1 = lines[0];
                    string n2 = lines[1];

                    int num1 = int.Parse(n1);
                    int num2 = int.Parse(n2);

                    checked
                    {
                        int p = num1 * num2;
                        products.Add(p);
                    }

                }
                catch (IndexOutOfRangeException)
                {
                    badData.Add($"{i}.txt");
                }
                catch (FileNotFoundException)
                {
                    noFile.Add($"{i}.txt");
                }
                catch (FormatException)
                {
                    badData.Add($"{i}.txt");
                }
                catch (OverflowException)
                {
                    overflow.Add($"{i}.txt");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred while processing {i}.txt: {ex.Message}");
                }
                try
                {
                    File.WriteAllLines("no_file.txt", noFile);
                    File.WriteAllLines("bad_data.txt", badData);
                    File.WriteAllLines("overflow.txt", overflow);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while writing to the log files: {ex.Message}");
                }
            }
            
        }
        public void Averege()
        {
            try
            {
                double ave = products.Average();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("There are no numbers to calculate the average.");
            }
        }

    }
}
