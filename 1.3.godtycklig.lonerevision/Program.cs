using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1._3.godtycklig.lonerevision
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Exit = false;

            int SalariesIn;

            SalariesIn = 0;

            do
            {
                Console.Clear();
                
                    SalariesIn = ReadInt("Ange antal löner att mata in: ");

                    if (SalariesIn < 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Du måste mata in minst två löner för att göra en beräkning.");
                        Console.ResetColor();
                    }
                    else
                    {
                        ProcessSalaries(SalariesIn);
                    }
               

                

                Console.WriteLine();

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Tryck på valfri tangent för att göra en ny beräkning, esc avslutar programmet.");
                Console.ResetColor();

               
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static int ReadInt(string prompt)
        {
            string In;
            int Num;

            In = "0";

            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    In = Console.ReadLine();
                    Num = int.Parse(In);

                    if (Num < 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Skriv in ett högre värde än 0.");
                        Console.ResetColor();
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fel! '{0}' kan inte tolkas som ett heltal.", In);
                    Console.ResetColor();
                }
            }
            return Num;
        }

        private static void ProcessSalaries(int count)
        {
            int[] SalariesAmount = new int[count];

            for (int i = 0; i < count; i++)
            {
                SalariesAmount[i] = ReadInt(String.Format("Ange lön nummer {0}: ", i + 1));
            }

            Console.WriteLine();
            Console.WriteLine("----------------------------------");

            double MedSalary = 0;
            double AvgSalary = 0;
            double SalarySpread = 0;
            int Median1 = 0;
            int Median2 = 0;

            Array.Sort(SalariesAmount);

            if (count % 2 == 0)
            {
                Median1 = SalariesAmount[SalariesAmount.Length / 2];
                Median2 = SalariesAmount[SalariesAmount.Length / 2 - 1];

                MedSalary = ((Median1 + Median2) / 2);
            }
                //Kolla om det är jämt eller udda antal löner. Och om det är jämnt tal, plussa med varandra och dela med 2

            else
            {
                MedSalary = SalariesAmount[SalariesAmount.Length / 2];
            }

            AvgSalary = SalariesAmount.Average();

            SalarySpread = SalariesAmount.Max() - SalariesAmount.Min();

            Console.WriteLine("Medianlön :        {0:f0}", MedSalary);
            Console.WriteLine("Medellön :         {0:f0}", AvgSalary);
            Console.WriteLine("Lönespridning :    {0:f0}", SalarySpread);

            Console.WriteLine("---------------------------------");


        }
    }

}