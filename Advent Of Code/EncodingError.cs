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
 *  This file covers the solution to Day 9 puzzles
 */

namespace Advent_Of_Code
{
    class EncodingError
    {
        int DEPTH = 25;
        List<long> XmasSequence;
        public EncodingError()
        {
            XmasSequence = transformInputToList();
        }


        //PART 1
        public long FindWeaknessInSequence()
        {
            for (int i = DEPTH + 1; i < XmasSequence.Count; i++)
            {
                if (!checkNumber(i, DEPTH))
                {
                    return XmasSequence[i];
                }
            }
            return -1;
        }

        //PART 2
        public long RepairWeakinessInSequence(long goalNumber, int begin)
        {
            if (!(begin < XmasSequence.Count - 2))
            {
                return -1;
            }
            int i = begin;

            long sum = 0;
            while (i < XmasSequence.Count)
            {
                sum += XmasSequence[i];
                if (sum == goalNumber)
                {
                    return sumMinMax(begin, i);
                    //return XmasSequence[i-1] + XmasSequence[begin];
                }
                i++;
            }
            long recursion = (RepairWeakinessInSequence(goalNumber, begin + 1));
            if (recursion != -1)
                return recursion;


            return -1;
        }


        //UTILITIES
        private long sumMinMax(int begin, int end)
        {
            long min = long.MaxValue;
            long max = long.MinValue;

            for (int i = begin; i <= end; i++)
            {
                min = XmasSequence[i] < min ? XmasSequence[i] : min;
                max = XmasSequence[i] > max ? XmasSequence[i] : max;
            }
            return min + max;

        }

        private bool checkNumber(int position, int depth)
        {
            bool status = false;
            for (int i = position - depth; i < position; i++)
            {
                for (int j = position - depth; j < position; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    if (XmasSequence[i] + XmasSequence[j] == XmasSequence[position])
                    {
                        status = true;
                    }
                }

            }
            return status;
        }

        private List<long> transformInputToList()
        {
            List<string> input = new List<string>(File.ReadAllLines("C:\\Users\\User\\Documents\\DesktopDev\\Advent Of Code\\ProblemInputs\\Day9.txt"));
            List<long> sequence = new List<long>();
            foreach (string line in input)
            {
                sequence.Add(Int64.Parse(line.Replace('\r', ' ').Trim()));
            }
            return sequence;
        }
    } 
}