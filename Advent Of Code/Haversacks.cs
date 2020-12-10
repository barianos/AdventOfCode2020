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
 *  This file covers the solution to Day 7 puzzles
 */

namespace Advent_Of_Code
{
    class Haversacks
    {
        string bagOfInterest;
        List<BagModel> rules;
        public Haversacks()
        {
            List<string> input = new List<string>(File.ReadAllLines("C:\\Users\\User\\Documents\\DesktopDev\\Advent Of Code\\ProblemInputs\\Day9.txt"));
            bagOfInterest = "shiny gold";
            rules = new List<BagModel>();
            foreach (string line in input)
            {
                rules.Add(new BagModel(line));
            }
            Console.WriteLine("Puzzle 2: " + findBagByColorRecursive(bagOfInterest));
        }
        /// <summary>
        /// Counts all the bags that can contain a bag of given color
        /// </summary>
        private int findBagByColorRecursive(string color)
        {
            int retv = 0;
            foreach (BagModel rule in rules)
            {
                if (rule.Color.Equals(color))
                {
                    foreach (BagRule extra in rule.IncludeRule)
                    {
                        retv += extra.Count + extra.Count * findBagByColorRecursive(extra.Color);
                    }
                }

            }
            return retv;
        }
    }
}
