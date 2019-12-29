using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Advent_of_Code.Day_04
{
    class PasswordBruteForcer
    {
        public int Characters { get; }
        public int StartRange { get; }
        public int EndRange { get; }

        public PasswordBruteForcer(int characters, int startRange, int endRange)
        {
            if (startRange < 0 || endRange < 0)
            {
                throw new ArgumentException("Cannot accept negative values for range");
            }

            if (characters < 1)
            {
                throw new ArgumentException("Cannot process a password with zero or negative length");
            }

            this.Characters = characters;
            this.StartRange = startRange;
            this.EndRange = endRange;
        }

        public IEnumerable<string> GetPossibleIntegerPasswordsInRange()
        {
            foreach (int i in Enumerable.Range(StartRange, (EndRange - StartRange + 1)))
            {
                yield return i.ToString().PadLeft(Characters, '0');
            }
        }

        public static List<int> GetIntListFromString(string number) => number.ToString().ToCharArray().Select(x => x - 48).ToList();

        public static bool HasTwoOrMoreAdjacentCharacters(List<int> input)
        {
            int previousValue = input[0];
            for (int i = 0; i < input.Count; i++)
            {
                int thisValue = input[i];
                if (i > 0 && thisValue == previousValue)
                {
                    return true;
                }
                previousValue = thisValue;
            }
            return false;
        }

        public static bool HasPairOfSameCharacters(List<int> input)
        {
            int previousValue = -1;
            int currentCount = 1;
            bool hasTwoAdjacent = false;
            for (int i = 0; i < input.Count; i++)
            {
                int thisValue = input[i];

                if (thisValue == previousValue)
                {
                    currentCount += 1;
                    if (i == (input.Count - 1) && currentCount == 2) // When this is the last element in the list
                    {
                        hasTwoAdjacent = true;
                    }
                }
                else if (currentCount == 2)
                {
                    hasTwoAdjacent = true;
                    currentCount = 1;
                }
                else if (currentCount > 2)
                {
                    currentCount = 1;
                }

                previousValue = thisValue;
            }

            if (hasTwoAdjacent)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool HasNoDecendingValues(List<int> input)
        {
            int previousValue = input[0];
            for (int i = 0; i < input.Count; i++)
            {
                int thisValue = input[i];

                if (previousValue > thisValue)
                {
                    return false;
                }
                previousValue = thisValue;
            }
            return true;
        }

        public int GetValidPasswordsInRange_Part1() =>
            GetPossibleIntegerPasswordsInRange()
                .Select(x => GetIntListFromString(x))
                .Where(x => HasTwoOrMoreAdjacentCharacters(x))
                .Where(x => HasNoDecendingValues(x))
                .Count();

        public int GetValidPasswordsInRange_Part2() =>
            GetPossibleIntegerPasswordsInRange()
                .Select(x => GetIntListFromString(x))
                .Where(x => HasPairOfSameCharacters(x))
                .Where(x => HasNoDecendingValues(x))
                .Count();
    }
}
