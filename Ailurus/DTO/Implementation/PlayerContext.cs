using System.Collections.Generic;

namespace Ailurus.DTO
{
    public class PlayerContext<TCoordinate> : IPlayerContext<TCoordinate> where TCoordinate : ICoordinate
    {
        public IEnumerable<IDrone<TCoordinate>> Drones { get; set; }
    }
}