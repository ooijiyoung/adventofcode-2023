using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    internal class D1
    {
        public async Task Day1()
        {
            // Read input file
            string[] lines = await File.ReadAllLinesAsync("Input/Day1.txt");
            int sum = 0;
            foreach (string line in lines)
            {
                Console.WriteLine(line);
                //get digits from string using regex
                var digits = Regex.Matches(line, @"\d+").Cast<Match>().Select(m => m.Value).ToList();
                if (digits.Any())
                {
                    var joinedDigit = string.Join("", digits);
                    Console.WriteLine(joinedDigit);
                    var f = joinedDigit.First();
                    var l = joinedDigit.Last();
                    //combine first char and last char to form a new string
                    var newString = f.ToString() + l.ToString();
                    Console.WriteLine(newString);
                    sum += int.Parse(newString);

                }
                //output sum value with label
                Console.WriteLine("Sum: {0} ", sum);

            }

        }

        public async Task Day1Part2()
        {
            //may contains overlapping words
            string[] lines = await File.ReadAllLinesAsync("Input/Day1.txt");
            int sum = 0;
            //number word to int
            Dictionary<string, int> numberWord = new()
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 }
            };

            var tmpDic = new Dictionary<string, int>();

            //algro to combine overlapping words
            foreach (var word in numberWord)
            {
                var potentalOverlaps =
                    numberWord.Keys.Where(x => x.StartsWith(word.Key.Last()));

                foreach (var overlap in potentalOverlaps)
                {
                    Console.WriteLine($"{word.Key} {overlap}");
                    //trim first charater of overlap
                    var trimmedOverlap = overlap.Substring(1);
                    //combine word and trimmed overlap
                    var combinedWord = word.Key + trimmedOverlap;
                    var secondnum = numberWord[overlap];
                    var newstr = word.Value.ToString() + secondnum.ToString();

                    tmpDic.Add(combinedWord, Convert.ToInt32(newstr));

                }
            }

            foreach (var item in numberWord)
            {
                tmpDic.Add(item.Key, item.Value);
            }

            //merge tmpDic to numberWord on top of numberWord
            numberWord = tmpDic;

            //print out numberWord
            foreach (var item in numberWord)
            {
                Console.WriteLine($"{item.Key} {item.Value}");
            }

            foreach (string line in lines)
            {
                string currLine = line;
                //replace string with number
                int wordCount = 0;
                //string contains number word


                foreach (var item in numberWord)
                {
                    currLine = currLine.Replace(item.Key, item.Value.ToString());


                }
                //Console.WriteLine(line);

                //Console.WriteLine(currLine);
                //get digits from string using regex
                var digits = Regex.Matches(currLine, @"\d+").Cast<Match>().Select(m => m.Value).ToList();
                string newString = "";
                if (digits.Any())
                {
                    var joinedDigit = string.Join("", digits);
                    var f = joinedDigit.First();
                    var l = joinedDigit.Last();
                    //combine first char and last char to form a new string
                    newString = f.ToString() + l.ToString();
                    //Console.WriteLine(newString);
                    sum += int.Parse(newString);

                }
                Console.WriteLine($"{line};{currLine};{newString};{sum}");

            }
            Console.WriteLine("Sum: {0} ", sum);

        }

        
    }

}
