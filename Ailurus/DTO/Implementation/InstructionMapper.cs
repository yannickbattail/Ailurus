using System;
using Ailurus.DTO.Implementation.DroneInstruction;

namespace Ailurus.DTO.Implementation
{
    public class InstructionMapper<TCoordinate> : IInstructionMapper<TCoordinate> where TCoordinate : ICoordinate
    {
        public IDroneInstruction<TCoordinate> ToSpecificInstruction(GlobalInstruction<TCoordinate> globalInstruction)
        {
            if (globalInstruction.TYPE == "CollectDto")
            {
                return new CollectDto<TCoordinate>()
                {
                    DroneName = globalInstruction.DroneName
                };
            }
            if (globalInstruction.TYPE == "MoveToDto")
            {
                return new MoveToDto<TCoordinate>()
                {
                    DroneName = globalInstruction.DroneName,
                    Destination = globalInstruction.Destination
                };
            } 
            if (globalInstruction.TYPE == "UnloadDto")
            {
                return new UnloadDto<TCoordinate>()
                {
                    DroneName = globalInstruction.DroneName
                };
            }
            throw new Exception("Unknown instruction type "+globalInstruction.TYPE);
        }
    }
}