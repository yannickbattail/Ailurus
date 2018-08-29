﻿using System.Linq;
using Ailurus.DTO.Interfaces;
using Ailurus.Model;

namespace Ailurus.DTO.Implementation
{
    public class PlayerContextMapper<TCoordinate> where TCoordinate : ICoordinate
    {
        public PlayerContextDto<TCoordinate> Map(IPlayerContext<TCoordinate> playerContext)
        {
            return new PlayerContextDto<TCoordinate>()
            {
                Drones = playerContext.Drones.Select(d => Map(d))
            };
        }

        public IDroneDto<TCoordinate> Map(IDrone<TCoordinate> drone)
        {
            return new DroneDto<TCoordinate>()
            {
                CurrentPosition = drone.CurrentPosition,
                LastInstruction = drone.LastInstruction,
                Name = drone.Name,
                Speed = drone.Speed,
                State = drone.State
            };
        }
    }
}