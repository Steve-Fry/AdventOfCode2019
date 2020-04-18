using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Advent_of_Code.SharedLibrary.Tests
{
    public class Test_MathLib
    {
        [Theory]
        [MemberData(nameof(ShouldCorrectlyCalculateLCM_TwoValues_Data))]
        public void ShouldCorrectlyCalculateLCM_TwoValues(List<double> input, double expected)
        {
            double actual = SharedLibrary.MathLib.GetLCM(input);
            Assert.Equal(expected, actual);
        }


        [Theory]
        [MemberData(nameof(ShouldCorrectlyCalculateLCM_MultipleValues_Data))]
        public void ShouldCorrectlyCalculateLCM_MultipleValues(List<double> input, double expected)
        {
            double actual = SharedLibrary.MathLib.GetLCM(input);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> ShouldCorrectlyCalculateLCM_MultipleValues_Data() =>
            new List<object[]>
            {
                new object[] {new List<double> {12,15,10,75 }, 300},
                new object[] {new List<double> { 12, 18, 30 }, 180},
                new object[] {new List<double> { 8, 18, 24 }, 72},
                new object[] {new List<double> { 15, 20, 30, 35 }, 420},
                new object[] {new List<double> { 16, 24, 40, 56 }, 1680},
                new object[] {new List<double> { 16, 48, 64, 80, 112 }, 6720},
            };

        public static IEnumerable<object[]> ShouldCorrectlyCalculateLCM_TwoValues_Data() =>
            new List<object[]>
            {
                new object[] {new List<double> {8,12}, 24 },
                new object[] {new List<double> {40,56}, 280 },
                new object[] {new List<double> {14,22 }, 154 }
            };
    }
}
