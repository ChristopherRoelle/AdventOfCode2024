using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode2024.Week1
{
    class Day1
    {
        List<int> list1 = new List<int>();
        List<int> list2 = new List<int>();

        public void ReadInput(string inputPath)
        {
            string line;

            try
            {
                StreamReader sr = new StreamReader(inputPath);

                //Read the first line
                line = sr.ReadLine();

                while(line != null)
                {
                    //Split the string
                    string[] values = line.Split("   ");

                    //Left goes to list 1, right to list 2
                    list1.Add(int.Parse(values[0]));
                    list2.Add(int.Parse(values[1]));

                    //Read the next line
                    line = sr.ReadLine();
                }

                //Clode the reader
                sr.Close();

                //Sort the lists
                list1.Sort();
                list2.Sort();

            }
            catch (Exception e) {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }

        public int CalculateDistance()
        {
            //With the lists sorted, find the difference between the smallest::smallest values.
            //For each pair (sorted asc), add the difference (absolute).

            int totalDistance = 0;

            for (int i = 0; i < list1.Count; i++)
            {
                totalDistance += Math.Abs(list1[i] - list2[i]);
            }

            return totalDistance;
        }

        public int CalculateSimilarityScore()
        {
            //For each entry in the left list, find how many times it occurs in the right list
            //Multiply the value by its occurance count 
            //Add all scores together. (even if the number is a dupe in the left list

            int totalSimilarity = 0;

            foreach (int i in list1)
            {
                int occurance = 0;

                foreach (int j in list2)
                {
                    if (i == j) occurance++;
                }

                totalSimilarity += i * occurance;
            }

            return totalSimilarity;
        }


    }
}
