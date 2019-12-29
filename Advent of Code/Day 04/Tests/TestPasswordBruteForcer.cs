using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using Advent_of_Code.Day_04;

namespace Advent_of_Code.Day_04.Tests
{

    public class TestsPasswordBruteForcer
    {
        [Theory]
        [MemberData(nameof(ShouldReturnAValidRangeOfIntegerPasswords_Data))]
        public void ShouldReturnAValidRangeOfIntegerPasswords(List<string> expected, int lowerBound, int upperBound, int characters)
        {
            PasswordBruteForcer bruteForcer = new PasswordBruteForcer(characters, lowerBound, upperBound);
            List<string> actual = bruteForcer.GetPossibleIntegerPasswordsInRange().ToList();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(ShouldParseStringIntoIntList_Data))]
        public void ShouldParseStringIntoIntList(List<int> expected, string input)
        {
            List<int> actual = PasswordBruteForcer.GetIntListFromString(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(ShouldReturnCorrectResultForDecendingPassword_Data))]
        public void ShouldReturnCorrectResultForDecendingPassword(List<int> password, bool expected)
        {
            Assert.Equal(PasswordBruteForcer.HasNoDecendingValues(password), expected);

        }

        [Fact]
        public void ShouldReturnTheCorrectResultForPart1()
        {
            PasswordBruteForcer bruteForcer = new PasswordBruteForcer(6, 382345, 843167);
            Assert.Equal(460, bruteForcer.GetValidPasswordsInRange_Part1());
        }

        [Fact]
        public void ShouldReturnTheCorrectResultForPart2()
        {
            PasswordBruteForcer bruteForcer = new PasswordBruteForcer(6, 382345, 843167);
            Assert.Equal(290, bruteForcer.GetValidPasswordsInRange_Part2());
        }

        [Theory]
        [MemberData(nameof(ShouldCorrectlyCalculateTestCasesForPart2_Data))]
        public void ShouldCorrectlyCalculateTestCasesForPart2(List<int> input, bool expected)
        {
            bool actual = PasswordBruteForcer.HasPairOfSameCharacters(input) && PasswordBruteForcer.HasNoDecendingValues(input);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> ShouldCorrectlyCalculateTestCasesForPart2_Data() =>
        new List<object[]>
        {
                new object[] { new List<int> { 1,1,2,2,3,3 }, true },
                new object[] { new List<int> { 1,2,3,4,4,4 }, false },
                new object[] { new List<int> { 1,1,1,1,2,2 }, true },
        };

        public static IEnumerable<object[]> ShouldParseStringIntoIntList_Data() =>
            new List<object[]>
            {
                new object[] { new List<int> { 0, 2, 3, 0, 4, 9 }, "023049" },
                new object[] { new List<int> { 9, 9, 9, 9, 9, 9 }, "999999" },
                new object[] { new List<int> { 0, 0, 0, 0, 0, 0 }, "000000" },
            };

        public static IEnumerable<object[]> ShouldReturnAValidRangeOfIntegerPasswords_Data() =>
           new List<object[]>
           {
                new object[] { new List<string> {"02", "03", "04", "05", "06"}, 2, 6, 2},
                new object[] { new List<string> { "00", "01", "02", "03", "04", "05", "06" }, 0, 6, 2},
                new object[] { new List<string> { "02", "03", "04", "05", "06" }, 2, 6, 2},
           };

        public static IEnumerable<object[]> ShouldReturnCorrectResultForDecendingPassword_Data() =>
            new List<object[]>
            {
                new object[] { new List<int> {1,1,1,1,1,1} , true},
                new object[] { new List<int> {2,2,3,4,5,0} , false},
                new object[] { new List<int> {1,2,3,9,8,9} , false},
                new object[] { new List<int> {9,9,9,9,9,8} , false},
            };
    }
}
