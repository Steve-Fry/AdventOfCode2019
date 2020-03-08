using System;
using System.Numerics;

namespace Advent_of_Code.Day_12
{
    internal class OrbitalBody
    {
        public Vector3 Position { get; set; }
        public Vector3 Acceleration { get; set; }
        public Vector3 Velocity { get; set; }

        public OrbitalBody(Vector3 position)
        {
            Position = position;
            Acceleration = Vector3.Zero;
            Velocity = Vector3.Zero;
        }

        public (float Position, float Velocity) GetDimension(int dim)
        {
            return dim switch
            {
                0 => (Position: Position.X, Velocity: Velocity.X),
                1 => (Position: Position.Y, Velocity: Velocity.Y),
                2 => (Position: Position.Z, Velocity: Velocity.Z),
                _ => throw new ArgumentException("Dim must be in the range 0-2"),
            };
        }

        public float GetKeneticEnergy()
        {
            var v = Vector3.Abs(Velocity);
            return v.X + v.Y + v.Z;
        }

        internal void SetDimension(int dim, (float pos, float vel) state)
        {
            switch (dim)
            {
                case 0:
                    Position = new Vector3(state.pos, Position.Y, Position.Z);
                    Velocity = new Vector3(state.vel, Velocity.Y, Velocity.Z);
                    break;
                case 1:
                    Position = new Vector3(Position.X, state.pos, Position.Z);
                    Velocity = new Vector3(Velocity.X, state.vel, Velocity.Z);
                    break;
                case 2:
                    Position = new Vector3(Position.X, Position.Y, state.pos);
                    Velocity = new Vector3(Velocity.X, Velocity.Y, state.vel);
                    break;
                default:
                    throw new ArgumentException("Invalid Dimension - must be 0,1,2");
            }
        }

        public float GetPotentialEnergy()
        {
            var v = Vector3.Abs(Position);
            return v.X + v.Y + v.Z;
        }

        public float GetTotalEnergy() => GetPotentialEnergy() * GetKeneticEnergy();

        public override string ToString()
        {
            (float px, float py, float pz) = (Position.X, Position.Y, Position.Z);
            (float vx, float vy, float vz) = (Velocity.X, Velocity.Y, Velocity.Z);

            return $"pos=<x={px}, y={py}, z={pz}>, vel=<x={vx}, y={vy}, z={vz}>";
        }
    }
}
