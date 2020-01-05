using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Advent_of_Code.Day_06
{
    internal class OrbitMapSolver
    {
        private readonly Dictionary<string, OrbitalBody> _bodies = new Dictionary<string, OrbitalBody>();

        public int BodyCount => _bodies.Count;

        public OrbitMapSolver(List<string> input)
        {
            populateBodies(input);
            populateDistancesFromCOM();
        }

        private void populateBodies(List<string> input)
        {
            _bodies["COM"] = new OrbitalBody("COM");
            _bodies["COM"].DistanceFromCOM = 0;

            foreach (var line in input)
            {
                (string primaryBodyName, string orbitingBodyName) = parseOrbitString(line);

                if (_bodies.ContainsKey(primaryBodyName) == false)
                {
                    _bodies[primaryBodyName] = new OrbitalBody(primaryBodyName);
                }

                if (_bodies.ContainsKey(orbitingBodyName) == false)
                {
                    _bodies[orbitingBodyName] = new OrbitalBody(orbitingBodyName);
                }

                OrbitalBody primaryBody = _bodies[primaryBodyName];
                OrbitalBody orbitingBody = _bodies[orbitingBodyName];

                primaryBody.bodiesInOrbit.Add(orbitingBody);
                orbitingBody.inOrbitOf = primaryBody;
            }
        }

        private static (string primaryBody, string orbitingBody) parseOrbitString(string input)
        {
            List<string> splitInput = input.Split(")").ToList();
            return (splitInput[0], splitInput[1]);
        }

        private void populateDistancesFromCOM(OrbitalBody body = null)
        {
            body ??= _bodies["COM"]; // Set body to COM if null

            if (body.name == "COM")
            {
                body.DistanceFromCOM = 0;
            }
            else
            {
                body.DistanceFromCOM = body.inOrbitOf.DistanceFromCOM + 1;
            }

            body.bodiesInOrbit.ToList().ForEach(x => populateDistancesFromCOM(x));

        }

        public int TotalMapDistance => _bodies.Values.Select(x => x.DistanceFromCOM).Sum();

        public int GetShortestPathToSanta()
        {
            HashSet<OrbitalBody> explored = new HashSet<OrbitalBody>();   

            int distanceToSAN(OrbitalBody body, int currentDepth = 0)
            {
                if (body.name == "SAN")
                {
                    return currentDepth;
                } 
                else
                {
                    currentDepth += 1;
                    explored.Add(body);
                    return body.AllLinkedBodies.Except(explored).Select(x => distanceToSAN(x, currentDepth)).Where(x => x>0).FirstOrDefault();
                }

            }

            return distanceToSAN(_bodies["YOU"]) - 2;
        
        }

    }


}
