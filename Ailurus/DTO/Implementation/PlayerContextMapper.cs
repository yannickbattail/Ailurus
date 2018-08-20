using System.Linq;
using Ailurus.DTO.Interfaces;
using Ailurus.Model;

namespace Ailurus.DTO.Implementation
{
    public class PlayerContextMapper<TCoordinate> where TCoordinate : ICoordinate
    {
        public PlayerContextDto<TCoordinate> map(IPlayerContext<TCoordinate> playerContext)
        {
            return new PlayerContextDto<TCoordinate>()
            {
                Drones = playerContext.Drones.Select(d => map(d))
            };
        }

        public IDroneDto<TCoordinate> map(IDrone<TCoordinate> drone)
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