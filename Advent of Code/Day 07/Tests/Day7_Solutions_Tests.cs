﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Advent_of_Code.Day_07.Tests
{
    public class Day7_Solution_Tests
    {
        [Fact]
        public void ShouldCorrectlyCalculatePart1Solution()
        {
            List<int> program = SharedLibrary.FileParser.GetIntCodeFromFile(@"Inputs\Day07Input.txt");
            AmplifierTuner tuner = new AmplifierTuner(program);
            tuner.Run();

            List<long> expectedTune = new List<long> { 2, 3, 0, 4, 1 };
            int expectedOutput = 24405;

            Assert.Equal(expectedTune, tuner.OptimalTune);
            Assert.Equal(expectedOutput, tuner.HighestOutput);
        }

        [Fact]
        public void ShouldCorrectlyCalculatePart2Solution()
        {
            List<int> program = SharedLibrary.FileParser.GetIntCodeFromFile(@"Inputs\Day07Input.txt");
            FeedbackAmplifierTuner feedbackTuner = new FeedbackAmplifierTuner(program);
            feedbackTuner.Run();

            List<long> expectedTune = new List<long> { 5, 7, 9, 8, 6 };
            int expectedOutput = 8271623;

            Assert.Equal(expectedTune, feedbackTuner.OptimalTune);
            Assert.Equal(expectedOutput, feedbackTuner.HighestOutput);
        }
    }
}
