using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Advent_of_Code.SharedLibrary
{
    public class MathLib
    {
        public static double GetLCM(List<double> input) 
        {
            int i = 1;
            double maxVal = input.Max();
            while (true)
            {
                double multiple = maxVal * i;
                if (input.All(x => multiple % x == 0)) { return multiple; }
                i++;
            }
        }
    }
}
