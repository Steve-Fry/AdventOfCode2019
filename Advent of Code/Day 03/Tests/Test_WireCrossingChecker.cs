using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Advent_of_Code.Day_03.Tests
{
    public class Test_WireCrossingChecker
    {
        [Fact]
        public void ShouldCalculateTestCase1Correctly()
        {
            WireCrossingChecker crossingChecker = new WireCrossingChecker("R8,U5,L5,D3", "U7,R6,D4,L4");
            int actual = crossingChecker.GetClosestIntersection();
            Assert.Equal(6, actual);
        }
        [Fact]
        public void ShouldCalculateTestCase2Correctly()
        {
            WireCrossingChecker crossingChecker = new WireCrossingChecker("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83");
            int actual = crossingChecker.GetClosestIntersection();
            Assert.Equal(159, actual);
        }
        [Fact]
        public void ShouldCalculateTestCase3Correctly()
        {
            WireCrossingChecker crossingChecker = new WireCrossingChecker("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7");
            int actual = crossingChecker.GetClosestIntersection();
            Assert.Equal(135, actual);
        }

        [Fact]
        public void ShouldCalculateFirstCrossingTest1()
        {
            WireCrossingChecker crossingChecker = new WireCrossingChecker("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83");
            int actual = crossingChecker.GetFirstCrossing();
            Assert.Equal(610, actual);
        }
    }
}

