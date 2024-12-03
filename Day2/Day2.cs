using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2024.Day2
{
    internal class Day2
    {
        int minSafety = 1;
        int maxSafety = 3;

        int safeReports = 0;
        int unsafeReports = 0;

        List<Report> reports = new List<Report>();

        //Reads the Input file and parses the data into Report objects (list stored).
        public void ReadInput(string inputPath)
        {
            string line;

            try
            {
                StreamReader sr = new StreamReader(inputPath);

                //Read first line
                line = sr.ReadLine();

                while (line != null)
                {
                    Report report = new Report();
                    List<int> levels = new List<int>();
                    string[] values = line.Split(' ');

                    foreach (string value in values)
                    {
                        levels.Add(int.Parse(value));
                    }

                    //Add the report
                    report.SetLevels(levels, minSafety, maxSafety);

                    reports.Add(report);

                    //Read the next line
                    line = sr.ReadLine();
                }

                sr.Close();

                //Determine the safety counts
                DetermineSafetyCounts();
            }
            catch (Exception e)
            {

                Console.WriteLine($"Exception: {e.Message}");
            }
        }

        public void DetermineSafetyCounts()
        {
            foreach (Report report in reports)
            {
                if (report.GetIsSafe())
                {
                    safeReports++;
                }
                else
                {
                    unsafeReports++;
                }

            }
        }

        public int GetSafeReports()
        {
            return safeReports;
        }

        public int GetUnsafeReports()
        {
            return unsafeReports;
        }
    }
}
