using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Advent_of_Code.SharedLibrary.Tests
{
    public class Test_MathLib
    {
        [Theory]
        [MemberData(nameof(ShouldCorrectlyCalculateLCM_Data))]
        public void ShouldCorrectlyCalculateLCM(List<double> input, double expected)
        {
            double actual = SharedLibrary.MathLib.GetLCM(input);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> ShouldCorrectlyCalculateLCM_Data() =>
            new List<object[]>
            {
                new object[] {new List<double> {14,22 }, 154 },
                new object[] {new List<double> {12,15,10,75 }, 300},
                new object[] {new List<double> {6,7,21 }, 42}
            };

    }
}
