using System;
using Ailurus.DTO.Requests.Implementations;
using Ailurus.Mapper.Interfaces;
using Ailurus.Model;
using Ailurus.Model.Instructions;

namespace Ailurus.Mapper.Implementations
{
    public class InstructionMapper : IInstructionMapper
    {
        private IPlayerContext PlayerContext;

        public InstructionMapper(IPlayerContext playerContext)
        {
            PlayerContext = playerContext;
        }
        
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
                    return new Collect(PlayerContext, drone, startedAt);
                case "MoveTo":
                    return new MoveTo(PlayerContext, drone,startedAt,drone.CurrentPosition, globalInstruction.Destination);
                case "Unload":
                    return new Unload(PlayerContext, drone,startedAt);
                default:
                    throw new ArgumentException("Unknown instruction type "+globalInstruction.TYPE);
            }
        }
    }
}