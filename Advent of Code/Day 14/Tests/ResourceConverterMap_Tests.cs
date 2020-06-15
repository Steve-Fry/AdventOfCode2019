using Advent_of_Code.Day_14;
using System.IO;
using System;
using Xunit;

namespace Advent_of_Code.Day_14
{
    public class ResourceConverterMap_Tests
    {

        [Fact]
        public void ShouldParseFirstInputForReactionCorrectly()
        {
            // Arrange
            string lines = File.ReadAllText(@"Inputs\Day14Example1Input.txt");

            // Act
            ResourceConverterMap converterMap = new ResourceConverterMap(lines);

            // Assert
            Assert.Equal(6, converterMap.Resources.Count);

            // 10 ORE => 10 A
            Assert.Equal(10, converterMap.Resources["A"].inputResources[0].Count);
            Assert.Equal("ORE", converterMap.Resources["A"].inputResources[0].Name);

            Assert.Equal(10, converterMap.Resources["A"].outputResource.Count);
            Assert.Equal("A", converterMap.Resources["A"].outputResource.Name);

            // 7 A, 1 E => 1 FUEL
            Assert.Equal(7, converterMap.Resources["FUEL"].inputResources[0].Count);
            Assert.Equal("A", converterMap.Resources["FUEL"].inputResources[0].Name);

            Assert.Equal(1, converterMap.Resources["FUEL"].inputResources[1].Count);
            Assert.Equal("E", converterMap.Resources["FUEL"].inputResources[1].Name);

            Assert.Equal(1, converterMap.Resources["FUEL"].outputResource.Count);
            Assert.Equal("FUEL", converterMap.Resources["FUEL"].outputResource.Name);

            // 7 A, 1 D => 1 E
            Assert.Equal(7, converterMap.Resources["E"].inputResources[0].Count);
            Assert.Equal("A", converterMap.Resources["E"].inputResources[0].Name);

            Assert.Equal(1, converterMap.Resources["E"].inputResources[1].Count);
            Assert.Equal("D", converterMap.Resources["E"].inputResources[1].Name);

            Assert.Equal(1, converterMap.Resources["E"].outputResource.Count);
            Assert.Equal("E", converterMap.Resources["E"].outputResource.Name);

        }

        [Fact]
        public void ShouldThrowAnExceptionForEmptyString()
        {
            string input = "";
            Exception ex = Assert.Throws<ArgumentException>(() => new ResourceConverterMap(input));
            Assert.Equal("Input string was empty", ex.Message);
        }


    }
}