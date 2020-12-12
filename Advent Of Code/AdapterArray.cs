using System;
using System.Collections.Generic;
using System.IO;

/*
* "THE BEER-WARE LICENSE" (Revision 42): Anastasios Barianos wrote this file. 
* As long as you retain this notice you can do whatever you want with this stuff. 
* If we meet some day, and you think this stuff is worth it, you can buy me a beer in return. 
* Anastasios Barianos
*/

/***
 *  For the problem presentation scroll to the end of the file.
 *  This file covers the solution to Day 10 puzzles
 */

namespace Advent_Of_Code
{

    class AdapterArray
    {
        List<int> adapters;

        public AdapterArray()
        {
            adapters = transformInputToListOfInt();
            adapters.Sort();
            int[] differences = CountJoltDifferences();
            int puzzle1Solution = differences[0] * differences[1];
            Console.WriteLine("Puzzle 1: " + puzzle1Solution);
            long[] allPaths = DynamicFunction();
            Console.WriteLine("Puzzle 2: " + allPaths[allPaths.Length-1]);
        }


        //Not working right yet, but i dont know why.
        //We know the jolts can only jump in 1 or 2, twos are not possible.
        //So i have to tweak the rules somehow. When i count the 2 diffs the result is larger than expected
        //But when i comment them out the result is smaller than expected
        private long[] DynamicFunction()
        {
            long[] sequenceArray = new long[adapters[adapters.Count-1]];
            sequenceArray[0] = 1;
            sequenceArray[1] = 1;
            sequenceArray[2] = 2;
            for(int i = 3; i< sequenceArray.Length; i++)
            {
                if (adapters.Contains(i+1))
                {
                    long temp = sequenceArray[i - 1];
                   // temp += sequenceArray[i - 2];
                    temp += sequenceArray[i - 3];
                    sequenceArray[i] = temp;
                }
                else
                {
                    sequenceArray[i] = 0;
                }
            }
            return sequenceArray;
        }

        public int[] CountJoltDifferences()
        {
            int[] counter = new int[2];
            counter[0] =  0;
            counter[1] = 1;
            
            int previous = 0;
            for (int i = 0; i < adapters.Count; i++)
            {
                int diff = adapters[i] - previous;
                switch (diff)
                {
                    case 1:
                        counter[0]++;
                        break;
                    case 3:
                        counter[1]++;
                        break;
                    default: //logical error
                        break;

                }
                previous = adapters[i];
            }
            return counter;
        }

        private List<int> transformInputToListOfInt()
        {
            List<string> input = new List<string>(File.ReadAllLines("C:\\Users\\User\\Documents\\DesktopDev\\Advent Of Code\\ProblemInputs\\Day10.txt"));
            List<int> retv = new List<int>();
            foreach (string line in input)
            {
                retv.Add(Int32.Parse(line.Replace('\r', ' ').Trim()));
            }
            return retv;
        }

    }
}
