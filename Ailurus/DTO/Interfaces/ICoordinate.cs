using System;

namespace Ailurus.DTO.Interfaces
{
    public interface ICoordinate
    {
        double GetDistanceTo(ICoordinate destination);
        bool IsNear(ICoordinate point);
        bool IsInside(Tuple<ICoordinate, ICoordinate> area);
        ICoordinate ForceInside(Tuple<ICoordinate, ICoordinate> area);
        ICoordinate PathProgression(ICoordinate destination, double progression);
    }
}