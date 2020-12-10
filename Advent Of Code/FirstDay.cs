using System;
using System.Collections;
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
 *  This file covers the solution to Day 1 puzzles
 */


namespace Advent_Of_Code
{
    /// <summary>
    /// This class implements all methods that are needed to solve the two puzzles of day 1 of Advent of Code 2020
    /// </summary>
    public class FirstDay
    {
        ArrayList partsOfSum;
        int result;

        /// <summary>
        /// Takes in an arraylist and generates the product of the numbers within
        /// </summary>
        public int generateArraylistProduct(ArrayList multipliers)
        {
            result = 1;
            if (null == partsOfSum || partsOfSum.Count == 0)
            {
                Console.WriteLine("Arraylist is Empty!");
                return result;
            }
            
            foreach (int num in partsOfSum)
            {
                result *= num;
            }
            Console.WriteLine(result);
            return result;
        }


        /// <summary>
        /// Traverse an Array and find the numbers that sum up to a goalSum
        /// </summary>
        /// TODO some recursive way to make it work for 2, 3 or even more addents for the sum
        public ArrayList findSumPositions(int goalSum)
        {
            partsOfSum = new ArrayList();
            for (int i = 0; i < dataArray.Length; i++)
            {
                for (int j = 0; j < dataArray.Length; j++)
                {
                    for (int k = 0; k < dataArray.Length; k++)
                    {
                        if (dataArray[i] + dataArray[j] + dataArray[k] == goalSum)
                        {
                            partsOfSum.Add(dataArray[i]);
                            partsOfSum.Add(dataArray[j]);
                            partsOfSum.Add(dataArray[k]);
                            return partsOfSum;
                        }
                    }
                }
            }
            return null;
        }



        /// <summary>
        /// This array is the input given for me
        /// </summary>
        int[] dataArray = { 1974, 1902, 1356, 1724, 1550, 1870, 1436, 1945, 1640, 1766, 1508, 1802,
            1495, 1837, 131, 1754, 1296, 1627, 1768, 1451, 1252, 1566, 1611, 1531, 1868, 1745, 1894,
            1799, 1948, 1930, 1400, 2003, 1777, 1279, 472, 1474, 1787, 1406, 1522, 1646, 1865, 1581,
            1609, 1705, 1383, 1276, 1613, 1190, 1856, 1528, 1091, 1540, 1720, 1824, 1734, 1919, 1681,
            1686, 1344, 1644, 1670, 1710, 1708, 1458, 1728, 1972, 1630, 1995, 1763, 1935, 451, 1392,
            1990, 14, 1893, 1437, 1632, 1933, 1887, 1975, 1453, 1897, 2005, 2008, 1959, 1716, 1635,
            1619, 1994, 1674, 1942, 1817, 1825, 196, 769, 1065, 1662, 1079, 1574, 1554, 1621, 1857,
            1312, 1544, 2001, 1991, 1602, 1669, 1982, 1309, 1556, 1855, 1284, 1641, 1786, 735, 1921,
            1661, 1934, 1552, 1012, 1748, 1782, 1631, 1607, 1659, 1997, 1600, 1594, 1798, 1405, 1790,
            1993, 1960, 1717, 999, 1687, 1771, 1977, 1809, 1884, 1795, 1639, 1565, 1299, 1643, 1700,
            2002, 1823, 1369, 1572, 1657, 1683, 1966, 1606, 1792, 1756, 1936, 1718, 2009, 1711, 1461,
            1638, 1645, 1914, 1963, 1546, 1846, 1737, 1788, 1589, 1860, 1830, 1905, 1571, 1989, 1780,
            1878, 1767, 1776, 1727, 1582, 1769, 1040, 694, 1327, 1623, 1688, 1694, 1932, 2000, 1969,
            1590, 1425, 1917, 1324, 1852, 1753, 1743, 1551 };
    }
}