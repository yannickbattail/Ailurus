using System.Collections.Generic;
using Ailurus.DTO.Requests.Implementations;

namespace Ailurus.DTO.Requests.Interfaces
{
    public interface IInstructionSetDto
    {
        UserLoginDto Login { get; set; }
        IList<GlobalInstruction> Instructions { get; set; }
    }
}