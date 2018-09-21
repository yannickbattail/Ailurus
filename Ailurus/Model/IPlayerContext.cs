using System.Collections.Generic;
using Ailurus.DTO.Interfaces;

namespace Ailurus.Model
{
    public interface IPlayerContext
    {
        IEnumerable<IDrone> Drones { get; set; }
        string PlayerName { get; set; }
        IEnumerable<ResourceQuantity> Resources { get; }
    }
}