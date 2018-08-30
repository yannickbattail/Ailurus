using System;
using Ailurus.DTO.Implementation;
using Ailurus.DTO.Interfaces;
using Ailurus.Mapper.Interfaces;
using Ailurus.Model;
using Ailurus.Model.Instructions;

namespace Ailurus.Mapper.Implementation
{
    public class InstructionMapper<TCoordinate> : IInstructionMapper<TCoordinate> where TCoordinate : ICoordinate
    {
        public IInstruction<TCoordinate> ToSpecificInstruction(
            GlobalInstruction<TCoordinate> globalInstruction,
            IDrone<TCoordinate> drone,
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
                    return new Collect<TCoordinate>(drone, startedAt);
                case "MoveTo":
                    return new MoveTo<TCoordinate>(drone,startedAt,drone.CurrentPosition,globalInstruction.Destination);
                case "Unload":
                    return new Unload<TCoordinate>(drone,startedAt);
                default:
                    throw new ArgumentException("Unknown instruction type "+globalInstruction.TYPE);
            }
        }
    }
}