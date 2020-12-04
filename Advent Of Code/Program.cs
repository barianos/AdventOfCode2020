using System;
using System.Collections;


namespace Advent_Of_Code
{
    class Program
    {
        static int CURRENT_YEAR = 2020;
        static void Main(string[] args)
        {
            Console.WriteLine("*********Welcome to the Advent Of Code!*******\n -------------------");
                        
            //Day2 Solution 2
            PasswordDebug pd = new PasswordDebug();
            int solution = pd.analizePasswords();
            Console.WriteLine("Solution is: " + solution);


            //Day 1 Solution 2
            //FirstDay firstDay = new FirstDay();
            //ArrayList listOfAddents = firstDay.findSumPositions(CURRENT_YEAR);
            //int day1Solution = firstDay.generateArraylistProduct(listOfAddents);
        }




    }


}
