using System.Collections.Generic;
using System.Linq;
using System;

namespace Advent_of_Code.Day_14
{
    internal class ResourceConverterMap
    {
        private readonly string _input;
        public Dictionary<string, ResourceReaction> Resources {get; private set;}

        public ResourceConverterMap(string input)
        {
            ValidateInputString(input);
            this._input = input;
            Resources = new Dictionary<string, ResourceReaction>();
            ParseInput();
        }

        private void ValidateInputString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input string was empty");
            }
        }

        public void ParseInput()
        {
            List<string> lines = _input.Split("\n").ToList();
            foreach (var line in lines)
            {
                ResourceReaction reaction = new ResourceReaction(line);
                Resources[reaction.outputResource.Name] = reaction;
            }
        }
    }
}