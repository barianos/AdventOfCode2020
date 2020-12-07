using System;
using System.Collections.Generic;
using System.Text;


/*
 * "THE BEER-WARE LICENSE" (Revision 42): Anastasios Barianos wrote this file. 
 * As long as you retain this notice you can do whatever you want with this stuff. 
 * If we meet some day, and you think this stuff is worth it, you can buy me a beer in return. 
 * Anastasios Barianos
 */

/***
 *  For the problem presentation scroll to the end of the file.
 *  This file covers the solution to Day 5 puzzles
 */

namespace Advent_Of_Code
{
    /// <summary>
    /// This class implements all methods that are needed to solve the two puzzles of day 5 of Advent of Code 2020
    /// </summary>
    /// <remarks>
    /// For this particular one, the "smart" solution is to utilize binary numbers, since the problem is given as a BSP
    /// However I also played around with a more literal interpretation of the problem, and got myself a second solution.
    /// Both solutions return the same value. 
    /// </remarks>
    //TODO: Check speed of the two implementations and compare stats.
    class SeatLocation
    {
        /*********
         * 
         * Part 2
         * 
         */

        //I want a more elegant way
        public int getMySeat()
        {
            int retv = 0;
            List<int> decimalSeats = transformBinaryToDecimal(GetBinaryArray());
            decimalSeats.Sort();

            Console.WriteLine("Size: " + decimalSeats.Count);
            List<int> checkSeats = new List<int>();
            for (int i = 35; i < 886; i++)
            {
                checkSeats.Add(i);
            }
            checkSeats.Sort();

            for(int i= 0; i< checkSeats.Count; i++)
            {
                if(checkSeats[i] != decimalSeats[i])
                {
                    Console.WriteLine(checkSeats[i]);
                    break;
                }
            }

            //foreach(int seat in decimalSeats)
            //{
            //    Console.WriteLine("Seat: " + seat);
            //}
            //Console.WriteLine("min: " + decimalSeats.IndexOf(1));
            //Console.WriteLine("max: " + decimalSeats.IndexOf(decimalSeats.Count));

            return retv;
        }

        private List<int> transformBinaryToDecimal(List<string> binary)
        {
            List<int> numbers = new List<int>();
            foreach (string number in binary)
            {
                numbers.Add(Convert.ToInt32(number, 2));
                
            }
            return numbers;
        }


        /**********
         * 
         * Binary Method 
         * Since the codification is based on Binary Space Partitioning
         * each given string is a repreentation of the code in binary
         * thus, we have to transform the representation into binary, 
         * and then transform the binary into decimal numbers.
         * 
         */
        public int getLargestID()
        {
            int maxID = 0;
            List<string> binarySeats = GetBinaryArray();

            foreach (string seat in binarySeats)
            {
                int decimalCode = Convert.ToInt32(seat, 2);
                if (maxID < decimalCode)
                {
                    maxID = decimalCode;
                }
            }
            return maxID;
        }



        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                switch (c)
                {
                    case 'B':
                        sb.Append("1");
                        break;
                    case 'R':
                        sb.Append("1");
                        break;
                    default:
                        sb.Append("0");
                        break;
                }
            }
            return sb.ToString();
        }

        private List<string> GetBinaryArray()
        {
            List<string> entries = new List<string>();
            foreach (string seat in input)
            {
                entries.Add(StringToBinary(seat));
            }
            return entries;
        }

        public int findMaxID()
        {
            int maxID = 0;
            List<int> ids = findAllIDs();

            foreach (int id in ids)
            {
                if (id > maxID)
                    maxID = id;
            }
            return maxID;
        }


        private List<int> findAllIDs()
        {
            List<int> seatIDs = new List<int>();
            int row = 0, column = 0;
            foreach (string seat in input)
            {
                char[] bsp = seat.ToCharArray();
                int rangeMin = 0, rangeMax = 127;
                
                for(int i =0; i< 6; i++)
                {
                    switch (bsp[i])
                    {
                        case 'F':
                            rangeMax = getMiddle(rangeMin, rangeMax,false);
                            break;
                        case 'B':
                            rangeMin = getMiddle(rangeMin, rangeMax,true);
                            break;
                        default:
                            Console.WriteLine("Unexpected Row Error!");
                            break;
                    }
                }
                row = rangeMax;
                if (bsp[6].Equals('F')){
                    row = rangeMin;
                }

                rangeMin = 0;
                rangeMax = 7;
                for (int i =7; i<9; i++)
                {
                    switch (bsp[i])
                    {
                        case 'L':
                            rangeMax = getMiddle(rangeMin, rangeMax,false);
                            break;
                        case 'R':
                            rangeMin = getMiddle(rangeMin, rangeMax,true);
                            break;
                        default:
                            Console.WriteLine("Unexpected Column Error!");
                            break;
                    }
                }
                column = rangeMax;
                if (bsp[9].Equals('L'))
                {
                    column = rangeMin;
                }
                seatIDs.Add((row*8) + column);
                row = column = 0;
            }

            return seatIDs;
        }

        private int getMiddle(int min, int max, bool isUp)
        {
            int retv = max - min;
            retv = (retv/2) + min;

            if (isUp)
            {
                retv++;
            }
            return retv;
        }

        /// <summary>
        /// This array is the input given for me
        /// </summary>
        private string[] input = {
        "BFFBFBBRLR",
"FFFFBBBLRR",
"FFFFBBFLRL",
"BFFBBFFLRR",
"BFFBFBBLRR",
"FBBBBBFLLR",
"BBFFBFFRRR",
"BFFBBBBLLL",
"BBFFFBFRLL",
"BFBFFBBRRR",
"FFFBBBFLLR",
"BFFFBFBRRR",
"FBFBFFFRLR",
"BFFBFBBRLL",
"FFBBBFBRRR",
"BBFBFBBRRR",
"BFFBFFFLLL",
"FBBFFBBRLL",
"FBFFBFBRRR",
"BFFFBFBRLL",
"FBFBBFBRRL",
"FBFFBFBRLL",
"FBFFFFBLRR",
"BFBBBFBLLR",
"FFBBBBBLRR",
"BFBBBFBRRR",
"FFBFBBFLLL",
"BFFFFFBLRL",
"FBBBBFBRRR",
"FBBBFBFLRL",
"BBFFFFFRLR",
"BBFFBFBLLL",
"BBFBBFFRLL",
"FBBFFBFRRL",
"BFBBFFFRLL",
"BFFBFFBLRL",
"BFBBBBFLLR",
"BBFFFFBLLR",
"FBBBFBBRLR",
"BFFFBFFLLR",
"BFBBFBFRLL",
"FBBBBFBLLL",
"FBFBBBFLLL",
"FFFBBBBRLR",
"FBBBFFBRLL",
"BBFFBFBLRR",
"FBFFBFFRRL",
"FBBBFFFLLR",
"FBBFFFFRLR",
"BFBFFBFLLR",
"FFBFBBBRRL",
"FBBFFBBLLL",
"FFBFFBBRLL",
"FFBBFFFRRR",
"FBBFBFBRRR",
"FBBFFFFLLR",
"FBFBFBFLLL",
"BFBFFFBLRL",
"FFBBBBFLRR",
"FFBFFFFLRR",
"FBFBFFBRRR",
"FFFBBBFRRL",
"FBBBFBBLRL",
"BFFBBBFLLL",
"FFFBFBFRLR",
"BFBFBFBLLL",
"FBBBFFFRRL",
"FBBBBFFRLR",
"FFBFFBFLRR",
"BFBFFBFLRL",
"BFFBFBFRRR",
"BFBFFBFRRR",
"BBFFBBFLRL",
"BFFFBBBLLL",
"FBFFBBBLRL",
"FFBBFBBLRL",
"BFBBFFBRLL",
"FFBFFFFRRL",
"FBFFBBBRLL",
"FBBFBFBRLL",
"BBFBFBBRLR",
"FBFFFBFLRR",
"BFBBFFFLRR",
"BFBBBFFRRR",
"FFBFFBBRLR",
"BFBBBBBRRL",
"FFBFFBFLRL",
"FFFFBFFRLL",
"FBFBBBBRLL",
"FBFBBFFLLL",
"FFBBFBFRLR",
"FBBFFBBRLR",
"BBFFFBBLLR",
"FBBFFBBRRL",
"FFBFFBBRRL",
"BFFFFBBRLL",
"FBFBFFBRLR",
"FFFBFFBRRL",
"BFFBFFFRLL",
"FFBBBFFLLL",
"FBFFFBFRRR",
"BFBFBBFRRR",
"BFBFFBFLLL",
"FBFBBFFLLR",
"FBBBFFBLRL",
"FFBFFFFLLR",
"FFFBBBFRLR",
"FBBFBFFRLL",
"FFBFBFBLRL",
"BFBFBBBLRR",
"BBFBBBFLLR",
"FFFBBFBRRL",
"FBFBBFBLRL",
"BFFFBBBLRL",
"FFFBFFBRRR",
"FBBBFFFLRL",
"FBBBBBBRRL",
"BFBBBBBRRR",
"FFBFBBFRLL",
"FFBBBBFRRR",
"FBBFFBFLRL",
"FBBBBFBLLR",
"BBFFBBFLLL",
"FBBBBFBLRR",
"BFFFFFFLRL",
"FBBFFFBRLL",
"BBFFFBBLRL",
"FFBBFFFRLL",
"BFBBFBBLLR",
"BFBFBBBRLR",
"BFFFFBFLRR",
"FFBBFFBRRR",
"BFFFBBBRRL",
"FBFFBBBLRR",
"FFFFBFFLRR",
"FFBBFBFLLR",
"BFBBFFBLRL",
"BFFBFFFLLR",
"FFBBBFBLLL",
"BBFFFBBRLR",
"FBBBFBBRLL",
"FBFFBBFRLR",
"BBFBFBBLLR",
"BFBFFFBLLL",
"BBFBBFFLRR",
"BFBBFBFRRL",
"FFFBBFBRRR",
"BFBFBBFLLL",
"FFFFBFBRLL",
"FBFFFFBRLL",
"FBBFFBBLLR",
"FBBBFFBLRR",
"FBFFFFFLLL",
"BBFBFFFLLR",
"BFFFBBFLRR",
"FBBBBFFRRL",
"BFFBBBBLLR",
"FFBBFBBLLR",
"BFFBBBBRRR",
"BFFBFFBRRL",
"BBFBBFBLRL",
"FFBFFFBRRL",
"BBFBBFBLLL",
"FFBFBFBLLR",
"FFBBFBFRRL",
"BFFFFFBRLL",
"FBBBBBBRLL",
"FBBFBBBLLR",
"FFFFBBFRRR",
"FBBBFBFLLL",
"FBFFBFBRRL",
"BBFFFFBRLL",
"FBBBBFBLRL",
"BBFFBBBRRL",
"BFFBFFFRLR",
"FFBFBFFLLL",
"FFBBBBFLRL",
"BFFBBBFRRR",
"BFFBFFBLLL",
"FFBFFBBLRL",
"FBFFBBFRLL",
"FBFBBBFRRR",
"FBFFBFFLLR",
"BBFFBBFRRL",
"BFBFFBFRLR",
"FBBBFFBRRR",
"FFFBBBFRRR",
"BFFBBFBLRL",
"BBFFFBFLRL",
"FBBFFBBLRL",
"FBFBBFFRLR",
"BFFBBBFLRR",
"BBFFFFBLLL",
"BBFBBFBLLR",
"FFBBBBBRRR",
"FBFBFFFLRR",
"FBFBFFFLLR",
"FFBFFFBLLR",
"FFBFFBFRLR",
"BFFBFBBRRR",
"BBFFFBBLRR",
"BFBFBFFRLR",
"FFBBBBFLLR",
"FFBBFFBLRR",
"BBFBBFFRLR",
"BBFFFBFLLR",
"BBFFBBBLRL",
"BFFBBFBRRL",
"FFFBFBBLLR",
"BBFFBFFRLR",
"BFFFFBBLLR",
"FBBFBFFLLR",
"FFFFBFBRLR",
"FBBFFFFLLL",
"BFBFBBFRLR",
"BFFBFFBRLR",
"FFFBFFFLLR",
"FFBBBBFRLR",
"FBBBFBBLLL",
"FFBFBFBRRR",
"FBFFFBBLRR",
"BFBBFFFLRL",
"FBFFBFBRLR",
"BFBFFBFLRR",
"BBFFFBFLLL",
"FFBFFBBLRR",
"BFBFFFFRRR",
"BFFFBBBRLL",
"BBFBBFBLRR",
"FFFFBFBRRL",
"BFFBBFFRLL",
"FBFFBBBRRL",
"BBFFFFFLRL",
"BFFBBBFRLR",
"BFFFBFFRRL",
"BFBFFFBRLR",
"FFFBFBFLLL",
"BFBFFBBLLL",
"FBFBBBFRLR",
"FBFFBBFLLL",
"BFBFBBBLRL",
"FFBFBFBLRR",
"BFBBBBBLLL",
"BFFBBBBRRL",
"FFFFBBBRLR",
"BFBFBBFLLR",
"FBBBBBFRRR",
"FBBFBFFRLR",
"BBFBBFBRRL",
"FFBFBBBLRL",
"BFBFBFBLRL",
"FBFBBBFLRL",
"FBFBBBBLLL",
"FBFBBBBRRR",
"FBBFBFBLLR",
"FBFBFBBRLR",
"FFBFFFBLRR",
"BFFBBFBRLL",
"BFFBFBBLLL",
"FBFBFFBLRL",
"BFFFFFFRLR",
"BBFFFFFRLL",
"FFBFBFBRRL",
"FBBFFBFRRR",
"BFFFFBBLRL",
"FBBFBBFLRL",
"FBBFBBFRLL",
"BBFBFBBLRR",
"FBFBFBBLRL",
"BFBBBFFRLL",
"FBBBBBBLLL",
"FBBBBBBLRR",
"BBFFBFBRRL",
"FBFBFBFRRR",
"FBBFBFFRRR",
"BBFBBFFRRR",
"FFBFBBFLRL",
"FFBFBBBRRR",
"BFFFFFFLRR",
"BFBFFBBLRR",
"BFBFBFBRLL",
"FBFBBBBLLR",
"BFFFFBBLLL",
"FBBFFFBLLR",
"BFBFBFBRLR",
"BBFFFFBLRL",
"BFBFBBBLLR",
"FFFBBBBRRL",
"FBFFFBFRLL",
"FBBFBBBLRL",
"BFBFFBBRLR",
"FBBFFFBLRR",
"FBBBBBFRLL",
"BBFBFFBLRL",
"BFFFBFFRLL",
"FBFBFFBLLR",
"BFFFFFBRRR",
"FBBFBBBRRL",
"FFFBBFFRRR",
"BFBBFBFLLL",
"BFFBBFBRLR",
"FFBBBBBLLL",
"FBFFBBBRLR",
"FFFBFFBRLR",
"BFBFFFFLRR",
"BFFFBFFLRR",
"BFFFFBBRLR",
"FBFBBBFLLR",
"BFFBFBBRRL",
"FBBFBBBRLL",
"FBBFBBFRLR",
"FFBFBFFLRR",
"FFFBFFFLLL",
"BFBFBFFLLL",
"FFFBFBFRRR",
"BFFBFFFLRL",
"FFBFBFBLLL",
"BFFFBFFLRL",
"BFBBBFFLRL",
"FFFFBFBLLL",
"FBBBBFFLLR",
"FBFBBFBRRR",
"FFFBBBBLRR",
"BBFBBFFLRL",
"FBFFBFFRLR",
"FFFBFBBLRL",
"BBFBFBFLLR",
"FFBFBFFRRL",
"BFFFFBFRLL",
"FFBFBFFLRL",
"FBBBBFBRLR",
"FBFBFFFRRR",
"BFBBBBFRRL",
"BBFFFFBLRR",
"FFFFBFBRRR",
"FFFBFFFRRR",
"BFBBBFFLLR",
"BBFBFBFRLR",
"FFFBFBBLLL",
"FFBFBBBRLR",
"BBFFBFBLRL",
"FFBFFFBLLL",
"FBFFFFFLRR",
"FBBFBBBRLR",
"FBFFFBBLLR",
"FFBFBFBRLR",
"FFBBFBFLRL",
"FBFBFBBLRR",
"FBBFFBFLRR",
"BBFFBBBLLR",
"FFFBFFFRRL",
"FFBFFFFRLL",
"BFBFBFFRRL",
"FBFBBBFLRR",
"FFBBFBBRRL",
"BFBBBFBLRL",
"FFFFBFFRLR",
"FFFBBBBLLR",
"FBBBFFFLLL",
"BFFBFFFRRR",
"FFFFBBBLRL",
"BFFFBBFLLR",
"FBFBFFFLRL",
"BFFFFBFLRL",
"FBFFBBBLLL",
"FFBBBFFRLL",
"BFBFFFBRRL",
"BFFFFFBLLR",
"FFBFBBFRRR",
"FBFBFBFRLR",
"BFBFBFFLLR",
"BFBBBBBLRL",
"FFFBBFFLRL",
"FBFFBFFRLL",
"FFFFBFFRRR",
"FBFFFBFLLL",
"BBFBFBFRLL",
"FBBFBFBLLL",
"FBFFFBBRRR",
"FFBBBFFRRL",
"FBBFBBFLRR",
"FBBBFFBRLR",
"FFFBBFFRRL",
"FFFBFFFRLR",
"FBFFBFBLLL",
"FFBFBFFRRR",
"BFFBBBBRLR",
"BBFFBBFLLR",
"BBFBFFBRLR",
"FBBFBBFLLL",
"FBBFBBFRRL",
"BBFBBFBRLL",
"BFFFFBFRRL",
"FBFBBFFRRR",
"BFFFFBFLLL",
"BBFFFBFLRR",
"FBBBFBFRLR",
"FFFBFFBLRR",
"FBBFBBFLLR",
"FBBFFFFLRR",
"BFBBBBFRRR",
"FBFFFFBRLR",
"FBBBBBFLRL",
"BFBFFBBLRL",
"BFBBBBFLRL",
"FBFBFBBRRR",
"FFFFBBBRRR",
"FBBFFFBRRL",
"FBFFBFFLRL",
"FFBFFFBRRR",
"BFFBBFFLLR",
"FBBBBBFRRL",
"FBBBFBBRRL",
"FFFBFBBRLL",
"BBFFBFBRRR",
"FBFBFBFLRL",
"FBBFFBFLLR",
"FFBFFFFRRR",
"BFFBBFFLLL",
"BFBBBFFLRR",
"FFBFBBFRLR",
"BBFFBFFLLL",
"BBFBFBFRRR",
"BFFBFFBRRR",
"BBFFBBBRLR",
"BFBFBBBRLL",
"BBFBFFFRLR",
"FFFFBBBLLR",
"FBBFBFBRLR",
"FFBBFBBLRR",
"FBFFFBBLRL",
"BBFFBFBRLL",
"BFFBFFFRRL",
"FFBBBBBRRL",
"FBFFFFFRLR",
"FFBFFFBRLR",
"FFFBFBBRRR",
"BFFBFBBLLR",
"FFFBBFFRLL",
"BBFFBFFLRL",
"FFFBBFFLLR",
"BFFFBFBLRR",
"FBBFBFBLRL",
"BFBBFFFRRR",
"BFBBBFBLRR",
"FFBBBFBRRL",
"FFBBBBFRRL",
"FFBFFFBLRL",
"BFBFBBFLRL",
"BFFBBFFRLR",
"FFBBBFFLRL",
"BFBFFFBLRR",
"FFFBBFBLRL",
"FFFBFFBLLL",
"BFBFBFBLRR",
"FBFBBFBRLR",
"BBFFBBBRRR",
"FFFBFBBRLR",
"BFFBBFFRRL",
"BFBBBBBRLL",
"BBFBFFFLRL",
"FFFFBFBLRL",
"BFBBFBFLLR",
"FBFBFFFRLL",
"BFBBFBFLRR",
"FBFBFBFLRR",
"BBFFFBFRRL",
"FFFFBFFRRL",
"FBFBFFBLRR",
"BFBFBFFLRR",
"FFFBBBBLLL",
"BBFBBFBRRR",
"BFFBBBFLRL",
"BBFFBFBLLR",
"BFBBFBBLLL",
"FFFBFBFRRL",
"FBBBFBBRRR",
"FFFBBFFLLL",
"BFBBBFBLLL",
"FBFFBFBLRL",
"BBFFFFBRRL",
"BBFFBFFLRR",
"FBFFFFBRRL",
"FBBFFBFRLR",
"FBFBBBBLRR",
"BBFFBBBLLL",
"BBFFFFFLLR",
"FBFFBBFRRR",
"FBBFFBFLLL",
"FBFFBFBLLR",
"BBFFFFBRRR",
"FBFFFBFRLR",
"BFBFBFBRRR",
"BFBBBFFLLL",
"FBBFFBBRRR",
"FFBBFBBRLL",
"FFBBFBBRRR",
"BBFBFFFLLL",
"FBFFBBFRRL",
"BFFFBFBLLR",
"FBFBBBFRRL",
"FBFBFBBRRL",
"FBFFBBBRRR",
"BBFBFBFLLL",
"FFBBFFFRLR",
"FBBFFFBLLL",
"FFBFFBBRRR",
"BFFFBBFLLL",
"FBFBFBBLLL",
"FBBFFFFRRL",
"FFBBFBFRLL",
"FBBBBBFRLR",
"BFBBFBBLRL",
"BFFFFBFRLR",
"BFFFFFFRRR",
"FBFBBFFLRL",
"FFBBFFBLRL",
"FBBFFFBLRL",
"FBBBBFFRLL",
"BBFBFFFRLL",
"FBFFFFFRLL",
"FFBFFBBLLL",
"FBFFFFBLRL",
"BFBFBBBLLL",
"BBFBBFBRLR",
"BBFFFBFRRR",
"FBBFBFBRRL",
"BFFBFFFLRR",
"BFBBFFBRRR",
"BFBBBFBRLL",
"BFBBBFFRRL",
"FBFBFBFLLR",
"FFBFBFBRLL",
"FFBBBFFLLR",
"BFBFBBBRRR",
"BBFFBFBRLR",
"FFBBBFBRLL",
"FFFBBFFLRR",
"BFBFFFBLLR",
"FFBFBBFRRL",
"BBFFBBFRLR",
"BBFBFBBLLL",
"FBFBBFBLRR",
"BBFBFBFLRL",
"FBBFFFBRRR",
"FBFBBFFRRL",
"FBBBFBFRRR",
"BFFFFFFRRL",
"BBFFFFFRRR",
"BFBBBFBRLR",
"BBFFFBBRRR",
"FBFFFFFRRR",
"BBFFFFFLRR",
"FFFBFBBRRL",
"FFBBBFBRLR",
"FFFBFFBLRL",
"FFFBBBBRLL",
"FBFBBBBLRL",
"BFBBBBBRLR",
"FBFBFFBRRL",
"BFBBFFBLLR",
"BFFFFFBLLL",
"BFBBBBFLRR",
"FFBFBBBLLR",
"BBFBBFFLLR",
"BFBFFBFRLL",
"FBBBBFBRRL",
"FBFFFBFLRL",
"FFBBFFBLLR",
"BFFBFFBLLR",
"FFBBBFBLRL",
"FBBBBFFLRR",
"BFFBFBFLRL",
"BFFBFFBLRR",
"FFBFBBBLLL",
"FBFBFFBRLL",
"FBBBFFFRRR",
"FBBBBBBLRL",
"FFBFFBFLLL",
"BBFFBFFRRL",
"FFFBBBFLRL",
"BFBBFBBRLR",
"FFFBFBFLRR",
"FBBBFBFRLL",
"BFBBFFFLLR",
"FBFBFFFLLL",
"BFFBBBFLLR",
"BBFBFFBRRL",
"FFBBBBBLLR",
"FFFBBBFLRR",
"BFBFBBBRRL",
"BFFFFFBRRL",
"FBFFBBBLLR",
"BBFBBBFLRR",
"BFFBBBBLRR",
"BBFBFFFLRR",
"FBBBFBFLLR",
"BBFFBFFRLL",
"FFBBFFFLRL",
"BBFBFFBLRR",
"BFFBBFBLLR",
"BFBBBBBLLR",
"BFFFBBFRLL",
"FBFBBBBRRL",
"FFBFBFFLLR",
"BFFFBFBLLL",
"FFFBBBFRLL",
"FBFFBBFLLR",
"FFFBBFBRLL",
"BFBFFFBRLL",
"BFFFBFFLLL",
"BBFFFFBRLR",
"FBBFFBBLRR",
"BBFFBBBRLL",
"BFBFFFFRLL",
"FBBBBBBRLR",
"FFFBFFBLLR",
"FFFBBBBRRR",
"FFFBBBBLRL",
"FBBBFFBLLR",
"BFBFBFBRRL",
"FFFFBBFRLR",
"FFBFFBFLLR",
"FFFFBBBRRL",
"FBBFFFFRLL",
"BFFBBBFRRL",
"FFFFBBFRRL",
"BFBFFBBRLL",
"FBFFFFFLRL",
"FFFBBFBLRR",
"FBFFFBFRRL",
"BFBFFBBLLR",
"FFFFBBFLLL",
"FBFFFBBRRL",
"BFFBBBFRLL",
"BFFFBFBRLR",
"BBFBFBBRLL",
"FBFBFBBRLL",
"BFBFFFBRRR",
"BFFFBBBLRR",
"FFBFBFFRLL",
"BFBBFBFRRR",
"BBFBBFFRRL",
"BBFFFBBLLL",
"FBFBFFBLLL",
"FBFFFFBLLR",
"FBFBBFFRLL",
"BBFBBBFLLL",
"FFBFBBFLRR",
"BFFBFBFLLR",
"BFFBBBBLRL",
"FFBFBBBLRR",
"FBBBFFFRLL",
"FFBFFFFLLL",
"FBFFFFBLLL",
"FBBBBBBRRR",
"BFBFFBBRRL",
"FFBBFFFLLL",
"FFBBBFBLRR",
"FFBBBBBLRL",
"BBFFBBFRLL",
"FFBBFBFLLL",
"BFFFFFFLLL",
"BFBBFBFRLR",
"BBFFFFFRRL",
"FFBBFFFRRL",
"FFFFBFBLRR",
"BFFFBBBLLR",
"FBFFBFFRRR",
"BFBFFFFLLL",
"FBBFBFFLRR",
"FFBBBFFRRR",
"FBBBFFFRLR",
"FFFFBBFLRR",
"FBFBFBBLLR",
"BFFFFFBRLR",
"BFFBFBFRLR",
"FBFFBFBLRR",
"FBFFFBFLLR",
"FBFFBBFLRR",
"FFBBFBBRLR",
"BFFFBFBRRL",
"BFBBFBBRLL",
"BBFFFFFLLL",
"FFBBBBBRLR",
"BBFBFFBLLL",
"BBFFFBBRLL",
"BBFBFFBRLL",
"BFFBFBFRRL",
"FFBFFBFRRL",
"BFBBFFBRRL",
"BFFFFFFRLL",
"FFBBBBFRLL",
"FFFBFBFLRL",
"FBBBBFFLLL",
"BBFBBFFLLL",
"BFFFFBBRRL",
"BFFFBFBLRL",
"FFFBFBBLRR",
"BFFFBFFRRR",
"FFBBBFFRLR",
"BFBFBBFRRL",
"BFFBBFFRRR",
"BFFBBFFLRL",
"FBBBBFBRLL",
"FFFFBBFLLR",
"BFBFFFFRLR",
"BBFFBFFLLR",
"BBFBFFBLLR",
"FFFBBFBLLL",
"BFBFBFFRRR",
"FBBFBFFLRL",
"BFFBFBFRLL",
"FFBBFFBLLL",
"FBBBBFFLRL",
"FFBBFFFLLR",
"FFFBBFBLLR",
"BFBBFFFLLL",
"BFFBFBFLLL",
"BFFBBFBLRR",
"BFFBFBFLRR",
"FBBFFFFRRR",
"BFBBFFBRLR",
"BFFFBBFRRR",
"BFBBBFBRRL",
"FFBBFBBLLL",
"FBBBFBBLLR",
"BBFBFBBRRL",
"FFBFFBFRLL",
"FFFFBBFRLL",
"BBFFBBFLRR",
"FBFBFBFRRL",
"FBBBFBBLRR",
"FBFFBFFLRR",
"FFFBFBFLLR",
"FBBFBFFRRL",
"FBFFFBBRLL",
"FFBFFBBLLR",
"FFBFBFFRLR",
"FFBFBBBRLL",
"FFFBFFFLRL",
"FFFBBFFRLR",
"FBFBBFBRLL",
"BFFFBBFLRL",
"BFBBFBBRRR",
"FBBFBBFRRR",
"FFBBFBFRRR",
"BFFBFBBLRL",
"FFFFBBBLLL",
"BFFFFFBLRR",
"FBBFBBBLRR",
"FBBBBBFLLL",
"FFBFFBFRRR",
"BBFFBBFRRR",
"FFBFBBFLLR",
"FFBBBFFLRR",
"BFFFBBFRRL",
"BFBFBFFLRL",
"BFBBFBFLRL",
"FFBBFBFLRR",
"FFFBBFBRLR",
"FBFBBBBRLR",
"BFFFBBFRLR",
"FFFBFFFLRR",
"BFBBFFFRRL",
"BFBBBBBLRR",
"FBFFFFBRRR",
"FBBFBBBLLL",
"FFFFBBBRLL",
"BBFFFBBRRL",
"BBFBFFFRRR",
"FFBFFFFRLR",
"FFBBFFBRLL",
"FBFFFBBLLL",
"BBFBFBFLRR",
"FBBBFBFLRR",
"BFBFBFFRLL",
"BBFBBBFLRL",
"FBFFFFFLLR",
"BFBFBFBLLR",
"BBFBBBFRLR",
"BFBBBFFRLR",
"FFBBFFFLRR",
"FBFFFBBRLR",
"FFBFFFBRLL",
"BFBBFBBRRL",
"FFBBFFBRLR",
"BFBBFFBLLL",
"FFBBBBFLLL",
"BBFBFFFRRL",
"FBFBBBFRLL",
"FBFBBFFLRR",
"FBBFBFFLLL",
"BFBFFBFRRL",
"FBFBFFFRRL",
"BFBFBBFRLL",
"BFFFBFFRLR",
"FBFBFBFRLL",
"BFBBFBBLRR",
"FBBFBFBLRR",
"BFFBFFBRLL",
"FFFBFFFRLL",
"FFBFFFFLRL",
"FBBBFFFLRR",
"FFFBFFBRLL",
"BFFFBBBRLR",
"FBFBBFBLLR",
"BFBBBBFRLL",
"BBFFBBBLRR",
"FBFFFFFRRL",
"BFBFFFFRRL",
"FBBBBBBLLR",
"FBBFFFBRLR",
"FBBBFFBLLL",
"BBFBBBFRLL",
"BFFBBFBLLL",
"BFFFFFFLLR",
"FBBFBBBRRR",
"BFFFFBBLRR",
"BBFFFBFRLR",
"FFFBBBFLLL",
"BFFBBBBRLL",
"BFBBBBFLLL",
"BFBFBBFLRR",
"BFBFFFFLLR",
"BBFBFBFRRL",
"FFBBFFBRRL",
"BFBBBBFRLR",
"FBBBFFBRRL",
"BBFBFBBLRL",
"BFBBFFBLRR",
"FBBFFFFLRL",
"FBBBBFFRRR",
"FFBBBFBLLR",
"FBBFFBFRLL",
"FBFBBFBLLL",
"FFFFBFBLLR",
"FBBBFBFRRL",
"FBFFBBFLRL",
"BFBBFFFRLR",
"BFFFFBBRRR",
"FFBBBBBRLL",
"BFFFBBBRRR",
"FBBBBBFLRR",
"BFFFFBFRRR",
"BFBFFFFLRL",
"FFFBFBFRLL",
"BFFFFBFLLR",
"BBFBFFBRRR",
"FBFFBFFLLL"};
    }
}



/* 
 * 
 * 
 * --- Day 5: Binary Boarding ---

You board your plane only to discover a new problem: you dropped your boarding pass! You aren't sure which seat is yours, and all of the flight attendants are busy with the flood of people that suddenly made it through passport control.

You write a quick program to use your phone's camera to scan all of the nearby boarding passes (your puzzle input); perhaps you can find your seat through process of elimination.

Instead of zones or groups, this airline uses binary space partitioning to seat people. A seat might be specified like FBFBBFFRLR, where F means "front", B means "back", L means "left", and R means "right".

The first 7 characters will either be F or B; these specify exactly one of the 128 rows on the plane (numbered 0 through 127). Each letter tells you which half of a region the given seat is in. Start with the whole list of rows; the first letter indicates whether the seat is in the front (0 through 63) or the back (64 through 127). The next letter indicates which half of that region the seat is in, and so on until you're left with exactly one row.

For example, consider just the first seven characters of FBFBBFFRLR:

    Start by considering the whole range, rows 0 through 127.
    F means to take the lower half, keeping rows 0 through 63.
    B means to take the upper half, keeping rows 32 through 63.
    F means to take the lower half, keeping rows 32 through 47.
    B means to take the upper half, keeping rows 40 through 47.
    B keeps rows 44 through 47.
    F keeps rows 44 through 45.
    The final F keeps the lower of the two, row 44.

The last three characters will be either L or R; these specify exactly one of the 8 columns of seats on the plane (numbered 0 through 7). The same process as above proceeds again, this time with only three steps. L means to keep the lower half, while R means to keep the upper half.

For example, consider just the last 3 characters of FBFBBFFRLR:

    Start by considering the whole range, columns 0 through 7.
    R means to take the upper half, keeping columns 4 through 7.
    L means to take the lower half, keeping columns 4 through 5.
    The final R keeps the upper of the two, column 5.

So, decoding FBFBBFFRLR reveals that it is the seat at row 44, column 5.

Every seat also has a unique seat ID: multiply the row by 8, then add the column. In this example, the seat has ID 44 * 8 + 5 = 357.

Here are some other boarding passes:

    BFFFBBFRRR: row 70, column 7, seat ID 567.
    FFFBBBFRRR: row 14, column 7, seat ID 119.
    BBFFBBFRLL: row 102, column 4, seat ID 820.

As a sanity check, look through your list of boarding passes. What is the highest seat ID on a boarding pass?

Your puzzle answer was 885.

The first half of this puzzle is complete! It provides one gold star: *
--- Part Two ---

Ding! The "fasten seat belt" signs have turned on. Time to find your seat.

It's a completely full flight, so your seat should be the only missing boarding pass in your list. However, there's a catch: some of the seats at the very front and back of the plane don't exist on this aircraft, so they'll be missing from your list as well.

Your seat wasn't at the very front or back, though; the seats with IDs +1 and -1 from yours will be in your list.

What is the ID of your seat?

 * 
 * 
 * 
 */
