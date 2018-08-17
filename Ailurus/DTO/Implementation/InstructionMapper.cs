using System;
using Ailurus.DTO.Implementation.DroneInstruction;

namespace Ailurus.DTO.Implementation
{
    public class InstructionMapper<TCoordinate> : IInstructionMapper<TCoordinate> where TCoordinate : ICoordinate
    {
        public IDroneInstruction<TCoordinate> ToSpecificInstruction(GlobalInstruction<TCoordinate> globalInstruction)
        {
            if (globalInstruction.TYPE == typeof(CollectDto<TCoordinate>).Name)
            {
                return new CollectDto<TCoordinate>()
                {
                    DroneName = globalInstruction.DroneName
                };
            }
            if (globalInstruction.TYPE == typeof(MoveToDto<TCoordinate>).Name)
            {
                return new MoveToDto<TCoordinate>()
                {
                    DroneName = globalInstruction.DroneName,
                    Destination = globalInstruction.Destination
                };
            } 
            if (globalInstruction.TYPE == typeof(UnloadDto<TCoordinate>).Name)
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