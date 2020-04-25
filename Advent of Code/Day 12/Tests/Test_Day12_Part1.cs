using System.Collections.Generic;
using System.Numerics;
using Xunit;

namespace Advent_of_Code.Day_12.Tests
{
    public class Test_Day12_Part1
    {
        [Fact]
        public void ShouldCalculateExample1_InitialConditionIsCorrect()
        {
            List<OrbitalBody> bodies = new List<OrbitalBody>()
                {
                    new OrbitalBody(new Vector3(-1, 0, 2)),
                    new OrbitalBody(new Vector3(2, -10, -7)),
                    new OrbitalBody(new Vector3(4, -8, 8)),
                    new OrbitalBody(new Vector3(3, 5, -1)),
                };
            JovianSystem jovianSystem = new JovianSystem(bodies);

            Assert.Equal("pos=<x=-1, y=0, z=2>, vel=<x=0, y=0, z=0>", jovianSystem.OrbitalBodies[0].ToString());
            Assert.Equal("pos=<x=2, y=-10, z=-7>, vel=<x=0, y=0, z=0>", jovianSystem.OrbitalBodies[1].ToString());
            Assert.Equal("pos=<x=4, y=-8, z=8>, vel=<x=0, y=0, z=0>", jovianSystem.OrbitalBodies[2].ToString());
            Assert.Equal("pos=<x=3, y=5, z=-1>, vel=<x=0, y=0, z=0>", jovianSystem.OrbitalBodies[3].ToString());

        }

        [Fact]
        public void ShouldCalculateExample1_FirstStep()
        {
            List<OrbitalBody> bodies = new List<OrbitalBody>()
                {
                    new OrbitalBody(new Vector3(-1, 0, 2)),
                    new OrbitalBody(new Vector3(2, -10, -7)),
                    new OrbitalBody(new Vector3(4, -8, 8)),
                    new OrbitalBody(new Vector3(3, 5, -1)),
                };
            JovianSystem jovianSystem = new JovianSystem(bodies);

            Assert.Equal("pos=<x=-1, y=0, z=2>, vel=<x=0, y=0, z=0>", jovianSystem.OrbitalBodies[0].ToString());
            Assert.Equal("pos=<x=2, y=-10, z=-7>, vel=<x=0, y=0, z=0>", jovianSystem.OrbitalBodies[1].ToString());
            Assert.Equal("pos=<x=4, y=-8, z=8>, vel=<x=0, y=0, z=0>", jovianSystem.OrbitalBodies[2].ToString());
            Assert.Equal("pos=<x=3, y=5, z=-1>, vel=<x=0, y=0, z=0>", jovianSystem.OrbitalBodies[3].ToString());

            jovianSystem.DoTimeStep();
            Assert.Equal("pos=<x=2, y=-1, z=1>, vel=<x=3, y=-1, z=-1>", jovianSystem.OrbitalBodies[0].ToString());
            Assert.Equal("pos=<x=3, y=-7, z=-4>, vel=<x=1, y=3, z=3>", jovianSystem.OrbitalBodies[1].ToString());
            Assert.Equal("pos=<x=1, y=-7, z=5>, vel=<x=-3, y=1, z=-3>", jovianSystem.OrbitalBodies[2].ToString());
            Assert.Equal("pos=<x=2, y=2, z=0>, vel=<x=-1, y=-3, z=1>", jovianSystem.OrbitalBodies[3].ToString());
        }

        [Fact]
        public void ShouldCalculateExample1_AllSteps()
        {
            List<OrbitalBody> bodies = new List<OrbitalBody>()
                {
                    new OrbitalBody(new Vector3(-1, 0, 2)),
                    new OrbitalBody(new Vector3(2, -10, -7)),
                    new OrbitalBody(new Vector3(4, -8, 8)),
                    new OrbitalBody(new Vector3(3, 5, -1)),
                };
            JovianSystem jovianSystem = new JovianSystem(bodies);

            Assert.Equal("pos=<x=-1, y=0, z=2>, vel=<x=0, y=0, z=0>", jovianSystem.OrbitalBodies[0].ToString());
            Assert.Equal("pos=<x=2, y=-10, z=-7>, vel=<x=0, y=0, z=0>", jovianSystem.OrbitalBodies[1].ToString());
            Assert.Equal("pos=<x=4, y=-8, z=8>, vel=<x=0, y=0, z=0>", jovianSystem.OrbitalBodies[2].ToString());
            Assert.Equal("pos=<x=3, y=5, z=-1>, vel=<x=0, y=0, z=0>", jovianSystem.OrbitalBodies[3].ToString());

            jovianSystem.DoTimeStep();
            Assert.Equal("pos=<x=2, y=-1, z=1>, vel=<x=3, y=-1, z=-1>", jovianSystem.OrbitalBodies[0].ToString());
            Assert.Equal("pos=<x=3, y=-7, z=-4>, vel=<x=1, y=3, z=3>", jovianSystem.OrbitalBodies[1].ToString());
            Assert.Equal("pos=<x=1, y=-7, z=5>, vel=<x=-3, y=1, z=-3>", jovianSystem.OrbitalBodies[2].ToString());
            Assert.Equal("pos=<x=2, y=2, z=0>, vel=<x=-1, y=-3, z=1>", jovianSystem.OrbitalBodies[3].ToString());

            jovianSystem.DoTimeStep();
            Assert.Equal("pos=<x=5, y=-3, z=-1>, vel=<x=3, y=-2, z=-2>", jovianSystem.OrbitalBodies[0].ToString());
            Assert.Equal("pos=<x=1, y=-2, z=2>, vel=<x=-2, y=5, z=6>", jovianSystem.OrbitalBodies[1].ToString());
            Assert.Equal("pos=<x=1, y=-4, z=-1>, vel=<x=0, y=3, z=-6>", jovianSystem.OrbitalBodies[2].ToString());
            Assert.Equal("pos=<x=1, y=-4, z=2>, vel=<x=-1, y=-6, z=2>", jovianSystem.OrbitalBodies[3].ToString());

            jovianSystem.DoTimeStep();
            Assert.Equal("pos=<x=5, y=-6, z=-1>, vel=<x=0, y=-3, z=0>", jovianSystem.OrbitalBodies[0].ToString());
            Assert.Equal("pos=<x=0, y=0, z=6>, vel=<x=-1, y=2, z=4>", jovianSystem.OrbitalBodies[1].ToString());
            Assert.Equal("pos=<x=2, y=1, z=-5>, vel=<x=1, y=5, z=-4>", jovianSystem.OrbitalBodies[2].ToString());
            Assert.Equal("pos=<x=1, y=-8, z=2>, vel=<x=0, y=-4, z=0>", jovianSystem.OrbitalBodies[3].ToString());

            jovianSystem.DoTimeStep();
            Assert.Equal("pos=<x=2, y=-8, z=0>, vel=<x=-3, y=-2, z=1>", jovianSystem.OrbitalBodies[0].ToString());
            Assert.Equal("pos=<x=2, y=1, z=7>, vel=<x=2, y=1, z=1>", jovianSystem.OrbitalBodies[1].ToString());
            Assert.Equal("pos=<x=2, y=3, z=-6>, vel=<x=0, y=2, z=-1>", jovianSystem.OrbitalBodies[2].ToString());
            Assert.Equal("pos=<x=2, y=-9, z=1>, vel=<x=1, y=-1, z=-1>", jovianSystem.OrbitalBodies[3].ToString());

            jovianSystem.DoTimeStep();
            Assert.Equal("pos=<x=-1, y=-9, z=2>, vel=<x=-3, y=-1, z=2>", jovianSystem.OrbitalBodies[0].ToString());
            Assert.Equal("pos=<x=4, y=1, z=5>, vel=<x=2, y=0, z=-2>", jovianSystem.OrbitalBodies[1].ToString());
            Assert.Equal("pos=<x=2, y=2, z=-4>, vel=<x=0, y=-1, z=2>", jovianSystem.OrbitalBodies[2].ToString());
            Assert.Equal("pos=<x=3, y=-7, z=-1>, vel=<x=1, y=2, z=-2>", jovianSystem.OrbitalBodies[3].ToString());

            jovianSystem.DoTimeStep();
            Assert.Equal("pos=<x=-1, y=-7, z=3>, vel=<x=0, y=2, z=1>", jovianSystem.OrbitalBodies[0].ToString());
            Assert.Equal("pos=<x=3, y=0, z=0>, vel=<x=-1, y=-1, z=-5>", jovianSystem.OrbitalBodies[1].ToString());
            Assert.Equal("pos=<x=3, y=-2, z=1>, vel=<x=1, y=-4, z=5>", jovianSystem.OrbitalBodies[2].ToString());
            Assert.Equal("pos=<x=3, y=-4, z=-2>, vel=<x=0, y=3, z=-1>", jovianSystem.OrbitalBodies[3].ToString());

            jovianSystem.DoTimeStep();
            Assert.Equal("pos=<x=2, y=-2, z=1>, vel=<x=3, y=5, z=-2>", jovianSystem.OrbitalBodies[0].ToString());
            Assert.Equal("pos=<x=1, y=-4, z=-4>, vel=<x=-2, y=-4, z=-4>", jovianSystem.OrbitalBodies[1].ToString());
            Assert.Equal("pos=<x=3, y=-7, z=5>, vel=<x=0, y=-5, z=4>", jovianSystem.OrbitalBodies[2].ToString());
            Assert.Equal("pos=<x=2, y=0, z=0>, vel=<x=-1, y=4, z=2>", jovianSystem.OrbitalBodies[3].ToString());

            jovianSystem.DoTimeStep();
            Assert.Equal("pos=<x=5, y=2, z=-2>, vel=<x=3, y=4, z=-3>", jovianSystem.OrbitalBodies[0].ToString());
            Assert.Equal("pos=<x=2, y=-7, z=-5>, vel=<x=1, y=-3, z=-1>", jovianSystem.OrbitalBodies[1].ToString());
            Assert.Equal("pos=<x=0, y=-9, z=6>, vel=<x=-3, y=-2, z=1>", jovianSystem.OrbitalBodies[2].ToString());
            Assert.Equal("pos=<x=1, y=1, z=3>, vel=<x=-1, y=1, z=3>", jovianSystem.OrbitalBodies[3].ToString());

            jovianSystem.DoTimeStep();
            Assert.Equal("pos=<x=5, y=3, z=-4>, vel=<x=0, y=1, z=-2>", jovianSystem.OrbitalBodies[0].ToString());
            Assert.Equal("pos=<x=2, y=-9, z=-3>, vel=<x=0, y=-2, z=2>", jovianSystem.OrbitalBodies[1].ToString());
            Assert.Equal("pos=<x=0, y=-8, z=4>, vel=<x=0, y=1, z=-2>", jovianSystem.OrbitalBodies[2].ToString());
            Assert.Equal("pos=<x=1, y=1, z=5>, vel=<x=0, y=0, z=2>", jovianSystem.OrbitalBodies[3].ToString());

            jovianSystem.DoTimeStep();
            Assert.Equal("pos=<x=2, y=1, z=-3>, vel=<x=-3, y=-2, z=1>", jovianSystem.OrbitalBodies[0].ToString());
            Assert.Equal("pos=<x=1, y=-8, z=0>, vel=<x=-1, y=1, z=3>", jovianSystem.OrbitalBodies[1].ToString());
            Assert.Equal("pos=<x=3, y=-6, z=1>, vel=<x=3, y=2, z=-3>", jovianSystem.OrbitalBodies[2].ToString());
            Assert.Equal("pos=<x=2, y=0, z=4>, vel=<x=1, y=-1, z=-1>", jovianSystem.OrbitalBodies[3].ToString());
        }

        [Fact]
        public void ShouldCalculateExample2()
        {
            List<OrbitalBody> bodies = new List<OrbitalBody>()
                {
                    new OrbitalBody(new Vector3(-1, 0, 2)),
                    new OrbitalBody(new Vector3(2, -10, -7)),
                    new OrbitalBody(new Vector3(4, -8, 8)),
                    new OrbitalBody(new Vector3(3, 5, -1)),
                };
            JovianSystem jovianSystem = new JovianSystem(bodies);

            jovianSystem.DoTimeSteps(10);

            Assert.Equal(179, jovianSystem.GetSystemEnergy());
        }

        [Fact]
        public void ShouldCalculateExample3()
        {
            List<OrbitalBody> bodies = new List<OrbitalBody>()
                {
                    new OrbitalBody(new Vector3(-8, -10, 0)),
                    new OrbitalBody(new Vector3(5, 5, 10)),
                    new OrbitalBody(new Vector3(2, -7, 3)),
                    new OrbitalBody(new Vector3(9, -8, -3)),
                };
            JovianSystem jovianSystem = new JovianSystem(bodies);

            jovianSystem.DoTimeSteps(100);

            Assert.Equal("pos=<x=8, y=-12, z=-9>, vel=<x=-7, y=3, z=0>", jovianSystem.OrbitalBodies[0].ToString());
            Assert.Equal("pos=<x=13, y=16, z=-3>, vel=<x=3, y=-11, z=-5>", jovianSystem.OrbitalBodies[1].ToString());
            Assert.Equal("pos=<x=-29, y=-11, z=-1>, vel=<x=-3, y=7, z=4>", jovianSystem.OrbitalBodies[2].ToString());
            Assert.Equal("pos=<x=16, y=-13, z=23>, vel=<x=7, y=1, z=1>", jovianSystem.OrbitalBodies[3].ToString());

            Assert.Equal(1940, jovianSystem.GetSystemEnergy());
        }
    }
}
