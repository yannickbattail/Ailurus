using System.Collections.Generic;
using Ailurus.DTO.Interfaces;

namespace Ailurus.Model
{
    public interface IPlayerContext<TCoordinate> where TCoordinate : ICoordinate
    {
        IEnumerable<IDrone<TCoordinate>> Drones { get; set; }
        string PlayerName { get; set; }
        IEnumerable<ResourceQuantity> Resources { get; }
    }
}