using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;

namespace Advent_of_Code.Day_14
{
    public class FuelConverterCalculator_Tests
    {

        [Theory]
        [InlineData(@"Inputs\Day14Example1Input.txt", 31)]
        [InlineData(@"Inputs\Day14Example2Input.txt", 165)]
        [InlineData(@"Inputs\Day14Example3Input.txt", 13312)]
        [InlineData(@"Inputs\Day14Example4Input.txt", 180697)]
        [InlineData(@"Inputs\Day14Example5Input.txt", 2210736)]
        public void ShouldCalculatePart1ExamplesCorrectly(string relativeFilePath, int expected)
        {
            // Arrange
            string input = File.ReadAllText(relativeFilePath);
            ResourceConverterMap map = new ResourceConverterMap(input);

            // Act
            FuelConverterCalculator calculator = new FuelConverterCalculator(input, map);
            long actual = calculator.CalculateRequiredOre();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(@"Inputs\Day14Example3Input.txt", 82892753)]
        [InlineData(@"Inputs\Day14Example4Input.txt", 5586022)]
        [InlineData(@"Inputs\Day14Example5Input.txt", 460664)]
        public void ShouldCalculatePart2ExamplesCorrectly(string relativeFilePath, int expected)
        {
            // Arrange
            string input = File.ReadAllText(relativeFilePath);
            ResourceConverterMap map = new ResourceConverterMap(input);
            long oreCount = 1_000_000_000_000;

            // Act
            FuelConverterCalculator calculator = new FuelConverterCalculator(input, map);
            long actual = calculator.CalculateFuelProduced(oreCount);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldCalculatePart1SolutionCorrectly()
        {
            // Arrange
            string input = File.ReadAllText(@"Inputs\Day14Input.txt");
            ResourceConverterMap map = new ResourceConverterMap(input);
            int expected = 899155;

            // Act
            FuelConverterCalculator calculator = new FuelConverterCalculator(input, map);
            long actual = calculator.CalculateRequiredOre();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldCalculatePart2SolutionCorrectly()
        {
            // Arrange
            string input = File.ReadAllText(@"Inputs\Day14Input.txt");
            ResourceConverterMap map = new ResourceConverterMap(input);
            long oreCount = 1_000_000_000_000;
            long expected = 2390226;

            // Act
            FuelConverterCalculator calculator = new FuelConverterCalculator(input, map);
            long actual = calculator.CalculateFuelProduced(oreCount);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}