using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Advent_of_Code.Day_06
{
    class OrbitalBody
    {
        public string name { get; }
        public HashSet<OrbitalBody> bodiesInOrbit;

        public OrbitalBody inOrbitOf { get; set; }

        public int DistanceFromCOM;

        public OrbitalBody(string name)
        {
            this.name = name;
            bodiesInOrbit = new HashSet<OrbitalBody>();
        }

        public List<OrbitalBody> AllLinkedBodies
        {
            get
            {
                List<OrbitalBody> bodies = bodiesInOrbit.ToList();
                
                if (inOrbitOf != null)
                {
                    bodies.Add(inOrbitOf);
                }

                return bodies;
            }
        } 
    }
}
