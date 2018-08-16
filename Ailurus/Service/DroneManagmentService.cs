using System;
using System.Collections.Generic;
using System.Linq;
using Ailurus.DTO;
using Ailurus.Repository;
using SQLitePCL;

namespace Ailurus.Service
{
    public class DroneManagmentService<TCoordinate> where TCoordinate : ICoordinate
    {
        private IPlayerContext<TCoordinate> PlayerContext;

        public DroneManagmentService(IPlayerContext<TCoordinate> playerContext)
        {
            PlayerContext = playerContext ?? throw new ArgumentNullException(nameof(playerContext));
        }

        public IEnumerable<string> ProcessInstructions(Instructions<TCoordinate> instructions)
        {
            return instructions.DroneInstruction.Select(
                ProcessInstruction
            );
        }
        
        public string ProcessInstruction(IDroneInstruction<TCoordinate> instruction)
        {
            try
            {
                var drone = PlayerContext.Drones.First(
                    dr => dr.Name == instruction.DroneName
                );
                if (drone.DroneState == DroneState.ExecutionInstruction 
                    && drone.LastInstruction != null)
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