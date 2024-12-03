using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

enum Direction {
    ASC,
    DESC,
    IND
}

namespace AdventOfCode2024.Day2
{

    internal class Report
    {
        private Direction direction;
        private List<int> levels = new List<int>();
        private bool isSafe = false;
        private bool isValid = false;
        private int min = 0;
        private int max = 0;

        /// <summary>
        /// Sets the report's levels.
        /// </summary>
        /// <param name="levels">The list of levels from the report</param>
        /// <param name="minThreshold">The minimum threshold for safety. Absolute.</param>
        /// <param name="maxThreshold">The maximum threshold for safety. Absolute.</param>
        public void SetLevels(List<int> levels, int minThreshold, int maxThreshold)
        {
            this.min = minThreshold;
            this.max = maxThreshold;
            this.levels = new List<int>(levels);
            this.isValid = DetermineValidity(levels);
            this.isSafe = DetermineSafety();

        }

        //Determines the direction of the report
        private bool DetermineValidity(List<int> input)
        {
            bool increasing = IsIncreasing(input);
            bool decreasing = IsDecreasing(input);

            //Determine if its neither ASC/DESC
            if(!increasing && !decreasing)
            {
                direction = Direction.IND;
                return false;
            }
            else if(increasing)
            {
                direction = Direction.ASC;
            }
            else if(decreasing)
            {
                direction = Direction.DESC;
            }

            //Check that all adjacent are within bounds
            for (int i = 1; i < input.Count; i++)
            {
                int diff = Math.Abs(input[i] - input[i - 1]);

                if(diff < min || diff > max)
                {
                    //Outside of safe bounds
                    return false;
                }
            }

            return true;

        }

        private bool IsIncreasing(List<int> input)
        {
            for(int i = 1; i < input.Count; i++)
            {
                if (input[i-1] > input[i])
                {
                    return false;
                }
            }

            return true;
        }
        private bool IsDecreasing(List<int> input)
        {
            for (int i = 1; i < input.Count; i++)
            {
                if (input[i - 1] < input[i])
                {
                    return false;
                }
            }

            return true;
        }

        //Determines if the report is safe
        private bool DetermineSafety()
        {
            /*
             * The levels are either all increasing or all decreasing.
             *  Any two adjacent levels differ by at least one and at most three.
             */

            //We already know this is valid
            if(isValid)
            {
                return true;
            }

            //If we arent valid, can we remove a single level to make it valid?
            for (int i = 0; i < levels.Count; i++)
            {
                List<int> temp = new List<int>(this.levels);

                temp.RemoveAt(i);
                bool pass = DetermineValidity(temp);

                //foreach (int level in levels)
                //{ Console.Write($"{level}, "); }
                //Console.WriteLine();
                //foreach (int level in temp)
                //{ Console.Write($"{level}, "); }
                //Console.WriteLine();
                //Console.WriteLine(direction);
                //Console.WriteLine(pass);
                //Console.WriteLine();

                //Did we pass this time?
                if(pass) { return true; }
            }

            //Still failed
            return false;
            
            
        }

        public bool GetIsSafe()
        {
            return this.isSafe;
        }
            
    }
}
