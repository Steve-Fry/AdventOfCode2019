using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Advent_of_Code.Day_01.Tests
{
    public class Test_GetFuelRequiementForMass
    {
        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void ShouldReturnCorrectFuelRequierment(double mass, double expected)
        {
            double actual = FuelCalculator.GetFuelRequirementForMass(mass);
            Assert.Equal(expected, actual);
        }

    }
}
