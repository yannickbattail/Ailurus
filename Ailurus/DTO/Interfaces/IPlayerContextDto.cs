﻿using System.Collections.Generic;
using Ailurus.Model;

namespace Ailurus.DTO.Interfaces
{
    public interface IPlayerContextDto
    {
        IEnumerable<IDroneDto> Drones { get; set; }
        string PlayerName { get; set; }
        IEnumerable<ResourceQuantity> Resources { get; set; }
        bool GoalAchieved { get; set; }
    }
}