using System.Collections.Generic;
using Ailurus.Model;

namespace Ailurus.DTO.Interfaces
{
    public interface IPlayerContext<TCoordinate> where TCoordinate : ICoordinate
    {
        IEnumerable<IDrone<TCoordinate>> Drones { get; set; }
        string PlayerName { get; set; }
        IEnumerable<ResourceQuantity> Resources { get; }
    }
}