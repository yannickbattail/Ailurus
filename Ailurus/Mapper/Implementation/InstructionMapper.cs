using System;
using Ailurus.DTO.Implementation;
using Ailurus.DTO.Interfaces;
using Ailurus.Mapper.Interfaces;
using Ailurus.Model;
using Ailurus.Model.Instructions;

namespace Ailurus.Mapper.Implementation
{
    public class InstructionMapper : IInstructionMapper
    {
        public IInstruction ToSpecificInstruction(
            GlobalInstruction globalInstruction,
            IDrone drone,
            DateTime startedAt)
        {
            if (globalInstruction == null)
            {
                throw new ArgumentException("globalInstruction is null");
            }
            if (drone == null)
            {
                throw new ArgumentException("drone is null");
            }
            
            switch (globalInstruction.TYPE)
            {
                case "Collect":
                    return new Collect(drone, startedAt);
                case "MoveTo":
                    return new MoveTo(drone,startedAt,drone.CurrentPosition, globalInstruction.Destination);
                case "Unload":
                    return new Unload(drone,startedAt);
                default:
                    throw new ArgumentException("Unknown instruction type "+globalInstruction.TYPE);
            }
        }
    }
}