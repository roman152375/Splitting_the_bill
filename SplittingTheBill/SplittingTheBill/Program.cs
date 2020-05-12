using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplittingTheBill
{
    class Program
    {
        static readonly string rootFolder = @"C:\Users\ratul\source\repos";
        static readonly string textFile = @"C:\Users\ratul\source\repos\SplittingTheBill\input";
        static void Main(string[] args)
        {
            int people = 0;
            int totalBills = 0;
            int counter = 0;
            double total = 0;
            if (File.Exists(textFile))
            {

                string[] lines = File.ReadAllLines(textFile);

                if (lines.Length <= 1)
                {
                    Console.WriteLine("Not enough data to calculate, update your file.");
                    Console.ReadKey();
                }
                else
                {

                    people = int.Parse(lines[0]);
                    double[] people1 = new double[people];
                    for (int l = 1; l < lines.Length; l++)
                    {
                        if (int.Parse(lines[l]) == 0)
                        {
                            Console.WriteLine("No more bills to calculate, processing...");
                            Console.WriteLine();
                        }
                        else if (int.Parse(lines[l]) != 0)
                        {
                            int bills = int.Parse(lines[l]);
                            totalBills += bills;
                            Console.WriteLine("Bills to Process " + "for Person " + (counter + 1) + ": " + bills);

                            for (int i = 0; i < bills; i++)
                            {
                                people1[counter] += double.Parse(lines[l + 1]);
                                total += double.Parse(lines[l + 1]);
                            }
                            l += bills;
                            counter++;
                            Console.ReadKey();
                        }

                    }
                    double avg = total / totalBills;
                    Console.WriteLine("Bills: " + totalBills);
                    Console.WriteLine("People: " + people);
                    Console.WriteLine("Total: $" + total);
                    Console.WriteLine("Average: $" + avg);
                    Console.WriteLine();
                    counter = 0;
                    foreach (double i in people1)
                    {
                        if (i > avg)
                        {
                            Console.WriteLine("Person " + (counter + 1) + " paid $" + i + " so this person should receive an amount of: $" + (i - avg));

                        }
                        else if (i < avg)
                        {
                            Console.WriteLine("Person " + (counter + 1) + " paid $" + i + " should pay an amount of: $" + (avg - i));
                        }
                        else if (i == avg)
                        {
                            Console.WriteLine("Equal, we're fine");
                        }
                        counter++;
                    }
                    Console.ReadKey();

                }

            }
        }

    }
}

