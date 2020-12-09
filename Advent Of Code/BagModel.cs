using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_Of_Code
{
    class BagModel
    {
        private string color;
        private List<BagRule> includeRule;



        public string Color
        {
            get { return color; }
            set { color = value; }
        }


        public List<BagRule> IncludeRule
        {
            get { return includeRule; }
            set { includeRule = value; }
        }
        public BagModel(string rule)
        {
            //drab gray bags contain 5 mirrored white bags, 1 light green bag, 5 shiny lavender bags, 5 faded aqua bags.
            //bright lime bags contain no other bags.
            includeRule = new List<BagRule>();
            string temp;// = rule;
            string[] splitted = rule.Split(" bags contain ");
            color = splitted[0];
            //splitted = rule.Split("contain ");
            //splitted = splitted[1].Split(" bags, ")
            temp = splitted[1].Replace(" bags", "");
            temp = temp.Replace(" bag", "");
            temp = temp.Replace(".", "");
            temp = temp.Replace("\r", "");
            temp = temp.Replace("\n", "");
            splitted = temp.Split(",");
            
            foreach(string bagRule in splitted)
            {
                includeRule.Add(new BagRule(bagRule));
            }
        
        }

        //public int GetRecursiveContained(string color)
        //{
        //    int retv = 0;
        //    foreach(BagRule bag in includeRule)
        //    {
        //        retv += bag.Count;
        //        retv += retv * GetRecursiveContained(bag.Color);
        //    }


        //    return retv;
        //}

        //private string ExtractColorFromInput(string input)
        //{
        //    string[] splitted = input.Split(" bags contain ");
        //    return splitted[0];
        //}



    }
}
