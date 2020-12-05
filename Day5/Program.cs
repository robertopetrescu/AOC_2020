using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Day5
{
    class Program
    {

        
        static void Main(string[] args)
        {
            // Day 5: Binary Boarding


            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"input.txt");
            string[] lines = File.ReadAllLines(path);

            
            partOne(lines);

           
            partTwo(lines);

        }

        public static void partOne(string[] lines)
        {
            
            int maxSeat = 0;
            foreach (var line in lines)
            {
                int seatId = findSeat(line);
                //Console.WriteLine(seatId);
                
                if (maxSeat <= seatId)
                    maxSeat = seatId;
                
            }
            Console.WriteLine(maxSeat);
        }

        public static void partTwo(string[] lines)
        {
            
            List<int> seatIds = new List<int>(); 
            foreach (var line in lines)
            {
                seatIds.Add(findSeat(line));   
            }
           
            seatIds.Sort();
           
            for(int i=1;i<seatIds.Count;i++)
            {
                if(seatIds[i]-seatIds[i-1] > 1)
                    Console.WriteLine(seatIds[i-1]+1);
            }
           
        }

        public static int findSeat(string line)
        {
            int[] seats = { 0, 127 };
            int[] columns = { 0, 7 };
            for (int i = 0; i <= 6; i++)
            {
                if (line[i].Equals('F'))
                {
                    seats[1] = (seats[1] + seats[0]) / 2;
                }
                else
                {
                    seats[0] += (seats[1] - seats[0]) / 2 + 1;
                }
            }
            for (int i = 7; i <= 9; i++)
            {
                if (line[i].Equals('L'))
                {
                    columns[1] = (columns[1] + columns[0]) / 2;
                }
                else
                {
                    columns[0] += (columns[1] - columns[0]) / 2 + 1;
                }
            }
            int seatId = seats[0] * 8 + columns[0];
            return seatId;
        }
        

    }
}
