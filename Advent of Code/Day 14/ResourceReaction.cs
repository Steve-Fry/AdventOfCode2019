using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code.Day_14
{
    internal class ResourceReaction
    {
        public List<Resource> inputResources { get; private set; }
        public Resource outputResource { get; private set; }

        public ResourceReaction(string reactionAsString)
        {
            // Init fields.
            inputResources = new List<Resource>();
            LoadStateFromString(reactionAsString);
        }

        private void LoadStateFromString(string reactionAsString)
        {
            var splitResources = SplitInputAndOutput(reactionAsString);
            List<string> inputsList = SplitInputs(splitResources.inputs);
            AddInputResources(inputsList);
            AddOuputResource(splitResources.output);
        }

        private void AddOuputResource(string output)
        {
            Resource resource = new Resource(output);
            outputResource = resource;
        }

        private (string inputs, string output) SplitInputAndOutput(string line)
        {
            string[] splitString = line.Split(" => ");

            if (splitString.Length != 2)
            {
                throw new ArgumentException("Input string could not be split into an input and output object", "line");
            }
            else
            {
                return (inputs: splitString[0], output: splitString[1]);
            }
        }

        private void AddInputResources(List<string> inputs)
        {
            foreach (var input in inputs)
            {
                Resource resource = new Resource(input);
                inputResources.Add(resource);
            }
        }

        private List<string> SplitInputs(string input) => input.Split(", ").ToList();
    }
}