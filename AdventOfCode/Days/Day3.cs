using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day3
    {
        public async Task Part1()
        {
            //read input file
            string[] lines = await File.ReadAllLinesAsync("Input/Day3.txt");
            int sum = 0;
            for(int x =0; x < lines.Length; x++)
            {
                lines[x] = $".{lines[x]}."; //add a dot to the beginning and end of each line
            }

            for (int row = 0; row < lines.Length; row++)
            {
                int startDigit = 0;
                int endDigit = 0;
                bool contDigit = false;
                string currDigit = "";
                for (int col = 0; col < lines[row].Length; col++)
                {
                    char character = lines[row][col];
                    if (char.IsDigit(character))
                    {
                        if (!contDigit)
                        {
                            contDigit = true;
                            startDigit = col;
                        }
                    }
                    else
                    {
                        if(contDigit)
                        {
                            endDigit = col;
                            //Console.Write(lines[row].Substring(startDigit, endDigit - startDigit));
                            //Console.Write("     ");
                            currDigit = lines[row].Substring(startDigit, endDigit - startDigit);
                            contDigit = false;

                            //find is surrounded by non-digits

                            ////get upper row 
                            int upperRow = row - 1;
                            int lowerRow = row + 1;
                            int start = startDigit - 1;
                            int end = endDigit + 1;
                            string upperRowStr = "";
                            string lowerRowStr = "";
                            string currRowStr = "";
                            if (start < 0)
                            {
                                start = 0;
                            }
                            if (end > lines[row].Length)
                            {
                                end = lines[row].Length;
                            }
                            if (upperRow >= 0)
                            {
                                Console.WriteLine(lines[upperRow].Substring(start, end - start));
                                upperRowStr = lines[upperRow].Substring(start, end - start).Replace(".", "");
                            }
                            //curr row
                            Console.WriteLine(lines[row].Substring(start, end - start));
                            currRowStr = lines[row].Substring(start, end - start).Replace(".", "").Replace(currDigit, "");

                            //lower row
                            if (lowerRow < lines.Length)
                            {
                                Console.WriteLine(lines[lowerRow].Substring(start, end - start));
                                lowerRowStr = lines[lowerRow].Substring(start, end - start).Replace(".", "");
                            }

                            if (upperRowStr.Length > 0 || currRowStr.Length > 0 || lowerRowStr.Length > 0)
                            {
                                sum += int.Parse(currDigit);
                                Console.WriteLine("Is part number");
                            }
                            Console.WriteLine();

                        }
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Sum: {sum}");
        }

    }
}
