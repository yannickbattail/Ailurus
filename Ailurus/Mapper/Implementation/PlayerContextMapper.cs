using System.Linq;
using Ailurus.DTO.Implementation;
using Ailurus.DTO.Interfaces;
using Ailurus.Mapper.Interfaces;
using Ailurus.Model;

namespace Ailurus.Mapper.Implementation
{
    public class PlayerContextMapper : IPlayerContextMapper
    {
        public IPlayerContextDto Map(IPlayerContext playerContext)
        {
            return new PlayerContextDto()
            {
                Drones = playerContext.Drones.Select(Map),
                PlayerName = playerContext.PlayerName,
                Resources = playerContext.Resources
            };
        }

        public IDroneDto Map(IDrone drone)
        {
            return new DroneDto()
            {
                CurrentPosition = drone.CurrentPosition,
                LastInstruction = drone.GetLastValidInstruction(),
                Name = drone.Name,
                Speed = drone.Speed,
                State = drone.State,
                StorageSize = drone.StorageSize,
                Storage = drone.Storage
            };
        }
    }
}