using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Advent_of_Code.Day_10.Tests
{
    public class Test_Day10_Part1
    {
        [Fact]
        public void ShouldCorrectlyCalculateExample1_Part1()
        {
            AsteroidMap map = new AsteroidMap(@"..\..\..\Day 10\Tests\Example1Input.txt");
            Asteroid asteroid = map.Asteroids.Where(x => x.X == 3 && x.Y == 4).First();

            Assert.Equal(4, asteroid.Y);
            Assert.Equal(3, asteroid.X);

            map.UpdateAsteroidsInFOV(asteroid);
            Assert.Equal(8, asteroid.AsteroidsVisible);
        }

        [Fact]
        public void ShouldCorrectlyCalculateExample1()
        {
            AsteroidMap map = new AsteroidMap(@"..\..\..\Day 10\Tests\Example1Input.txt");

            Asteroid asteroid = map.GetBestAsteroid();
            Assert.Equal(3, asteroid.X);
            Assert.Equal(4, asteroid.Y);
            Assert.Equal(8, asteroid.AsteroidsVisible);
        }

        [Fact]
        public void ShouldCorrectlyCalculateExample2()
        {
            AsteroidMap map = new AsteroidMap(@"..\..\..\Day 10\Tests\Example2Input.txt");

            Asteroid asteroid = map.GetBestAsteroid();
            Assert.Equal(5, asteroid.X);
            Assert.Equal(8, asteroid.Y);
            Assert.Equal(33, asteroid.AsteroidsVisible);
        }

        [Fact]
        public void ShouldCorrectlyCalculateExample3()
        {
            AsteroidMap map = new AsteroidMap(@"..\..\..\Day 10\Tests\Example3Input.txt");

            Asteroid asteroid = map.GetBestAsteroid();
            Assert.Equal(1, asteroid.X);
            Assert.Equal(2, asteroid.Y);
            Assert.Equal(35, asteroid.AsteroidsVisible);
        }
        [Fact]
        public void ShouldCorrectlyCalculateExample4()
        {
            AsteroidMap map = new AsteroidMap(@"..\..\..\Day 10\Tests\Example4Input.txt");

            Asteroid asteroid = map.GetBestAsteroid();
            Assert.Equal(6, asteroid.X);
            Assert.Equal(3, asteroid.Y);
            Assert.Equal(41, asteroid.AsteroidsVisible);
        }

        [Fact]
        public void ShouldCorrectlyCalculateExample5()
        {
            AsteroidMap map = new AsteroidMap(@"..\..\..\Day 10\Tests\Example5Input.txt");

            Asteroid asteroid = map.GetBestAsteroid();
            Assert.Equal(11, asteroid.X);
            Assert.Equal(13, asteroid.Y);
            Assert.Equal(210, asteroid.AsteroidsVisible);
        }

    }
}
