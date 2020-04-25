using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Advent_of_Code.Day_10.Tests
{
    public class Test_Day10_Solutions
    {
        [Fact]
        public void ShouldCorrectlyGetPart1Solution()
        {
            AsteroidMap map = new AsteroidMap(@"Inputs\Day10Input.txt");
            Asteroid asteroid = map.GetBestAsteroid();

            Assert.Equal(280, asteroid.AsteroidsVisible);
            Assert.Equal(20, asteroid.X);
            Assert.Equal(18, asteroid.Y);
        }

        [Fact]
        public void ShouldCorrectlyGetPart2Solution()
        {
            AsteroidMap map = new AsteroidMap(@"Inputs\Day10Input.txt");
            Asteroid asteroid = map.GetBestAsteroid();

            Asteroid answer = map.GetOrderOfDestruction(asteroid).Skip(199).First();

            Assert.Equal(7, answer.X);
            Assert.Equal(6, answer.Y);
        }

    }
}
