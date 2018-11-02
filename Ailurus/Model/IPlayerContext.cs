using System.Collections.Generic;
using Ailurus.DTO.Responses.Interfaces;

namespace Ailurus.Model
{
    public interface IPlayerContext
    {
        IEnumerable<IDrone> Drones { get; set; }
        string PlayerName { get; set; }
        string Pass { get; set; }
        int Level { get; set; }
        IEnumerable<ResourceQuantity> Resources { get; }
        bool IsGoalAchieved();
        bool IsGoalAchieved(IEnumerable<ResourceQuantity> goal);
        IMapInfo GetMap();
    }
}