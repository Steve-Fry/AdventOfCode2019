using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.Day_08
{
    class Day_08
    {
        public void Run()
        {
            SIFImage imageParser = new SIFImage(@"..\..\..\Day 08\Day8Input.txt", 25, 6);

            imageParser.PrintLayer1();

            Console.WriteLine($"=====Day 8, part 1=====");

            Console.WriteLine($"=====Day 8, part 2=====");

        }
    }
}
