using SharedLibrary;
using System.Linq;
using Xunit;

namespace Advent_of_Code.Day_13
{

    public class Test_Day13_Part1
    {
        [Fact]
        public void ShouldReturnCorrectAnswerForPart1()
        {
            ArcadeMachine arcadeMachine = new ArcadeMachine();
            int answer = arcadeMachine.GetInitialScreenOutput().InSetsOf(3).Count(x => x[2] == 2);

            Assert.Equal(277, answer);
        }

        [Fact]
        public void ShouldReturnCorrectAnswerForPart2()
        {
            ArcadeMachine arcadeMachine = new ArcadeMachine();
            arcadeMachine.RunMachine();

            Assert.Equal(1, 0);
        }

    }
}
