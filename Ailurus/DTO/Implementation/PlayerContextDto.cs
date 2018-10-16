using System.Collections.Generic;
using Ailurus.DTO.Interfaces;
using Ailurus.Model;

namespace Ailurus.DTO.Implementation
{
    public class PlayerContextDto : IPlayerContextDto
    {
        public IEnumerable<IDroneDto> Drones { get; set; }
        public string PlayerName { get; set; }
        public IEnumerable<ResourceQuantity> Resources { get; set; }
        public bool GoalAchieved { get; set; }
    }
}