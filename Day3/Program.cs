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

            // Day 3: Toboggan Trajectory

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"input.txt");
            string[] lines = File.ReadAllLines(path);

            // count the number of '#'
            partOne(lines);

            // count the number of '#' for multiple input data and multiply the result
            partTwo(lines);
            
        }

        public static void partOne(string[] lines)
        {
            int count = 0;
            
            int down = 1;
            int right = 3;
            int rightIndex = right;

            for (int row = 1; row < lines.Count(); row += down)
            {

                string line = lines[row];
                
                // reset position
                if (rightIndex >= line.Length)
                    rightIndex = rightIndex - line.Length;

                Console.WriteLine("{0} is on row {1} and on position {2} contains {3}", line, row, rightIndex, line[rightIndex]);

                if (line[rightIndex].Equals('#'))
                    count++;

                rightIndex += right;
            }
            Console.WriteLine(count);
        }

        public static void partTwo(string[] lines)
        {
            
            int[] rightArr = { 1, 3, 5, 7, 1 };
            int[] downArr = { 1, 1, 1, 1, 2 };
            long nTree = 1;
            

            for (int i = 0; i < rightArr.Length; i++)
            {

                int count = 0;
                int down = downArr[i];
                int right = rightArr[i];
                int rightIndex = right;

                for (int row = down; row < lines.Count(); row += down)
                {
                    //single line
                    string line = lines[row];

                    //reset position
                    if (rightIndex >= line.Length)
                        rightIndex = rightIndex - line.Length;

                    // count '#'
                    if (line[rightIndex].Equals('#'))
                        count++;

                    rightIndex += right;
                }
                Console.WriteLine("Value for each: {0}",count);
                nTree = nTree * count;
            }
            Console.WriteLine(nTree);

        }


    }

}



