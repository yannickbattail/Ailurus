using System.Collections.Generic;
using Ailurus.Model;

namespace Ailurus.DTO.Interfaces
{
    public interface IPlayerContextDto<TCoordinate> where TCoordinate : ICoordinate
    {
        IEnumerable<IDroneDto<TCoordinate>> Drones { get; set; }
    }
}