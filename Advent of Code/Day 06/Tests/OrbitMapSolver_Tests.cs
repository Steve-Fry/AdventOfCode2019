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
            List<string> input = SharedLibrary.FileParser.GetStringsFromFile(@"Inputs\Day06_Example1Input.txt");
            OrbitMapSolver mapSolver = new OrbitMapSolver(input);
            int actual = mapSolver.TotalMapDistance;
            int expected = 42;
            Assert.Equal(expected, actual);
        }
    
        [Fact]
        public void ShoudlCalculateDistanceExample2()
        {
            List<string> input = SharedLibrary.FileParser.GetStringsFromFile(@"Inputs\Day06_Example2Input.txt");
            OrbitMapSolver mapSolver = new OrbitMapSolver(input);
            int actual = mapSolver.GetShortestPathToSanta();

            int expected = 4;
            Assert.Equal(expected, actual);

        }

    }



}
