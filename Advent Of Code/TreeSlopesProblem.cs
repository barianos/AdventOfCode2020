﻿/*
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
    /// This class implements all methods that are needed to solve the two puzzles of day 3 of Advent of Code 2020
    /// </summary>
    class TreeSlopesProblem
    {
        private char[,] map;

        public TreeSlopesProblem()
        {
            map = createMap();
        }

        private char[,] createMap()
        {
            char[,] newMap;
            char[] firstRow = input[0].ToCharArray();
            newMap = new char[firstRow.Length, input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                char[] row = input[i].ToCharArray();
                for (int j=0; j< row.Length; j++)
                {
                    newMap[j,i] = row[j];
                }
            }
            return newMap;
        }


        public int traverseMap(int right, int down)
        {
            int retv = 0;
            int x = 0, y = 0;
            int columns = map.GetLength(0);
            int rows = map.GetLength(1);
            while (y < rows)
            {
                char test = map[x,y];
                if (test == '#')
                {
                    retv++;
                }
                int temp = x + right;
                if (temp >= columns)
                {
                    x = temp - columns;
                }
                else
                {
                    x += right;
                }
                y += down;
            }

            return retv;
        }


        string[] exampleInput =
        {
            "..##.......",
            "#...#...#..",
            ".#....#..#.",
            "..#.#...#.#",
            ".#...##..#.",
            "..#.##.....",
            ".#.#.#....#",
            ".#........#",
            "#.##...#...",
            "#...##....#",
            ".#..#...#.#"
        };

        /// <summary>
        /// This array is the input given for me
        /// </summary>
        string[] input = {".#.#....##.......#..........#..",
                "...#...........##...#..#.......",
                "#.####......##.#...#......#.#..",
                "##.....#.#.#..#.#............#.",
                "##.....#....#.........#...##...",
                "###..#.....#....#..............",
                "..........#..#.#..#.#....#.....",
                "##.....#....#.#...#.##.........",
                "#...#......#....##....#..#.#...",
                ".##.##...#....##..#.#.....#...#",
                ".....#.#..........##.#........#",
                ".##..................#..#..##.#",
                "#.#..........##....#.####......",
                ".#......#.#......#.........#...",
                "#....#..##.##..##........#.#...",
                "##..#.##..#...#..####.#..#.....",
                "###....#.###.##...........##..#",
                ".....#.##.....##.#..#####....##",
                "....#.###....#..##....##...#...",
                "..###.#...##.....#.##..#..#.#..",
                "#...#..#..#.........#..#.......",
                "##..#.#.....#.#.#.......#...#.#",
                "...#...##.#........#...#.......",
                "..#..#.#..#...#...#...........#",
                "........#.....#......#...##....",
                "#........##.##.#.#...#...#.....",
                "####.......#.##.###.#....#.....",
                "...#...........#...#......#...#",
                "##...#...#............#.......#",
                "....#...........##.......#.....",
                "###......#.....#....#...#.#...#",
                ".....##..........#.......#.#...",
                "##.##.##...#......#....#.......",
                "##..#.#..#......#...#..#.......",
                "....#....##.##............####.",
                "..#.###..#.##.###..#.##.......#",
                "#.##..#.#.....#..#.....##......",
                "..##..#.....##.#.##........#...",
                ".#..#.#......#..#............#.",
                ".....#..#.#...#....#.##.#......",
                ".#...##.#..#.#...##...##..##...",
                "###............#.#..#..#...#...",
                "..#..##.####.#.....#.....##.###",
                "#....#.##..##....#..#...#.##.#.",
                ".....#.##.........##...##......",
                ".........####.#....#.#......#.#",
                ".........#.#..#...#.#..#.#....#",
                ".#.....#..##.##..##....#.......",
                "..........##......#.##.###....#",
                ".##...###..##.#...#........##..",
                "..............#.#....#.#.###.##",
                "..##.##.......#.#......##...#..",
                ".#.....#..##..#.###...#..#.##.#",
                "#.....#.#..#...#........#...#..",
                ".#......#....#.#.....###...#..#",
                "..##.#....#..##......#.....#...",
                "..#.#.##..#.....#.####..###....",
                ".........#......#..#...........",
                "..#........#.##.#.....##.##..#.",
                ".......#.........#....#...#.#..",
                ".##.....#.#....#.#.......#.....",
                "..........#.##........##...##..",
                "###..###.#.#..#..#####.##.#.##.",
                "..##..##.#.#...#..#.#.#......#.",
                "#..#..#..#..##..#.....#......#.",
                "..#....#.##..#......##.........",
                "..#.##......#...##.#......#....",
                ".......#..#.##.#.....#.........",
                ".......#.#.#.###...##......#...",
                ".....#.#..........#..#...#.....",
                "....##..........#..........##..",
                "..#......#.....#.##.#..#...#.#.",
                "....#.....#..#...#..#.#.##..###",
                ".####....#........#...#........",
                "...##.#.##.#..#...##...#.##....",
                "....#...#...#.#.#.#...#..#.....",
                ".....#...#.#.....#.#........##.",
                "..#.#.......###.#.....##.......",
                "......#.........##....#....#..#",
                ".............##.....##.........",
                ".........##...##.......#.....#.",
                "##.........#..........#.###..##",
                "...#.....#......#....#..##.....",
                "##..#...#...##.#.....#.#......#",
                "..#...##.#.......#.#......#.##.",
                "......#.......#.#...........#..",
                "..........#.....##............#",
                "#........#...#..#.......###.##.",
                ".##...........#.#........#.#.#.",
                "...#..##...#.#....#####.#......",
                ".....##...###...#..#.##...####.",
                "...#....#.....#..#.......#.....",
                "#....#....#...#..#..#.######..#",
                "#.###...........#......#...#..#",
                ".#.#.#.#..#....#....#...##.#...",
                ".#..#.........#.#....###...#...",
                "......#..##.##..........#....##",
                ".....#......##....##.....#...#.",
                ".#...#.#.#....##....#..#....#.#",
                "..................#..###.#..##.",
                "..#.........#......#....#..###.",
                "#.#.....#..#..#....###..###....",
                "..##..##.#..##........##...##..",
                "##..#........##..###..#.....#.#",
                "..#..###..#......#....#...#...#",
                "#..#.#..............##.#..#.#..",
                ".....####....#...####.....#.#..",
                ".....#....##.#......###........",
                "##.##...#.#.#.#.......#....##..",
                ".#......#...#.#....#..##.#.##.#",
                "#.#.##.#.#......#..##........##",
                "...##.....#.....#...#..###...#.",
                "........###.....#.....#...##..#",
                ".....#.##.##......#.#....#...#.",
                ".#....##.......#..#.####.......",
                ".#..#....#..........#......#.#.",
                ".#.##.##.....###.#.#...........",
                ".........#......#..##..........",
                "....#...##.#.#.#..#.#.........#",
                "..#.....#.##...#..#..#.###....#",
                "...#.##......#.....##....#.....",
                "###............#.#....#...#....",
                ".......#.....#..#.#.#....#..#.#",
                "...#......#.#..##..#....#...#.#",
                "............##........##..##...",
                "..#..#.##..#......###..#.......",
                "........#.........#............",
                "..#...#.#########.#...##..###..",
                "#....#......#.......#.#.....#..",
                "#.#..#....###.###....#...#.#...",
                "#...###.#.#.......#.##......#..",
                ".................#...#.#.#.....",
                "##....#...#........#....#.#..#.",
                "......#.....#...#..........#.#.",
                "##..........#...#..........#.##",
                "..#.#.##.#....#.#......#...##..",
                ".....#.......#..#.....#........",
                "#.##.#..##..#.......##.........",
                "....#......#..#..#.#...#.......",
                "...#....#................###...",
                ".##.....#.#....#.#..........##.",
                "...#..#....#.##.##......#......",
                "..#.#....#.......#.#..##.......",
                "....#.....#..........##.#.#####",
                "#.....................##..#..#.",
                ".###..#.##.......##.#...#..#...",
                "...###.......#..#...#......#..#",
                "#..#...#.#..#.#..#..#.##.......",
                "#...##.......#..#..#.##..###...",
                "......#....#.#.#........#.##..#",
                "..##..#....#....#..#.#..#......",
                "..##.#...#.#######..#...#.....#",
                "..#....#..#.........#..##......",
                "...#....#.#......#..#..#.#.....",
                "#..#....#........#.#..##....###",
                "#....#..##......##.##.....#.###",
                "...#.#..........#..#.#.#.#.##..",
                "......##..#.#..#.#....#....#...",
                "##....#....#..#..#.##......#...",
                "....#.#..##.#.#...###....##.#..",
                "...#.......##..#.......#...#...",
                "......##.......#..##.....#...#.",
                "...#.#...#...........#...#.....",
                ".#....#...#......##.##..###..#.",
                ".#..........#...#...#...##.##..",
                ".....###..#.....#..##....#.####",
                "..#.###..#..##..##.....#.#.....",
                ".............#.###...##.#.....#",
                "....###.......###.#.....#..#.#.",
                "........##.#.........#.....###.",
                ".....###.#..#.....#...#..#.....",
                ".#....#..##.#..#.#....#.......#",
                "........#......#.#..#.#..#...##",
                "...#.##.##......#..............",
                ".#.....##.#.....#..#......##...",
                "#..#..#.....#.....#.....###....",
                ".##...........#..#.##.....#....",
                "..#.#......#.#...#.##.#..#...##",
                "...#..........#.....#..........",
                "#.#.#.#.#...#....#...#.....##..",
                "#......##...#...#..........#.#.",
                "....##........#.#..............",
                "#..#.#.#..#........##......#.##",
                "........####...##.#.....#......",
                "....#........#.#..#..##..#.#...",
                ".#.....#..###...#..#.....#..#..",
                "#......###.#..#....#..#.#......",
                "....#.....##.##..#...#.#..##.#.",
                "..##..#...#.#......#....#...#.#",
                "#..##...##..#...###...#..#.....",
                ".......#.....#...........##....",
                "#..##....#........#....##..#.#.",
                ".#........#..##...###.#..#.....",
                ".#.#....#..##...#...##.#..###..",
                "#.........#.......#.....#.#....",
                "#..#.....#.#.###.#..#......#...",
                "....#..#.#....#..##..###....###",
                "###.##.#.#..#...........#.#.#..",
                "..##.#.......#......#..##....#.",
                ".....#.#.#.......##.......#...#",
                "...........#.##....##.##....#.#",
                "...#.......#..#.##..#......#..#",
                "#.#.#...#......##.#...........#",
                "##........#...........###.#..#.",
                "..........#.#.#....#.#..##.#.#.",
                "...#.#.#....#..........#..#....",
                "#.#....###.#.#..#.......###...#",
                ".#....#......#.#.#..#..#.......",
                "......##.............#....#.#.#",
                ".#..........#.........#.##.....",
                "##....#....##....#..#.......#..",
                "#.##.##.#..#..#.....#..#.##.#..",
                ".#..#.......##..#.....##.##....",
                ".......#..........#.#.##..#.##.",
                "....#.....#.#...##....##.......",
                ".......#.........#...##....##.#",
                "#.....#......#..........#...#..",
                "...#.#.......#.#..#....###..#..",
                ".....#.#.#.........#...........",
                ".#..###.#.#........#.#.........",
                ".........#..#......##...##....#",
                "...###..#.....##.....#.###....#",
                ".##...#...#........###.#..#....",
                ".##........#..#.###.######.##.#",
                "##.#...#.#....#..##.#....##....",
                ".......##.....##.#..###.#......",
                "..##...##........#.......#....#",
                "#..##...#.####...###......#...#",
                ".##.....#.##.#.#.....###.#..##.",
                "..###....#.#.###.#....#........",
                "....#..###..#...#....#..#..#.#.",
                "#.#.##....##...##.......#......",
                ".........#...#....#..#.........",
                ".............#...#..##.#.......",
                "...#.##.......#...#.#..##.##...",
                ".####.#.##..#.#......#.##...#.#",
                ".#..#.#.....#.................#",
                "..#.##..###....#...#......####.",
                "..##..##...........#....#...#..",
                "....#...#...#...#.......#....#.",
                "#.#...###...#...#.#...#....##.#",
                "......#...#.#.......#.....#...#",
                "....##...#.#.#....#....#.#....#",
                ".....#.....#...##..#...#....##.",
                "#.....#....#......##.##....#...",
                "...#.#....#...#....#.#....##..#",
                "...#.#..#...##....###..#.......",
                "...##......###...###.#...#..#..",
                "##.......#.......###.......#..#",
                "..##.##..###.#............#...#",
                "#.....##..#..##....##..#.......",
                "......#.#...#......#.....#.....",
                "#...........#....#..##.##.#....",
                ".......#..#......#...#....#...#",
                ".#...##...........#......#...#.",
                "#........#....##...###.#....#..",
                ".....#.......##.........#.##...",
                ".#.###..#....#..##.#..#.#..#...",
                "#.......#.##.#.#....#.#..#....#",
                "###.....#.#.......#..#......#.#",
                "#..#.#.......#.#..##..##.#.#...",
                "#..#.#.#.###........#.....#...#",
                "#.#.#..#..##.....#...........#.",
                "..#.#..#.....#...#...#...##....",
                "...#.##......#...##.#...#.#.#.#",
                "#..#.#.#.#.......####..........",
                "..#......#.#......##.###.....##",
                "..#...##..#.........##....#.##.",
                "##.##.##.#.#.....#..........##.",
                ".#.....###.#..#....#..#.###...#",
                "#...##.......###....#.#..#.....",
                "..#....##.........##.........##",
                "......#....#.##.......#........",
                "..#.#.#..#...#...#...##.#...#..",
                "......#..##.#.#.#...##...#.#.##",
                "#..#...##.#.....#...#.##.......",
                "..#..#.........##.#...#.##...##",
                "##.##.#....#.......#.##..#.....",
                ".....##...##.##...##.........##",
                "#......#...#.......#...#...#...",
                "...##...........#...#..#.......",
                ".#.##.#..#........#....#.......",
                "#.#...#..#......##...#.#.##....",
                "##........####..#.#...#.#.##.##",
                "#..#.#.##......##.#.#..#.......",
                ".....#.........#..#.####....#..",
                "......##..#....#...#.#....#....",
                "#...##........#.........#.....#",
                ".#.#...#.#.#..#............##.#",
                ".#..#....#....#.....#...#.....#",
                "..###...#..#.....#.##.###...#.#",
                ".#.###..#..#...#.#...#.#......#",
                "#...#####......###........##...",
                ".....#.....#..#.#....#..##.....",
                "....##...#.#.##.#####...#....#.",
                ".#.#.........##.#.......#..##..",
                ".#...#.#...#...#....#.#...##.#.",
                ".##...#..#.#..#......#.#.#..##.",
                "..#.....#..#.....##.....#......",
                "..#........#..##...#.......###.",
                ".#....#.......#....#....#..#...",
                "....#......#.#.#.........#.....",
                "..##...#.#.#...#.#........#....",
                ".#.....####...##.#..#...##.....",
                "...#.....#...#...#....#....#...",
                ".........#..#.#.....#..#.#..#..",
                ".........##...........#.......#",
                "......#..#.....##...#.##.#.....",
                ".#......##........##...#.#.##..",
                ".....#.#..##...........#..#..#.",
                "...#.......#...#.#..#.##..#.##.",
                "...#.......#.....#.#...#.##.#..",
                "#.....#.............##.#..####.",
                ".#...#......#...##.#....#.#....",
                ".##..##.##....#.#.....#.......#",
                "...#...#....#....##.#..#....##.",
                "..............##....#.......#.#",
                ".#.#.#...##..#..#...###.#..#...",
                ".#.#...#.#..#.#..#...######..#.",
                "........#......#.#..#.#....#...",
                "..###.....###.#.##....#...##...",
                ".##.#.....#.......##.......#...",
                "..#..##...#..........#.#....#.#" };
    }
}

/***
 * --- Day 3: Toboggan Trajectory ---

With the toboggan login problems resolved, you set off toward the airport. While travel by toboggan might be easy, it's certainly not safe: there's very minimal steering and the area is covered in trees. You'll need to see which angles will take you near the fewest trees.

Due to the local geology, trees in this area only grow on exact integer coordinates in a grid. You make a map (your puzzle input) of the open squares (.) and trees (#) you can see. For example:

..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#

These aren't the only trees, though; due to something you read about once involving arboreal genetics and biome stability, the same pattern repeats to the right many times:

..##.........##.........##.........##.........##.........##.......  --->
#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..
.#....#..#..#....#..#..#....#..#..#....#..#..#....#..#..#....#..#.
..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#
.#...##..#..#...##..#..#...##..#..#...##..#..#...##..#..#...##..#.
..#.##.......#.##.......#.##.......#.##.......#.##.......#.##.....  --->
.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#
.#........#.#........#.#........#.#........#.#........#.#........#
#.##...#...#.##...#...#.##...#...#.##...#...#.##...#...#.##...#...
#...##....##...##....##...##....##...##....##...##....##...##....#
.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#  --->

You start on the open square (.) in the top-left corner and need to reach the bottom (below the bottom-most row on your map).

The toboggan can only follow a few specific slopes (you opted for a cheaper model that prefers rational numbers); start by counting all the trees you would encounter for the slope right 3, down 1:

From your starting position at the top-left, check the position that is right 3 and down 1. Then, check the position that is right 3 and down 1 from there, and so on until you go past the bottom of the map.

The locations you'd check in the above example are marked here with O where there was an open square and X where there was a tree:

..##.........##.........##.........##.........##.........##.......  --->
#..O#...#..#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..
.#....X..#..#....#..#..#....#..#..#....#..#..#....#..#..#....#..#.
..#.#...#O#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#
.#...##..#..X...##..#..#...##..#..#...##..#..#...##..#..#...##..#.
..#.##.......#.X#.......#.##.......#.##.......#.##.......#.##.....  --->
.#.#.#....#.#.#.#.O..#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#
.#........#.#........X.#........#.#........#.#........#.#........#
#.##...#...#.##...#...#.X#...#...#.##...#...#.##...#...#.##...#...
#...##....##...##....##...#X....##...##....##...##....##...##....#
.#..#...#.#.#..#...#.#.#..#...X.#.#..#...#.#.#..#...#.#.#..#...#.#  --->

In this example, traversing the map using this slope would cause you to encounter 7 trees.

Starting at the top-left corner of your map and following a slope of right 3 and down 1, how many trees would you encounter?

Your puzzle answer was 228.
--- Part Two ---

Time to check the rest of the slopes - you need to minimize the probability of a sudden arboreal stop, after all.

Determine the number of trees you would encounter if, for each of the following slopes, you start at the top-left corner and traverse the map all the way to the bottom:

    Right 1, down 1.
    Right 3, down 1. (This is the slope you already checked.)
    Right 5, down 1.
    Right 7, down 1.
    Right 1, down 2.

In the above example, these slopes would find 2, 7, 3, 4, and 2 tree(s) respectively; multiplied together, these produce the answer 336.

What do you get if you multiply together the number of trees encountered on each of the listed slopes?

Your puzzle answer was 6818112000.
 * 
 * 
 */
