using System;
using Ailurus.DTO.Implementation.DroneInstruction;
using Ailurus.Model.Instructions;

namespace Ailurus.DTO
{
    public interface IInstructionMapper<TCoordinate> where TCoordinate : ICoordinate
    {
        IInstruction<TCoordinate> ToSpecificInstruction(
            GlobalInstruction<TCoordinate> globalInstruction,
            IDrone<TCoordinate> drone,
            DateTime currentTime);
    }
}