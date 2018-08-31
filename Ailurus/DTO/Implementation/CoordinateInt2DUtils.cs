using System;
using Ailurus.DTO.Interfaces;

namespace Ailurus.DTO.Implementation
{
    public class CoordinateInt2DUtils : ICoordinateUtils<CoordinateInt2D>
    {
        public double GetDistanceTo(CoordinateInt2D origin, CoordinateInt2D destination)
        {
            return Math.Sqrt(Math.Pow(destination.X-origin.X, 2) + Math.Pow(destination.Y-origin.Y, 2));
        }

        public bool IsInside(CoordinateInt2D coord, Tuple<CoordinateInt2D, CoordinateInt2D> area)
        {
            var areaMin = area.Item1;
            var areaMax = area.Item2;
            return coord.X >= areaMin.X && coord.Y >= areaMin.Y
                                  && coord.X <= areaMax.X && coord.Y <= areaMax.Y;
        }

        public CoordinateInt2D ForceInside(CoordinateInt2D coord, Tuple<CoordinateInt2D, CoordinateInt2D> area)
        {
            var areaMin = area.Item1;
            var areaMax = area.Item2;
            var newCoordinate = new CoordinateInt2D()
            {
                X = coord.X,
                Y = coord.Y
            };
            if (newCoordinate.X < areaMin.X)
            {
                newCoordinate.X = areaMin.X;
            }
            if (newCoordinate.Y < areaMin.Y)
            {
                newCoordinate.Y = areaMin.Y;
            }
            if (newCoordinate.X > areaMax.X)
            {
                newCoordinate.X = areaMax.X;
            }
            if (newCoordinate.Y > areaMax.Y)
            {
                newCoordinate.Y = areaMax.Y;
            }
            return newCoordinate;
        }
    }
}
