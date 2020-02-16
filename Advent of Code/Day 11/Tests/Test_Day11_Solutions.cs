using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Advent_of_Code.Day_11.Tests
{
    public class Test_Day10_Solutions
    {
        [Fact]
        public void ShouldCorrectlyGetPart1Solution()
        {
            PaintableHullSection hull = new PaintableHullSection();
            PaintingRobot robot = new PaintingRobot(hull, 0);

            Assert.Equal(1985, robot.PaintedPanels);
        }

    }
}
