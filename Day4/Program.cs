using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace AOC_2020
{
    class Program
    {
        public static void Main(string[] args)
        {

            // Day 4: Passport Processing

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"input.txt");
            string[] lines = File.ReadAllLines(path);

            //Check lines that contain "byr:", "iyr:", "eyr:", "hgt:", "hcl:", "ecl:", "pid:"
            partOne(lines);

            // Check lines that meet conditions for each key
            partTwo(lines);

        }
        
        public static void partOne(string[] lines)
        {

            string[] toContain = { "byr:", "iyr:", "eyr:", "hgt:", "hcl:", "ecl:", "pid:" };

            string oneLine = "";
            int count = 0;

            foreach (var line in lines)
            {
                // add each line to a single string
                oneLine += line + " ";

                // when empty row is met or last row 
                if (line == "" || line == lines.Last())
                {
                    // check if all strings from toContain are present
                    if (toContain.All(oneLine.Contains))
                    { 
                        count++;
                    }
                    
                    //resent single string to empty
                    oneLine = "";

                }
            }

            Console.WriteLine("Lines with specified keys: {0}", count);
            
        }

        public static void partTwo(string[] lines)
        {

            string[] toContain = { "byr:", "iyr:", "eyr:", "hgt:", "hcl:", "ecl:", "pid:" };

            string oneLine = "";
            int count = 0;

            foreach (var line in lines)
            {
                oneLine += line + " ";
                if (line == "" || line == lines.Last())
                {

                    // check if all strings from toContain are present
                    if (toContain.All(oneLine.Contains))
                    {
                        int check = 0;
                        
                        //create an array of strings with each key
                        string[] keys = oneLine.Split(" ");
                        foreach (var key in keys)
                        {

                            //byr (Birth Year) - four digits; at least 1920 and at most 2002.
                            if (key.Contains(toContain[0]))
                            {
                                int year = Int32.Parse(key.Split(":")[1]);
                                if (year >= 1920 && year <= 2002) 
                                {
                                    check++;
                                }
                            }

                            //iyr (Issue Year) - four digits; at least 2010 and at most 2020.
                            if (key.Contains(toContain[1]))
                            {
                                int year = Int32.Parse(key.Split(":")[1]);
                                if (year >= 2010 && year <= 2020)
                                {
                                    check++;
                                }
                            }

                            //eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
                            if (key.Contains(toContain[2]))
                            {
                                int year = Int32.Parse(key.Split(":")[1]);
                                if (year >= 2020 && year <= 2030)
                                {
                                    check++;
                                }
                            }

                            //hgt (Height) - a number followed by either cm or in:
                            //              If cm, the number must be at least 150 and at most 193.
                            //              If in, the number must be at least 59 and at most 76.
                            if (key.Contains(toContain[3]))
                            {
                                string split = key.Split(":")[1];
                                string measure= split.Substring(split.Length - 2);
                                
                                var isNumber = int.TryParse(split.Substring(0, split.Length - 2), out int n);
                                if (isNumber)
                                {
                                    if (measure.Equals("cm"))
                                    {
                                        if (n >= 150 && n <= 193)
                                        {
                                            check++;
                                        }
                                    }
                                    else
                                    if (measure.Equals("in"))
                                    {
                                        if (n >= 59 && n <= 76)
                                        {
                                            check++;
                                        }
                                    }
                                }
                            }

                            //hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                            if (key.Contains(toContain[4]))
                            {
                                string hair = key.Split(":")[1];
                                if (hair[0].Equals('#') && Regex.IsMatch(hair.Substring(1), @"\A\b[0-9a-fA-F]+\b\Z"))
                                {
                                    check++;
                                }
                            }


                            //ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
                            if (key.Contains(toContain[5]))
                            {
                                string[] toCompare = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                                string eyeColor = key.Split(":")[1];
                                if (toCompare.Contains(eyeColor))
                                {
                                    check++;
                                }
                            }

                            //pid (Passport ID) - a nine-digit number, including leading zeroes.
                            if (key.Contains(toContain[6]))
                            {
                                string pid = key.Split(":")[1];
                                if (Regex.IsMatch(pid, @"^0{0,3}[1-9]\d*$") && pid.Length == 9)
                                {
                                    
                                    check++;
                                }
                            }

                        }

                        if (check == 7)
                        {
                            count++;
                            
                        }
                    }
                    
                    oneLine = "";
                }
            }
            Console.WriteLine("Lines with keys that meet the criteria: {0}", count);

        }
    }
}

