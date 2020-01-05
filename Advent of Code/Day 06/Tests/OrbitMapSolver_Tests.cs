using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace Advent_of_Code.Day_06.Tests
{
    public class OrbitMapSolver_Tests
    {
        [Fact]
        public void ShouldCalculateSimpleExample1()
        {
            List<string> input = SharedLibrary.FileParser.GetStringsFromFile(@"..\..\..\Day 06\Day6_Example1.txt");
            OrbitMapSolver mapSolver = new OrbitMapSolver(input);
            int actual = mapSolver.TotalMapDistance;
            int expected = 42;
            Assert.Equal(expected, actual);
        }
    
        [Fact]
        public void ShoudlCalculateDistanceExample2()
        {
            List<string> input = SharedLibrary.FileParser.GetStringsFromFile(@"..\..\..\Day 06\Day6_Example2.txt");
            OrbitMapSolver mapSolver = new OrbitMapSolver(input);
            int actual = mapSolver.GetShortestPathToSanta();

            int expected = 4;
            Assert.Equal(expected, actual);

        }

    }



}
