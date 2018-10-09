using System.Collections.Generic;
using Ailurus.DTO.Implementation;

namespace Ailurus.DTO.Interfaces
{
    public interface IInstructionSetDto
    {
        UserLoginDto Login { get; set; }
        IList<GlobalInstruction> Instructions { get; set; }
    }
}