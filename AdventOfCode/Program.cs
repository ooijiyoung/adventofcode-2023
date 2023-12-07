using AdventOfCode.Days;

namespace AdventOfCode
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Day2 day = new Day2();
            //await day.Day2Part2();
            Day3 day = new Day3();
            await day.Part1();
        }
    }
}
