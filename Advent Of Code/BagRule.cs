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
