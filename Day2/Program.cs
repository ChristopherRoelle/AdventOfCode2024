using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Day2
{
    class Program
    {

        public static void Main(string[] args)
        {
            string inputString = "C:\\Users\\chris\\source\\repos\\AdventOfCode2024\\AdventOfCode2024\\Day2\\input.txt";
            Day2 day2 = new Day2();

            Console.WriteLine("Day 2");
            day2.ReadInput(inputString);

            Console.WriteLine($"Safe Reports: {day2.GetSafeReports()}");
            Console.WriteLine($"Unsafe Reports: {day2.GetUnsafeReports()}");

            //Solution 1: 220
            //Solution 2: 296

        }

    }
}
