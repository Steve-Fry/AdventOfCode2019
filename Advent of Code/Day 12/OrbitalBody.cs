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

        public float GetKeneticEnergy()
        {
            var v = Vector3.Abs(Velocity);
            return v.X + v.Y + v.Z;
        }

        public float GetPotentialEnergy()
        {
            var v = Vector3.Abs(Position);
            return v.X + v.Y + v.Z;
        }

        public float GetTotalEnergy() => GetPotentialEnergy() * GetKeneticEnergy();

        public void CalculateAcceleration(OrbitalBody body)
        {
            Acceleration += new Vector3(
                GetAccelerationDirection(this.Position.X, body.Position.X),
                GetAccelerationDirection(this.Position.Y, body.Position.Y),
                GetAccelerationDirection(this.Position.Z, body.Position.Z)
                );
        }

        private int GetAccelerationDirection(double v1, double v2)
        {
            if (v1 > v2) { return -1; }
            else if (v1 < v2) { return +1; }
            else if (v1 == v2) { return 0; }
            else { throw new ArgumentException($"Invalid values of v1 and v2 {v1}, {v2}"); }
        }

        public void ApplyAcceleration()
        {
            Velocity += Acceleration;
            Acceleration = Vector3.Zero;
        }

        public void ApplyVelocity()
        {
            Position += Velocity;
        }

        public override string ToString()
        {
            (float px, float py, float pz) = (Position.X, Position.Y, Position.Z);
            (float vx, float vy, float vz) = (Velocity.X, Velocity.Y, Velocity.Z);

            return $"pos=<x={px}, y={py}, z={pz}>, vel=<x={vx}, y={vy}, z={vz}>";
        }
    }
}
