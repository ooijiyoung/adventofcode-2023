using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    internal class Day2
    {
        public async Task Day2Part1()
        {
            string[] lines = await File.ReadAllLinesAsync("Input/Day2.txt");
            int sum = 0;
            foreach (var line in lines)
            {
                Console.WriteLine(line);

                //parse game id;
                var gameid = line.Split(":")[0];
                //select int from string
                var gameidint = string.Join("", Regex.Matches(gameid, @"\d+").Cast<Match>().Select(m => m.Value).ToList());
                Console.WriteLine(gameidint);
                var gameDat = line.Split(":")[1];
                var gameDataSets = gameDat.Split(";");
                bool isValid = ParseGameSet(gameDataSets); ;
                if (isValid)
                {
                    sum += Convert.ToInt32(gameidint);
                }



            }
            Console.WriteLine("Sum: {0} ", sum);
        }

        private bool ParseGameSet(string[] gameDataSets)
        {
            int blueMax = 14;
            int greenMax = 13;
            int redMax = 12;

            string bluePtn = @"(\d+)(?= blue)";
            string greenPtn = @"(\d+)(?= green)";
            string redPtn = @"(\d+)(?= red)";
            bool isValid = false;

            foreach (var gameDataSet in gameDataSets)
            {
                var blue = Regex.Matches(gameDataSet, bluePtn).Cast<Match>().Select(m => Convert.ToInt32(m.Value)).FirstOrDefault(0);
                var green = Regex.Matches(gameDataSet, greenPtn).Cast<Match>().Select(m => Convert.ToInt32(m.Value)).FirstOrDefault(0);
                var red = Regex.Matches(gameDataSet, redPtn).Cast<Match>().Select(m => Convert.ToInt32(m.Value)).FirstOrDefault(0);
                if (blue > blueMax || green > greenMax || red > redMax)
                {
                    isValid = false;
                    break;
                }
                else
                {
                    isValid = true;
                }

            }


            return isValid;

        }
        public class GameResult
        {
            public int Blue { get; set; }
            public int Green { get; set; }
            public int Red { get; set; }
        }

        public async Task Day2Part2()
        {
            string[] lines = await File.ReadAllLinesAsync("Input/Day2.txt");
            int sum = 0;
            foreach (var line in lines)
            {
                Console.WriteLine(line);

                //parse game id;
                var gameid = line.Split(":")[0];
                //select int from string
                var gameidint = string.Join("", Regex.Matches(gameid, @"\d+").Cast<Match>().Select(m => m.Value).ToList());
                Console.WriteLine(gameidint);
                var gameDat = line.Split(":")[1];
                var gameDataSets = gameDat.Split(";");
                int power = ParseGameSetMinAmnt(gameDataSets); ;
                sum += power;
            }
            Console.WriteLine("Sum: {0} ", sum);
        }

        private int ParseGameSetMinAmnt(string[] gameDataSets)
        {
            int blueMax = 0;
            int greenMax = 0;
            int redMax = 0;

            string bluePtn = @"(\d+)(?= blue)";
            string greenPtn = @"(\d+)(?= green)";
            string redPtn = @"(\d+)(?= red)";
            bool isValid = false;

            foreach (var gameDataSet in gameDataSets)
            {
                var blue = Regex.Matches(gameDataSet, bluePtn).Cast<Match>().Select(m => Convert.ToInt32(m.Value)).FirstOrDefault(0);
                var green = Regex.Matches(gameDataSet, greenPtn).Cast<Match>().Select(m => Convert.ToInt32(m.Value)).FirstOrDefault(0);
                var red = Regex.Matches(gameDataSet, redPtn).Cast<Match>().Select(m => Convert.ToInt32(m.Value)).FirstOrDefault(0);
               
                if(blue > blueMax)
                {
                    blueMax = blue;
                }
                if (green > greenMax)
                {
                    greenMax = green;
                }
                if (red > redMax)
                {
                    redMax = red;
                }


            }


            return (blueMax * greenMax * redMax);

        }
    }
}
