using System.Linq;
using Ailurus.DTO.Implementation;
using Ailurus.DTO.Interfaces;
using Ailurus.Mapper.Interfaces;
using Ailurus.Model;

namespace Ailurus.Mapper.Implementation
{
    public class PlayerContextMapper<TCoordinate> : IPlayerContextMapper<TCoordinate> where TCoordinate : ICoordinate
    {
        public IPlayerContextDto<TCoordinate> Map(IPlayerContext<TCoordinate> playerContext)
        {
            return new PlayerContextDto<TCoordinate>()
            {
                Drones = playerContext.Drones.Select(Map),
                PlayerName = playerContext.PlayerName,
                Resources = playerContext.Resources
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
                State = drone.State,
                StorageSize = drone.StorageSize,
                Storage = drone.Storage
            };
        }
    }
}