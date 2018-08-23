using System;
using System.Collections.Generic;
using System.Linq;
using Ailurus.DTO;
using Ailurus.DTO.Implementation;
using Ailurus.DTO.Interfaces;
using Ailurus.Repository;

namespace Ailurus.Service
{
    public class DroneManagmentService<TCoordinate> where TCoordinate : ICoordinate
    {
        private IPlayerContext<TCoordinate> PlayerContext;
        private IPlayerContextRepository<TCoordinate> Repository;
        
        public DroneManagmentService(string playerName)
        {
            Repository = new PlayerContextRepository<TCoordinate>();
            PlayerContext = Repository.GetPlayerContextByPlayerName(playerName);
        }

        public IEnumerable<string> ProcessInstructions(IEnumerable<GlobalInstruction<TCoordinate>> instructions)
        {
            var messages = instructions.Select(
                ProcessInstruction
            );
            Repository.Save(PlayerContext.PlayerName, PlayerContext);
            return messages;
        }
        
        private string ProcessInstruction(GlobalInstruction<TCoordinate> globInstruction)
        {
            try
            {
                var drone = PlayerContext.Drones.First(
                    dr => dr.Name == globInstruction.DroneName
                );
                if (drone.State == DroneState.ExecutionInstruction)
                {
                    return "drone is alrady doing an action "+drone.LastInstruction.GetType().Name;
                }

                var mapper = new InstructionMapper<TCoordinate>();
                drone.LastInstruction = mapper.ToSpecificInstruction(globInstruction, drone, DateTime.Now);
                drone.LastInstruction.DoIt();
                return "OK, drone will do "+drone.LastInstruction.GetType().Name;
            }
            catch (InvalidOperationException e)
            {
                return "no such drone named: "+globInstruction.DroneName;
            }
        }
    }
}