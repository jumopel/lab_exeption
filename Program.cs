using System;
using System.IO;
namespace lab_exeption


{
    internal class Program
    {

        static void Main(string[] args)
        {
           

        }
        public void ReadeFile()
        {
            List<string> noFile = new();
            List<string> badData = new();
            List<string> overflow = new();
            List<int> products = new();
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

            }
        }
    }
}
