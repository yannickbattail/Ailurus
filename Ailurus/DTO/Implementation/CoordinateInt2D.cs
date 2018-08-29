using System;
using Ailurus.DTO.Interfaces;

namespace Ailurus.DTO.Implementation
{
    public class CoordinateInt2D : ICoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public double GetDistanceTo(ICoordinate destination)
        {
            var dest = destination as CoordinateInt2D;
            return Math.Sqrt(Math.Pow(dest.X-X, 2) + Math.Pow(dest.Y-Y, 2));
        }
    }
}
