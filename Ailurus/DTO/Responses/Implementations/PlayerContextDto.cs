using System.Collections.Generic;
using Ailurus.DTO.Responses.Interfaces;
using Ailurus.Model;

namespace Ailurus.DTO.Responses.Implementations
{
    public class PlayerContextDto : IPlayerContextDto
    {
        public IEnumerable<IDroneDto> Drones { get; set; }
        public string PlayerName { get; set; }
        public int Level { get; set; }
        public IEnumerable<ResourceQuantity> Resources { get; set; }
        public bool GoalAchieved { get; set; }
    }
}