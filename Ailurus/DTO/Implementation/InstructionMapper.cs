using System;
using Ailurus.DTO.Implementation.DroneInstruction;
using Ailurus.Model.Instructions;

namespace Ailurus.DTO.Implementation
{
    public class InstructionMapper<TCoordinate> : IInstructionMapper<TCoordinate> where TCoordinate : ICoordinate
    {
        public IInstruction<TCoordinate> ToSpecificInstruction(
            GlobalInstruction<TCoordinate> globalInstruction,
            IDrone<TCoordinate> drone,
            DateTime startedAt)
        {
            if (globalInstruction.TYPE == "Collect")
            {
                return new Collect<TCoordinate>(drone, startedAt);
            }
            if (globalInstruction.TYPE == "MoveToDto")
            {
                return new MoveTo<TCoordinate>(drone,startedAt,globalInstruction.Destination,drone.CurrentPosition);
            } 
            if (globalInstruction.TYPE == "UnloadDto")
            {
                return new Unload<TCoordinate>(drone,startedAt);
            }
            throw new Exception("Unknown instruction type "+globalInstruction.TYPE);
        }
    }
}