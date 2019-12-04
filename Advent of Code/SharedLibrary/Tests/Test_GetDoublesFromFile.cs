using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;

namespace Advent_of_Code.Day_01.Tests
{
    public class Test_GetDoublesFromFile
    {
        const string filename = @"D:\DEV\CSharp\Advent of Code\Advent of Code\Day 01\input.txt";

        [Fact]
        public void ShouldReturnCorrectFirstResult()
        {
            List<double> actual = SharedLibrary.FileParser.GetDoublesFromFile(filename).Take(10).ToList();
            List<double> expected = new List<double>() { 90903, 135889, 120859, 137397, 56532, 92489, 87979, 149620, 137436, 62999 };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldReturn100Elements()
        {
            int actual = SharedLibrary.FileParser.GetDoublesFromFile(filename).ToList().Count();
            Assert.Equal(100, actual);
        }

    }


}
