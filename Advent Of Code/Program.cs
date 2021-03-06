﻿using System;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


/*
 * "THE BEER-WARE LICENSE" (Revision 42): Anastasios Barianos wrote this file. 
 * As long as you retain this notice you can do whatever you want with this stuff. 
 * If we meet some day, and you think this stuff is worth it, you can buy me a beer in return. 
 * Anastasios Barianos
 */

/***
 *  This project is done for fun, in participation to the Advent of Code 2020.
 *  https://adventofcode.com
 *  Thanks to all people who made the challenges, run the website, etc.
 *
 */



namespace Advent_Of_Code
{
    class Program
    {
        static int CURRENT_YEAR = 2020;
        static void Main(string[] args)
        {
            //TODO: day 4 with regex
            //TODO: Do a more elegant way for day 5 part 2

            Console.WriteLine("*********Welcome to the Advent Of Code!*******\n -------------------");
            //Day10
            AdapterArray adapters = new AdapterArray();

            ////Day 9
            //EncodingError ee = new EncodingError();
            //long part1 = ee.FindWeaknessInSequence();
            //Console.WriteLine("Part 1 Number: " + part1);
            //long part2 = ee.RepairWeakinessInSequence(part1,0);
            //Console.WriteLine("Part 2 Number: " + part2);

            ////Day8 Solution
            //HandheldHalting hh = new HandheldHalting();
            //int acc = hh.ExecuteProgramToHalt();
            //Console.WriteLine("Puzzle 1: Accumulator Value: " + acc);
            //hh = new HandheldHalting();
            //acc = hh.ExecuteToBoot();
            //Console.WriteLine("Puzzle 2: Accumulator Value: " + acc);

            ////Day 7 Solution
            //Haversacks h = new Haversacks();

            ////Day 6 Solution
            //CustomCustoms cc = new CustomCustoms();

            ////Day 5 Solution
            //SeatLocation mySeat = new SeatLocation();
            //Console.WriteLine("Binary: " + mySeat.getMySeat());
            ////Console.WriteLine("Binary: " + mySeat.getLargestID()); //solution utilizing binary logic
            ////Console.WriteLine("Max Id: " + mySeat.findMaxID()); //dummies way

            ////Day 4 Solution
            //Passports p = new Passports();
            //int solution = p.countObjects();
            //Console.WriteLine("There are " + solution + "  valid passports!");

            ////Day 3 Solution 2
            //TreeSlopesProblem tsp = new TreeSlopesProblem();
            //int[] treesHit = new int[5];
            //treesHit[0] = tsp.traverseMap(1, 1);
            //treesHit[1] = tsp.traverseMap(3, 1);
            //treesHit[2] = tsp.traverseMap(5, 1);
            //treesHit[3] = tsp.traverseMap(7, 1);
            //treesHit[4] = tsp.traverseMap(1, 2);

            //long prod = 1;
            //foreach (int value in treesHit)
            //{
            //    prod *= value;
            //}

            //Console.WriteLine("you will hit " + prod + " trees!");

            ////Day 3 Solution 1
            //TreeSlopesProblem tsp = new TreeSlopesProblem();
            //int treesHit = tsp.traverseMap(3, 1);
            //Console.WriteLine("you will hit " + treesHit + " trees!");

            ////Day2 Solution 2
            //PasswordDebug pd = new PasswordDebug();
            //int solution = pd.analizePasswords();
            //Console.WriteLine("Solution is: " + solution);


            ////Day 1 Solution 2
            //FirstDay firstDay = new FirstDay();
            //ArrayList listOfAddents = firstDay.findSumPositions(CURRENT_YEAR);
            //int day1Solution = firstDay.generateArraylistProduct(listOfAddents);
        }

    }




}


