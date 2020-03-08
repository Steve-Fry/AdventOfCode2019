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

        public void DoTimeSteps(int steps)
        {

            for (int dim = 0; dim < 3; dim++)
            {
                List<(float Position, float Velocity)> states = OrbitalBodies.Select(x => x.GetDimension(dim)).ToList();

                for (int s = 0; s < steps; s++)
                {
                    var oldStateWithNewVelocity = states.Select(x => (x.Position, Velocity: GetNewVelocity(x, states) + x.Velocity));
                    states = oldStateWithNewVelocity.Select(x => (Position: x.Position + x.Velocity, x.Velocity)).ToList();
                }

                var statesList = states.ToList();
                for (int b = 0; b < OrbitalBodies.Count; b++)
                {
                    OrbitalBodies[b].SetDimension(dim, statesList[b]);
                }
            }
        }

        private float GetNewVelocity((float Position, float Velocity) target, IEnumerable<(float Position, float Velocity)> others)
        {

            return (from other in others
                    where other != target
                    select GetAcceleration(target, other)).Sum();
        }

        private float GetAcceleration((float Position, float Velocity) target, (float Position, float Velocity) other)
        {
            return Math.Sign(other.Position - target.Position);
        }

        public void DoTimeStep() => DoTimeSteps(1);

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
            List<double> cycleLengths = new List<double>();

            for (int dim = 0; dim < 3; dim++)
            {
                var previousStates = new HashSet<(float, float, float, float, float, float, float, float)>();

                List<(float Position, float Velocity)> states = OrbitalBodies.Select(x => x.GetDimension(dim)).ToList();
                previousStates.Add((states[0].Position, states[1].Position, states[2].Position, states[3].Position,
                                    states[0].Velocity, states[1].Velocity, states[2].Velocity, states[3].Velocity));

                int cycles = 0;
                while (true)
                {
                    var oldStateWithNewVelocity = states.Select(x => (x.Position, Velocity: GetNewVelocity(x, states) + x.Velocity));
                    states = oldStateWithNewVelocity.Select(x => (Position: x.Position + x.Velocity, x.Velocity)).ToList();

                    cycles++;

                    var state = (states[0].Position, states[1].Position, states[2].Position, states[3].Position,
                                 states[0].Velocity, states[1].Velocity, states[2].Velocity, states[3].Velocity);


                    if (previousStates.Contains(state))
                    {
                        cycleLengths.Add(cycles);
                        break;
                    }
                    else
                    {
                        previousStates.Add(state);
                    }
                }
            }

            return SharedLibrary.MathLib.GetLCM(cycleLengths);
        }
    }
}

