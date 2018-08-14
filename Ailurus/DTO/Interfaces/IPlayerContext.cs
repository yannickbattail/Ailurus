using System.Collections.Generic;

namespace Ailurus.DTO
{
    public interface IPlayerContext<TCoordinate> where TCoordinate : ICoordinate
    {
        IEnumerable<IDrone<TCoordinate>> Drones { get; set; }
    }
}