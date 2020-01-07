using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Advent_of_Code.Day_07.Tests
{
    public class Day7_Examples_Tests
    {
        [Fact]
        public void ShouldCorrectlyRunExample1()
        {
            List<int> program = new List<int>() { 3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0 };
            AmplifierTuner tuner = new AmplifierTuner(program);
            tuner.Run();


            List<int> expectedTune = new List<int> { 4, 3, 2, 1, 0 };
            int expectedOutput = 43210;

            Assert.Equal(expectedTune, tuner.OptimalTune);
            Assert.Equal(expectedOutput, tuner.HighestOutput);
        }

        [Fact]
        public void ShouldCorrectlyRunExample2()
        {
            List<int> program = new List<int>() { 3, 23, 3, 24, 1002, 24, 10, 24, 1002, 23, -1, 23, 101, 5, 23, 23, 1, 24, 23, 23, 4, 23, 99, 0, 0 };
            AmplifierTuner tuner = new AmplifierTuner(program);
            tuner.Run();


            List<int> expectedTune = new List<int> { 0, 1, 2, 3, 4 };
            int expectedOutput = 54321;

            Assert.Equal(expectedTune, tuner.OptimalTune);
            Assert.Equal(expectedOutput, tuner.HighestOutput);
        }        
        
        [Fact]
        public void ShouldCorrectlyRunExample3()
        {
            List<int> program = new List<int>() {3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0};
            AmplifierTuner tuner = new AmplifierTuner(program);
            tuner.Run();


            List<int> expectedTune = new List<int> { 1, 0, 4, 3, 2 };
            int expectedOutput = 65210;

            Assert.Equal(expectedTune, tuner.OptimalTune);
            Assert.Equal(expectedOutput, tuner.HighestOutput);
        }

    }
}
