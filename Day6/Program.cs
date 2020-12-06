using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            // Day 6: Custom Customs

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"input.txt");
            string[] lines = File.ReadAllLines(path);

           
            partOne(lines);

            partTwo(lines);
        }

        public static void partOne(string[] lines)
        {

            string allAnswers = "";
            int count = 0;

            foreach (var line in lines)
            {
                for (int i=0;i<line.Length;i++)
                {
                    //if answer is not present, add it to list and increment counter
                    if (!allAnswers.Contains(line.ElementAt(i))) 
                    {
                        allAnswers += line.ElementAt(i);
                        count++;
                    }
                }

                // when empty row is met 
                if (line.Equals(""))
                {
                    //reset single string to empty
                    allAnswers = "";
                }
            }

            Console.WriteLine("Part one: {0}", count);

        }

        public static void partTwo(string[] lines)
        {

            int count = 0;

            List<char> allChars = new List<char>();
            List<string> allLines = new List<string>();

            int countLinesInBatch = 0;
            int countLinesWithChar = 0;

            foreach (var line in lines) 
            {
                if (!line.Equals(""))
                {
                    allLines.Add(line);
                    countLinesInBatch++;
                }
                foreach (var character in line) 
                {
                    if (!allChars.Contains(character))
                        allChars.Add(character);
                }
                if (line.Equals(""))
                {
                    foreach (var c in allChars)
                    {
                        foreach (var line1 in allLines)
                        {
                            if (line1.Contains(c))
                            {
                                countLinesWithChar++;
                            }
                        }
                        if (countLinesInBatch == countLinesWithChar) 
                        {
                            count++;
                        }
                        countLinesWithChar = 0;
                    }
                    
                    allLines.Clear();
                    allChars.Clear();
                    countLinesInBatch = 0;
                }
            }
            Console.WriteLine("Part two: {0}",count);
            
        }
    }
}
