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

            //Day 2: Password Philosophy

            //Read from file 
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"input.txt");
            string[] values = File.ReadAllLines(path);

            // A char must appear in a string between the specified range
            // Example: 1-3 a: abcade
            // Answer:  'a' appears 2 time => valid ; it means that the password must contain a at least 1 time and at most 3 times.
            partOne(values);

            //// A char must appear in a string in the specified positions
            // Example: 1-3 a: abcde
            // Answer:  'a' appears in the first position, but not on the third => not valid. (it's invalid for both positions)
            partTwo(values);

        }

        public static void partOne(string[] values)
        {
            int countTotal = 0;
            foreach (var value in values)
            {
                // split by ':' to get condition and character to search for
                string[] words = value.Split(":");
                
                // get character to search for
                char c = words[0].Last();

                // remove the last 2 chars ( now we only have '1-3')
                words[0] = words[0].Remove(words[0].Length - 2);

                //split to get min and max
                string[] minmax = words[0].Split("-");
                int min = Int32.Parse(minmax[0]);
                int max = Int32.Parse(minmax[1]);

                // count specified character in string
                int count = words[1].Count(f => f == c);

                // count lines that meet the criteria
                if (count >= min && count <= max)
                    countTotal++;
            }
            Console.WriteLine(countTotal);
        }

        public static void partTwo(string[] values) 
        {
            int count = 0;
            foreach (var value in values)
            {
                // split by ':' to get condition and character to search for
                string[] words = value.Split(":");
                
                // get character to search for
                char c = words[0].Last();

                // remove the last 2 chars ( now we only have '1-3')
                words[0] = words[0].Remove(words[0].Length - 2);

                //split to get first and second positions
                string[] minmax = words[0].Split("-");
                int firstPos = Int32.Parse(minmax[0]);
                int secondPos = Int32.Parse(minmax[1]);

                string password = words[1];

                // count lines that meet the criteria
                // check if on any of the specified indexes the character is present and if it's not on both positions
                if ((password[firstPos].Equals(c) || password[secondPos].Equals(c)) && 
                    !(password[firstPos].Equals(c) && password[secondPos].Equals(c)))
                    count++;
            }
            Console.WriteLine(count);
        }
    }

}
