using System;
using System.Collections.Generic;
using System.Linq;
using Ailurus.DTO;
using Ailurus.Repository;

namespace Ailurus.Service
{
    public class DroneManagmentService<TCoordinate> where TCoordinate : ICoordinate
    {
        private IPlayerContextRepository<TCoordinate> Repository;

        public DroneManagmentService(IPlayerContextRepository<TCoordinate> repository)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<string> ProcessInstructions(IEnumerable<IDroneInstruction<TCoordinate>> instructions, string playerName)
        {
            
            var context = Repository.GetPlayerContextByPlayerName(playerName);
            var messages = instructions.Select(
                instruction => ProcessInstruction(instruction, context)
            );
            Repository.SavePlayerContextByPlayerName(playerName, context);
            return messages;
        }
        
        private string ProcessInstruction(IDroneInstruction<TCoordinate> instruction, IPlayerContext<TCoordinate> context)
        {
            try
            {
                var drone = context.Drones.First(
                    dr => dr.Name == instruction.DroneName
                );
                if (drone.State == DroneState.ExecutionInstruction)
                {
                    return "drone is alrady doing an action "+drone.LastInstruction.TYPE;
                }
                drone.LastInstruction = instruction.ToIInstruction(DateTime.Now, drone);
                return "OK, drone will do "+drone.LastInstruction.TYPE;
                
            }
            catch (InvalidOperationException e)
            {
                return "no such drone named: "+instruction.DroneName;
            }
        }
    }
}