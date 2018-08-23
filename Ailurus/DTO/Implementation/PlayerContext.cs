using System.Collections.Generic;
using Ailurus.DTO.Interfaces;
using Ailurus.Model;

namespace Ailurus.DTO.Implementation
{
    public class PlayerContext<TCoordinate> : IPlayerContext<TCoordinate> where TCoordinate : ICoordinate
    {
        public IEnumerable<IDrone<TCoordinate>> Drones { get; set; }
        public string PlayerName { get; set; }

    }
}