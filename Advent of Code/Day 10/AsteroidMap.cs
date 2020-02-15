using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

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
