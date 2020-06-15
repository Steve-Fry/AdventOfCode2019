using System.Collections.Generic;

namespace Advent_of_Code.Day_14
{
    class SurplusStore
    {
        Dictionary<string, long> surplusResources;
        public SurplusStore()
        {
            surplusResources = new Dictionary<string, long>();
        }
        internal void Add(string resource, long quantity)
        {
            if (surplusResources.ContainsKey(resource))
            {
                surplusResources[resource] += quantity;
            }
            else
            {
                surplusResources[resource] = quantity;
            }
        }
        internal bool TryTake(string resource, long quantity)
        {
            if (!surplusResources.ContainsKey(resource))
            {
                return false;
            }

            if (surplusResources[resource] >= quantity)
            {
                surplusResources[resource] -= quantity;
                return true;
            }
            else
            {
                return false;
            }
        }
        internal long Take(string resource)
        {
            if (!surplusResources.ContainsKey(resource))
            {
                return 0;
            }

            long output = surplusResources[resource];
            surplusResources[resource] = 0;
            return output;
        }

        internal void Clear()
        {
            surplusResources.Clear();
        }
    }
}