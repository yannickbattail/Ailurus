using System;

namespace Ailurus.DTO
{
    public interface ICoordinate
    {
        Double GetDistanceTo(ICoordinate destination);
    }
}