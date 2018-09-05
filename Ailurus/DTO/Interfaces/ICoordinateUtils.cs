using System;

namespace Ailurus.DTO.Interfaces
{
    public interface ICoordinateUtils<TCoordinate> where TCoordinate : ICoordinate
    {
        double GetDistanceTo(TCoordinate origin, TCoordinate destination);
        bool IsNear(TCoordinate pointA, TCoordinate pointB);
        bool IsInside(TCoordinate coord, Tuple<TCoordinate, TCoordinate> area);
        TCoordinate ForceInside(TCoordinate coord, Tuple<TCoordinate, TCoordinate> area);
        TCoordinate PathProgression(TCoordinate origin, TCoordinate destination, double progression);
    }
}