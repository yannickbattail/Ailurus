using System;
using System.Collections.Generic;
using Ailurus.Model;

namespace Ailurus.DTO.Responses.Interfaces
{
    public interface IPlayerContextDto
    {
        IEnumerable<IDroneDto> Drones { get; set; }
        string PlayerName { get; set; }
        int Level { get; set; }
        IEnumerable<ResourceQuantity> Resources { get; set; }
        bool GoalAchieved { get; set; }
        DateTime DateStart { get; set; }
    }
}