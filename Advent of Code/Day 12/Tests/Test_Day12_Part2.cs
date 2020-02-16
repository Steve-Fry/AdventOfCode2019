using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Xunit;

namespace Advent_of_Code.Day_12.Tests
{
    public class Test_Day12_Part2
    {
        [Fact]
        public void ShouldCalculateExample1()
        {
            List<OrbitalBody> bodies = new List<OrbitalBody>()
            {
                // Short cycle
                new OrbitalBody(new Vector3(-1,0,2)),
                new OrbitalBody(new Vector3(2,-10,-7)),
                new OrbitalBody(new Vector3(4,-8,8)),
                new OrbitalBody(new Vector3(3,5,-1))

            };
            JovianSystem jovianSystem = new JovianSystem(bodies);

            Assert.Equal(2772, jovianSystem.GetNumberOfStepsPerCycle());
        }

        [Fact]
        public void ShouldCalculateExample2()
        {
            List<OrbitalBody> bodies = new List<OrbitalBody>()
            {
                // Stupid long cycle
                new OrbitalBody(new Vector3(-8,-10,0)),
                new OrbitalBody(new Vector3(5,5,10)),
                new OrbitalBody(new Vector3(2,-7,3)),
                new OrbitalBody(new Vector3(9,-8,-3))
            };
            JovianSystem jovianSystem = new JovianSystem(bodies);

            Assert.Equal(4686774924, jovianSystem.GetNumberOfStepsPerCycle());
        }
    }
}
