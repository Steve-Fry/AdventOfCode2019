using Xunit;

namespace Advent_of_Code.Day_12.Tests
{
    public class Test_Day12_Solutions
    {
        [Fact]
        public void ShouldCorrectlyGetPart1Solution()
        {
            Day_12 d12 = new Day_12();
            Assert.Equal(9876, d12.GetPart1Solution());
        }

        [Fact]
        public void ShouldCorrectlyGetPart2Solution()
        {
            Day_12 d12 = new Day_12();
            Assert.Equal(307043147758488, d12.GetPart2Solution());
        }
    }
}
