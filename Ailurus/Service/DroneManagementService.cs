using System;
using System.Collections.Generic;
using System.Linq;
using Ailurus.DTO;
using Ailurus.DTO.Implementation;
using Ailurus.DTO.Interfaces;
using Ailurus.Mapper.Implementation;
using Ailurus.Repository;

namespace Ailurus.Service
{
    public class DroneManagementService<TCoordinate> where TCoordinate : ICoordinate
    {
        private IPlayerContext<TCoordinate> PlayerContext;
        private IPlayerContextRepository<TCoordinate> Repository;
        
        public DroneManagementService(string playerName)
        {
            Repository = new PlayerContextRepository<TCoordinate>();
            PlayerContext = Repository.GetPlayerContextByPlayerName(playerName);
        }

        public IEnumerable<string> ProcessInstructions(IEnumerable<GlobalInstruction<TCoordinate>> instructions)
        {
            var messages = instructions.Select(
                ProcessInstruction
            );
            Repository.Save(PlayerContext);
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
                    return "drone is already doing an action "+drone.GetLastValidInstruction().GetType().Name;
                }

                var mapper = new InstructionMapper<TCoordinate>();
                drone.Instructions.Add(mapper.ToSpecificInstruction(globInstruction, drone, DateTime.Now));
                return "OK, drone will do "+drone.GetLastValidInstruction().GetType().Name;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                return "no such drone named: "+globInstruction.DroneName;
            }
        }
    }
}