using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace Advent_of_Code.Day_06.Tests
{
    public class OrbitMapSolver_Solution_Tests
    {
        [Fact]
        public void ShouldCalculateDay6Part1Solution()
        {
            List<string> input = SharedLibrary.FileParser.GetStringsFromFile(@"..\..\..\Day 06\Day6Input.txt");
            OrbitMapSolver mapSolver = new OrbitMapSolver(input);
            int actual = mapSolver.TotalMapDistance;
            int expected = 200001;
            Assert.Equal(expected, actual);
        }
    
        [Fact]
        public void ShouldCalculateDay6Part2Solution()
        {
            List<string> input = SharedLibrary.FileParser.GetStringsFromFile(@"..\..\..\Day 06\Day6Input.txt");
            OrbitMapSolver mapSolver = new OrbitMapSolver(input);
            int actual = mapSolver.GetShortestPathToSanta();

            int expected = 379;
            Assert.Equal(expected, actual);

        }

    }



}
