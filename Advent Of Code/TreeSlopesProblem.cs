﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_Of_Code
{
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
