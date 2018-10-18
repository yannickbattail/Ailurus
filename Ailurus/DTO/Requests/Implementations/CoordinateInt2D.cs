using System;
using Ailurus.DTO.Requests.Interfaces;

namespace Ailurus.DTO.Requests.Implementations
{
    public class CoordinateInt2D : ICoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
        
        public double GetDistanceTo(ICoordinate destination)
        {
            return GetDistanceTo(destination as CoordinateInt2D);
        }
        
        public double GetDistanceTo(CoordinateInt2D destination)
        {
            return Math.Sqrt(Math.Pow(destination.X-this.X, 2) + Math.Pow(destination.Y-this.Y, 2));
        }
        
        public bool IsNear(ICoordinate point)
        {
            return IsNear(point as CoordinateInt2D);
        }
        
        public bool IsNear(CoordinateInt2D point)
        {
            if (point == null)
            {
                throw new ArgumentNullException();
            }
            return this.X == point.X && this.Y == point.Y;
        }

        public bool IsInside(Tuple<ICoordinate, ICoordinate> area)
        {
            return IsInside(Tuple.Create(area.Item1 as CoordinateInt2D, area.Item2 as CoordinateInt2D));
        }

        public bool IsInside(Tuple<CoordinateInt2D, CoordinateInt2D> area)
        {
            var areaMin = area.Item1;
            var areaMax = area.Item2;
            return this.X >= areaMin.X && this.Y >= areaMin.Y
                                  && this.X <= areaMax.X && this.Y <= areaMax.Y;
        }

        public ICoordinate ForceInside(Tuple<ICoordinate, ICoordinate> area)
        {
            return ForceInside(Tuple.Create(area.Item1 as CoordinateInt2D, area.Item2 as CoordinateInt2D));
        }

        public CoordinateInt2D ForceInside(Tuple<CoordinateInt2D, CoordinateInt2D> area)
        {
            var areaMin = area.Item1;
            var areaMax = area.Item2;
            var newCoordinate = new CoordinateInt2D()
            {
                X = this.X,
                Y = this.Y
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

        public ICoordinate PathProgression(ICoordinate destination, double progression)
        {
            return PathProgression(destination as CoordinateInt2D, progression);
        }

        public CoordinateInt2D PathProgression(CoordinateInt2D destination, double progression)
        {
            if (progression < 0 || progression > 1)
            {
                throw new Exception("progression must be a percentage between 0 and 1 (including)");
            }
            return new CoordinateInt2D()
            {
                X = (int) Math.Round((destination.X - this.X) * progression + this.X),
                Y = (int) Math.Round((destination.Y - this.Y) * progression + this.Y)
            };
        }
    }
}
