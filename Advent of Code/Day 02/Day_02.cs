using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.Day_02
{
    public class Day_02
    {
        private readonly List<int> initialState = new List<int>() { 1, 12, 2, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 6, 1, 19, 1, 19, 5, 23, 2, 10, 23, 27, 2, 27, 13, 31, 1, 10, 31, 35, 1, 35, 9, 39, 2, 39, 13, 43, 1, 43, 5, 47, 1, 47, 6, 51, 2, 6, 51, 55, 1, 5, 55, 59, 2, 9, 59, 63, 2, 6, 63, 67, 1, 13, 67, 71, 1, 9, 71, 75, 2, 13, 75, 79, 1, 79, 10, 83, 2, 83, 9, 87, 1, 5, 87, 91, 2, 91, 6, 95, 2, 13, 95, 99, 1, 99, 5, 103, 1, 103, 2, 107, 1, 107, 10, 0, 99, 2, 0, 14, 0 };


        public void Run()
        {
            Console.WriteLine("Problem 02");
            Console.WriteLine("Part 1");
            Console.WriteLine($"Position 0 in the output: {GetPart1Solution()}");
            Console.WriteLine("Part 2");
            Console.WriteLine($"Position 0 in the output: {GetPart2Solution()}");
        }

        private int GetPart1Solution()
        {
            List<int> freshInitialState = initialState.GetRange(0, initialState.Count);
            IntCodeMachine intMachine = new IntCodeMachine(freshInitialState);
            return intMachine.Run();
        }

        private int GetPart2Solution()
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    List<int> freshInitialState = initialState.GetRange(0, initialState.Count);
                    freshInitialState[1] = i;
                    freshInitialState[2] = j;
                    IntCodeMachine intMachine = new IntCodeMachine(freshInitialState);

                    int result = intMachine.Run();
                    if (result == 19690720)
                    {
                        return (100 * i) + j;
                    }
                }
            }

            return 0;
        }
    }
}

