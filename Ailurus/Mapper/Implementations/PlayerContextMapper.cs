using System.Linq;
using Ailurus.DTO.Requests.Interfaces;
using Ailurus.DTO.Responses.Implementations;
using Ailurus.DTO.Responses.Interfaces;
using Ailurus.Mapper.Interfaces;
using Ailurus.Model;

namespace Ailurus.Mapper.Implementations
{
    public class PlayerContextMapper : IPlayerContextMapper
    {
        public IPlayerContextDto Map(IPlayerContext playerContext)
        {
            return new PlayerContextDto()
            {
                Drones = playerContext.Drones.Select(Map),
                PlayerName = playerContext.PlayerName,
                Resources = playerContext.Resources,
                GoalAchieved = playerContext.IsGoalAchieved()
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