using Ailurus.DTO.Responses.Interfaces;
using System;
using System.Collections.Generic;

namespace Ailurus.Model
{
    public interface IPlayerContext
    {
        IEnumerable<IDrone> Drones { get; set; }
        string PlayerName { get; set; }
        string Pass { get; set; }
        int Level { get; set; }
        IEnumerable<ResourceQuantity> Resources { get; }
        bool IsResourceGoalAchieved();
        bool IsResourceGoalAchieved(IEnumerable<ResourceQuantity> goal);
        DateTime? GetStartTime();
        DateTime? GetTimeWhenResoucesGoalIsAchieved();
        TimeSpan? GetSpentTime();
        bool IsTimeGoalAchieved();
        IMapInfo GetMap();
    }
}