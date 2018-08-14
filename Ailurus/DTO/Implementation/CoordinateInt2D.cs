using System;

namespace Ailurus.DTO
{
    public class CoordinateInt2D : ICoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public double GetDistanceTo(ICoordinate destination)
        {
            var dest = destination as CoordinateInt2D;
            return Math.Sqrt(X * dest.X + Y * dest.Y);
        }
    }
}
