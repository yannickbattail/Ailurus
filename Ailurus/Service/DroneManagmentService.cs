using System;
using System.Collections.Generic;
using System.Linq;
using Ailurus.DTO;
using Ailurus.DTO.Implementation;
using Ailurus.DTO.Implementation.DroneInstruction;
using Ailurus.DTO.Interfaces;

namespace Ailurus.Service
{
    public class DroneManagmentService<TCoordinate> where TCoordinate : ICoordinate
    {
        private IPlayerContext<TCoordinate> PlayerContext;

        public DroneManagmentService(IPlayerContext<TCoordinate> playerContext)
        {
            PlayerContext = playerContext ?? throw new ArgumentNullException(nameof(playerContext));
        }

        public IEnumerable<string> ProcessInstructions(IEnumerable<GlobalInstruction<TCoordinate>> instructions)
        {
            return instructions.Select(
                ProcessInstruction
            );
        }
        
        public string ProcessInstruction(GlobalInstruction<TCoordinate> globInstruction)
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
                drone.LastInstruction = globInstruction.ToIInstruction(DateTime.Now, drone);
                return "OK, drone will do "+drone.LastInstruction.GetType().Name;
                
            }
            catch (InvalidOperationException e)
            {
                return "no such drone named: "+globInstruction.DroneName;
            }
        }
    }
}