using Ailurus.DTO.Responses.Interfaces;
using Ailurus.Model;
using System;
using System.Collections.Generic;

namespace Ailurus.DTO.Responses.Implementations
{
    public class PlayerContextDto : IPlayerContextDto
    {
        public IEnumerable<IDroneDto> Drones { get; set; }
        public string PlayerName { get; set; }
        public int Level { get; set; }
        public IEnumerable<ResourceQuantity> Resources { get; set; }
        public bool IsResourceGoalAchieved { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? TimeWhenResoucesGoalIsAchieved { get; set; }
        public TimeSpan? SpentTime { get; set; }
        public bool IsTimeGoalAchieved { get; set; }
    }
}