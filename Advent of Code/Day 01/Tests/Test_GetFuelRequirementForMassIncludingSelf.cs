using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Advent_of_Code.Day_01.Tests
{
    public class Test_GetFuelRequiementForMassIncludingSelf
    {
        [Theory]
        [InlineData(14, 2)]
        [InlineData(1969, 966)]
        [InlineData(100756, 50346)]
        public void ShouldReturnCorrectFuelRequiermentIncludingSelf(double mass, double expected)
        {
            double actual = FuelCalculator.GetFuelRequirementsForMassIncludingSelf(mass);
            Assert.Equal(expected, actual);
        }

    }
}
