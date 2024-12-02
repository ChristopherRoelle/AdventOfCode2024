using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Week1
{
    internal class Program
    {

        public static void Main() {

            string inputPath = "C:\\Users\\chris\\source\\repos\\AdventOfCode2024\\AdventOfCode2024\\Week1\\input.txt";

            Week1 week1 = new Week1();

            week1.ReadInput(inputPath);

            Console.WriteLine($"Total Distance: {week1.CalculateDistance()}"); // Solution1: 2164381
            Console.WriteLine($"Total Similarity: {week1.CalculateSimilarityScore()}"); // Solution2: 20719933

        }


    }
}
