using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Advent_of_Code.Day_12
{
    internal class JovianSystem
    {
        public List<OrbitalBody> OrbitalBodies { get; private set; }

        public JovianSystem(List<OrbitalBody> orbitalBodies)
        {
            OrbitalBodies = orbitalBodies;
        }

        public void DoTimeStep()
        {
            var bodyCombinations = from b1 in OrbitalBodies
                                   from b2 in OrbitalBodies
                                   where b1 != b2
                                   select (b1, b2);

            foreach ((var body1, var body2) in bodyCombinations)
            {
                body1.CalculateAcceleration(body2);
            }

            OrbitalBodies.ForEach(x => x.ApplyAcceleration());

            OrbitalBodies.ForEach(x => x.ApplyVelocity());
        }

        public float GetSystemEnergy() => OrbitalBodies.Select(x => x.GetTotalEnergy()).Sum();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var body in OrbitalBodies)
            {
                sb.Append(body.ToString());
            }
            return sb.ToString();
        }

        public double GetNumberOfStepsPerCycle()
        {
            long x_cycle = 0;
            long y_cycle = 0;
            long z_cycle = 0;

            List<float> xStartPosition = OrbitalBodies.Select(x => x.Position.X).ToList();
            List<float> xStartVelocity = OrbitalBodies.Select(x => x.Velocity.X).ToList();

            List<float> yStartPosition = OrbitalBodies.Select(x => x.Position.Y).ToList();
            List<float> yStartVelocity = OrbitalBodies.Select(x => x.Velocity.Y).ToList();

            List<float> zStartPosition = OrbitalBodies.Select(x => x.Position.Z).ToList();
            List<float> zStartVelocity = OrbitalBodies.Select(x => x.Velocity.Z).ToList();

            long iterations = 0;
            while (x_cycle == 0 || y_cycle == 0 || z_cycle == 0)
            {
                DoTimeStep();
                iterations++;

                if (OrbitalBodies.Select(x => x.Position.X).ToList().SequenceEqual(xStartPosition)
                    && OrbitalBodies.Select(x => x.Velocity.X).ToList().SequenceEqual(xStartVelocity))
                {
                    x_cycle = iterations;
                }

                if (OrbitalBodies.Select(x => x.Position.Y).ToList().SequenceEqual(yStartPosition)
                    && OrbitalBodies.Select(x => x.Velocity.Y).ToList().SequenceEqual(yStartVelocity))
                {
                    y_cycle = iterations;
                }

                if (OrbitalBodies.Select(x => x.Position.Z).ToList().SequenceEqual(zStartPosition)
                    && OrbitalBodies.Select(x => x.Velocity.Z).ToList().SequenceEqual(zStartVelocity))
                {
                    z_cycle = iterations;
                }

            }

            return SharedLibrary.MathLib.GetLCM(new List<double> { x_cycle, y_cycle, z_cycle });
        }
    }
}
