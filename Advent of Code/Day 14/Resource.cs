using System;

namespace Advent_of_Code.Day_14
{
    public class Resource
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public Resource(string name, int count)
        {
            Name = name;
            Count = count;
        }

        public Resource(string input)
        {
            string[] splitName = input.Split(" ");

            if (splitName.Length != 2)
            {
                throw new ArgumentException("Input was not a spece sperated list of resouceCount & resourceName");
            }

            if (!int.TryParse(splitName[0], out int resourceCount))
            {
                throw new ArgumentException("Failed to parse the resource count from the input");
            }

            Name = splitName[1].Trim();
            Count = resourceCount;
        }

        public Resource Copy() => new Resource(Name, Count);

        public override string ToString() => $"{Count} {Name}";
    }
}