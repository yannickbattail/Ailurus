using System.Collections.Generic;

namespace Ailurus.Model
{
    public interface IPlayerContext
    {
        IEnumerable<IDrone> Drones { get; set; }
        string PlayerName { get; set; }
        string Pass { get; set; }
        IEnumerable<ResourceQuantity> Resources { get; }
    }
}