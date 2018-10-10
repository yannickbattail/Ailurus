using System;
using Ailurus.DTO.Implementation;
using Ailurus.Model;
using Ailurus.Model.Instructions;

namespace Ailurus.Mapper.Interfaces
{
    public interface IInstructionMapper
    {
        IInstruction ToSpecificInstruction(
            GlobalInstruction globalInstruction,
            IDrone drone,
            DateTime currentTime);
    }
}