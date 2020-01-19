using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;

namespace Advent_of_Code.Day_08.Tests
{
    public class SIFImage_Tests
    {
        [Fact]
        public void ShouldCorrectlyConstructFromFile()
        {
            SIFImage sifImageFromFile = new SIFImage(@"..\..\..\Day 08\Tests\Example1Input.txt", 3, 2);

            List<List<int>> expectedLayers = new List<List<int>>
            {
                new List<int>() { 1, 2, 3, 4, 5, 6 },
                new List<int>() { 7, 8, 9, 0, 1, 2 }
            };

            Assert.Equal(3, sifImageFromFile.XPixels);
            Assert.Equal(2, sifImageFromFile.YPixels);
            Assert.Equal(6, sifImageFromFile.LayerSize);
            Assert.Equal(expectedLayers, sifImageFromFile.Layers);
        }

        [Fact]
        public void ShouldCorrectlyConstructFromIEnumerable()
        {
            SIFImage sifImageFromIEnumerable = new SIFImage(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2 }, 3, 2);

            List<List<int>> expectedLayers = new List<List<int>>
            {
                new List<int>() { 1, 2, 3, 4, 5, 6 },
                new List<int>() { 7, 8, 9, 0, 1, 2 }
            };

            Assert.Equal(3, sifImageFromIEnumerable.XPixels);
            Assert.Equal(2, sifImageFromIEnumerable.YPixels);
            Assert.Equal(6, sifImageFromIEnumerable.LayerSize);
            Assert.Equal(expectedLayers, sifImageFromIEnumerable.Layers);
        }
    }

}
