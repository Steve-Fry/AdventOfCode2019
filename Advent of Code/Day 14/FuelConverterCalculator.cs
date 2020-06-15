using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Advent_of_Code.Day_14
{
    internal class FuelConverterCalculator
    {
        private readonly string _input;
        private readonly ResourceConverterMap _resourceConverterMap;
        private readonly Dictionary<string, ResourceReaction> _reactionMap;
        private readonly Dictionary<Resource, List<Resource>> reactionTree;
        private Dictionary<string, long> manufacturedResources;
        private SurplusStore surplusStore;

        public FuelConverterCalculator(string input, ResourceConverterMap converterMap)
        {
            reactionTree = new Dictionary<Resource, List<Resource>>();
            _input = input;
            _resourceConverterMap = converterMap;
            _reactionMap = _resourceConverterMap.Resources;
            surplusStore = new SurplusStore();
            manufacturedResources = new Dictionary<string, long>();
        }
        private void AddManufactured(string resource, long quantity)
        {
            manufacturedResources[resource] = manufacturedResources.ContainsKey(resource)
                ? manufacturedResources[resource] + quantity
                : quantity;
        }
        public long CalculateRequiredOre(long fuelRequired = 1)
        {
            reactionTree.Clear();
            manufacturedResources.Clear();
            surplusStore.Clear();

            Resource root = new Resource("FUEL", 1);
            MakeResource(root, fuelRequired);

            return manufacturedResources["ORE"];
        }
        private int GetMinimumProductionQuantity(Resource resource, int desiredQuantity)
        {
            double ratio = resource.Count / desiredQuantity;
            int multiple = (int)Math.Ceiling(ratio);
            return resource.Count * multiple;
        }
        internal long CalculateFuelProduced(long oreCount)
        {
            // Binary search to determine the ore fuel that can be produced with a given ore count.
            long left = 0;
            long right = oreCount - 1;
            long middle = 0;
            long result = 0;

            while (left <= right)
            {
                double tmp = (left + right) / 2;
                middle = (long)Math.Floor(tmp);
                result = CalculateRequiredOre(middle);
                if (result < oreCount)
                {
                    left = middle + 1;
                }
                else if (result > oreCount)
                {
                    right = middle - 1;
                }
                else
                {
                    return middle;
                }
            }
            return Math.Min(left, right);
        }
        private void MakeResource(Resource resource, long desiredQuantity)
        {
            if (resource.Name == "ORE")
            {
                AddManufactured(resource.Name, desiredQuantity);
                return;
            }

            ResourceReaction reaction = _reactionMap[resource.Name];
            long surplusQuatity = surplusStore.Take(resource.Name);
            long quantityToManufacture = desiredQuantity - surplusQuatity;

            long multiple = (long)Math.Ceiling((double)quantityToManufacture / (double)reaction.outputResource.Count);

            foreach (var input in reaction.inputResources)
            {
                long resourceCount = multiple * input.Count;
                if (!surplusStore.TryTake(input.Name, resourceCount))
                {
                    MakeResource(input, resourceCount);
                }
            }

            long produced = reaction.outputResource.Count * multiple;
            long surplusCount = produced - quantityToManufacture;

            surplusStore.Add(resource.Name, surplusCount);
            AddManufactured(resource.Name, quantityToManufacture);
        }
    }
}