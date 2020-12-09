using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_Of_Code
{
    
    class BagRule
    {
        private string color;
        private int count;

        public string Color {
            get { return color; }   
            set { color = value; }  
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }


        public BagRule(string rule)
        {
            //drab gray bags contain 5 mirrored white bags, 1 light green bag, 5 shiny lavender bags, 5 faded aqua bags.
            ///bright lime bags contain no other bags.
            string[] splitted = rule.Trim().Split(" ");
            if (!splitted[0].Equals("no")){
                color = splitted[1] + " " + splitted[2];
                count = Int32.Parse(splitted[0]);
            }
            else
            {
                count = 0;
                color = "ERROR!";
            }
        }


    }
}
