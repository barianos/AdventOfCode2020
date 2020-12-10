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
            includeRule = new List<BagRule>();
            string temp;// = rule;
            string[] splitted = rule.Split(" bags contain ");
            color = splitted[0];
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




    }
}
