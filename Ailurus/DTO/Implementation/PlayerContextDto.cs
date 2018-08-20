using System.Collections.Generic;
using Ailurus.DTO.Interfaces;
using Ailurus.Model;

namespace Ailurus.DTO.Implementation
{
    public class PlayerContextDto<TCoordinate> : IPlayerContextDto<TCoordinate> where TCoordinate : ICoordinate
    {
        public IEnumerable<IDroneDto<TCoordinate>> Drones { get; set; }
    }
}