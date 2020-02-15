using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Serilog;

namespace Advent_of_Code.Day_10
{
    internal class AsteroidMap
    {
        internal List<Asteroid> Asteroids { private set; get; }

        public AsteroidMap(string filename)
        {
            Asteroids = new List<Asteroid>();
            ParseMapFile(filename);
        }

        internal void ParseMapFile(string filename)
        {
            int i = 0;
            foreach (string line in File.ReadLines(filename))
            {
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == '#')
                    {
                        Asteroids.Add(new Asteroid(j, i));
                    }
                }
                i++;
            }

            if (Asteroids.Count == 0) { throw new FileLoadException("No asteroids loaded from file."); }
        }

        internal IEnumerable<Asteroid> GetOrderOfDestruction(Asteroid sourceAsteroid)
        {
            SortedDictionary<double, SortedList<double, Asteroid>> anglesWithNeighbours = GetDictionaryOfNeighbours(sourceAsteroid);

            bool firstRun = true;
            bool somethingNukedThisRound = true;

            while (somethingNukedThisRound == true)
            {
                somethingNukedThisRound = false;
                foreach (double angle in anglesWithNeighbours.Keys)
                {
                    // Angles will be in the range +/- PI
                    // If we started from -PI we would be 9 o'clock, we actually want to start at 12 o'clock
                    if (firstRun && angle < (Math.PI * -0.5)) { continue; } 
                    else if (firstRun && angle > Math.PI * - 0.5) { firstRun = false; } // Once we pass -1/2 Pi for the first time - its fair game. 

                    if (anglesWithNeighbours[angle].Count > 0)
                    {
                        yield return anglesWithNeighbours[angle].Values[0];
                        anglesWithNeighbours[angle].RemoveAt(0);
                        somethingNukedThisRound = true; 
                    }
                }
            }
        }

        private SortedDictionary<double, SortedList<double, Asteroid>> GetDictionaryOfNeighbours(Asteroid sourceAsteroid)
        {
            SortedDictionary<double, SortedList<double, Asteroid>> anglesWithNeighbors = new SortedDictionary<double, SortedList<double, Asteroid>>();
            foreach (Asteroid asteroid in this.Asteroids)
            {
                if (asteroid == sourceAsteroid) { continue; }
                double angle = sourceAsteroid.GetSlope(asteroid);

                if (anglesWithNeighbors.ContainsKey(angle) == false)
                {
                    anglesWithNeighbors.Add(angle, new SortedList<double, Asteroid>());
                }
                double distance = Math.Pow(sourceAsteroid.X - asteroid.X, 2) + Math.Pow(sourceAsteroid.Y - asteroid.Y, 2);
                anglesWithNeighbors[angle].Add(distance, asteroid);
            }

            return anglesWithNeighbors;
        }

        internal void UpdateAsteroidsInFOV(Asteroid targetAsteroid)
        {
            HashSet<double> angles = new HashSet<double>();
            foreach (var asteroid in Asteroids)
            {
                if (asteroid == targetAsteroid) { continue; }

                double slope = targetAsteroid.GetSlope(asteroid);
                angles.Add(slope);
            }

            targetAsteroid.AsteroidsVisible = angles.Count;
        }

        internal Asteroid GetBestAsteroid()
        {
            Asteroid bestAsteroid = Asteroids[0];

            foreach (Asteroid asteroid in Asteroids)
            {
                UpdateAsteroidsInFOV(asteroid);
                if (asteroid.AsteroidsVisible > bestAsteroid.AsteroidsVisible)
                {
                    bestAsteroid = asteroid;
                }
            }
            return bestAsteroid;
        }
    }
}
