using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AOC_2020
{
    class Program
    {
        public static void Main(string[] args)
        {

            //Read from file and convert to int
            string path  = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"input.txt");
            int[] values = Array.ConvertAll(File.ReadAllLines(path), int.Parse);

            partOne(values);
            
            partTwo(values);

        }

        //Sum of 2 numbers = 2020, multiply them
        public static void partOne(int[] values)
        {
            for (int i = 0; i < values.Count(); i++)
                for (int j = i + 1; j < values.Count(); j++)
                    if (values[i] + values[j] == 2020)
                    {
                        Console.WriteLine(values[i] + " * " + values[j] + " = " + values[i] * values[j]); ;
                    }
        }

        //Sum of 3 numbers = 2020, multiply them
        public static void partTwo(int[] values)
        {
            for (int i = 0; i < values.Count(); i++)
                for (int j = i + 1; j < values.Count(); j++)
                    for (int k = j + 1; k < values.Count(); k++)
                        if (values[i] + values[j] + values[k] == 2020)
                        {
                            Console.WriteLine(values[i] + " " + values[j] + " " + values[k]);
                            Console.WriteLine(values[i] * values[j] * values[k]);

                        }
        }
    }


}
