using Ailurus.Model;
using System;
using System.Collections.Generic;

namespace Ailurus.DTO.Responses.Interfaces
{
    public interface IPlayerContextDto
    {
        IEnumerable<IDroneDto> Drones { get; set; }
        string PlayerName { get; set; }
        int Level { get; set; }
        IEnumerable<ResourceQuantity> Resources { get; set; }
        bool IsResourceGoalAchieved { get; set; }
        DateTime? StartTime { get; set; }
        DateTime? TimeWhenResoucesGoalIsAchieved { get; set; }
        TimeSpan? SpentTime { get; set; }
        bool IsTimeGoalAchieved { get; set; }
    }
}