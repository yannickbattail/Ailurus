using System;
using Ailurus.DTO.Interfaces;

namespace Ailurus.DTO.Implementation
{
    public class CoordinateInt2D : ICoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }
    }
}
