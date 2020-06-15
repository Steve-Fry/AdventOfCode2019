using Advent_of_Code.Day_14;
using System.IO;
using Xunit;

namespace Advent_of_Code.Day_14
{
    public class ResourceReaction_Tests
    {

        [Theory]
        [InlineData(0, "ORE", 10)]
        [InlineData(1, "ORE", 1)]
        [InlineData(2, "A", 7)]
        [InlineData(3, "A", 7)]
        [InlineData(4, "A", 7)]
        [InlineData(5, "A", 7)]
        public void ShouldParseFirstInputForReactionCorrectly(int lineNumber, string resourceName, int resourceCount)
        {
            // Arrange
            string firstLine = File.ReadAllLines(@"Inputs\Day14Example1Input.txt")[lineNumber];
            string expectedName = resourceName;
            int expectedCount = resourceCount;

            // Act
            ResourceReaction reaction = new ResourceReaction(firstLine);
            string actualName = reaction.inputResources[0].Name;
            int actualCount = reaction.inputResources[0].Count;

            // Assert
            Assert.Equal(expectedName, actualName);
            Assert.Equal(expectedCount, actualCount);
        }

        [Theory]
        [InlineData(2, "B", 1)]
        [InlineData(3, "C", 1)]
        [InlineData(4, "D", 1)]
        [InlineData(5, "E", 1)]
        public void ShouldParseSecondInputForReactionCorrectly(int lineNumber, string resourceName, int resourceCount)
        {
            // Arrange
            string firstLine = File.ReadAllLines(@"Inputs\Day14Example1Input.txt")[lineNumber];
            string expectedName = resourceName;
            int expectedCount = resourceCount;

            // Act
            ResourceReaction reaction = new ResourceReaction(firstLine);
            string actualName = reaction.inputResources[1].Name;
            int actualCount = reaction.inputResources[1].Count;

            // Assert
            Assert.Equal(expectedName, actualName);
            Assert.Equal(expectedCount, actualCount);
        }

        [Theory]
        [InlineData(0, "A", 10)]
        [InlineData(1, "B", 1)]
        [InlineData(2, "C", 1)]
        [InlineData(3, "D", 1)]
        [InlineData(4, "E", 1)]
        [InlineData(5, "FUEL", 1)]
        public void ShouldParseOutputForReactionCorrectly(int lineNumber, string resourceName, int resourceCount)
        {
            // Arrange
            string firstLine = File.ReadAllLines(@"Inputs\Day14Example1Input.txt")[lineNumber];
            string expectedName = resourceName;
            int expectedCount = resourceCount;

            // Act
            ResourceReaction reaction = new ResourceReaction(firstLine);
            string actualName = reaction.outputResource.Name;
            int actualCount = reaction.outputResource.Count;

            // Assert
            Assert.Equal(expectedName, actualName);
            Assert.Equal(expectedCount, actualCount);
        }
    }
}