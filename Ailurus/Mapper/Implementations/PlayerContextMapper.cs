using Ailurus.DTO.Responses.Implementations;
using Ailurus.DTO.Responses.Interfaces;
using Ailurus.Mapper.Interfaces;
using Ailurus.Model;
using System.Linq;

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
                Level = playerContext.Level,
                Resources = playerContext.Resources,
                IsResourceGoalAchieved = playerContext.IsResourceGoalAchieved(),
                StartTime = playerContext.GetStartTime(),
                TimeWhenResoucesGoalIsAchieved = playerContext.GetTimeWhenResoucesGoalIsAchieved(),
                SpentTime = playerContext.GetSpentTime(),
                IsTimeGoalAchieved = playerContext.IsTimeGoalAchieved()
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