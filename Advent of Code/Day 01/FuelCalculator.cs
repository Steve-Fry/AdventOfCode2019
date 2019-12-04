using System;
using System.Collections.Generic;
using System.Text;

namespace Advent_of_Code.Day_01
{
    class FuelCalculator
    {
        public static double GetFuelRequirementForMass(double mass)
        {
            return Math.Floor(mass / 3) - 2;
        }

        public static double GetFuelRequirementsForMassIncludingSelf(double mass)
        {
            double fuelThisIteration = GetFuelRequirementForMass(mass);
            double totalFuel = 0;

            while (fuelThisIteration > 0)
            {
                totalFuel += fuelThisIteration;
                fuelThisIteration = GetFuelRequirementForMass(fuelThisIteration);
            }

            return totalFuel;
        }
    }
}
