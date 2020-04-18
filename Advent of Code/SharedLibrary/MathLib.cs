using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Advent_of_Code.SharedLibrary
{
    public static class MathLib
    {
        public static double GetGCD(double a, double b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            // Pull out remainders.
            while (true)
            {
                double remainder = a % b;
                if (remainder == 0)
                {
                    return b;
                }

                a = b;
                b = remainder;
            };
        }

        public static double GetLCM(double a, double b)
        {
            return a / GetGCD(a, b) * b;
        }


        public static double GetLCM(List<double> input)
        {
            if (input.Count < 2)
            {
                throw new ArgumentException("Input must be a collection of 2 or more objects");
            }

            double a = input[0];
            double b = input[1];
            List<double> remainingElements = input.Skip(2).ToList();
            double result = GetLCM(a, b);

            while (remainingElements.Count > 0)
            {
                a = result;
                b = remainingElements[0];
                remainingElements.RemoveAt(0);
                result = GetLCM(a, b);
            }

            return result;
        }
    }
}
