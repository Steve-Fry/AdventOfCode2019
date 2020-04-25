using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;

namespace Advent_of_Code.Day_08.Tests
{
    public class SIFImage_Solution_Tests
    {
        [Fact]
        public void ShouldCorrectlyCalculatePart1()
        {
            SIFImage _imageParser = new SIFImage(@"Inputs\Day08Input.txt", 25, 6);
            Assert.Equal(1474, _imageParser.Checksum);
        }

        [Fact]
        public void ShouldCorrectlyCalculatePart2()
        {
            SIFImage _imageParser = new SIFImage(@"Inputs\Day08Input.txt", 25, 6);
            List<int> expected = new List<int>() { 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0 };
            Assert.Equal(expected, _imageParser.StackedImage);
        }
    }

}
