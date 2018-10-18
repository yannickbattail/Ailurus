using System.Collections.Generic;
using Ailurus.DTO.Requests.Interfaces;

namespace Ailurus.DTO.Requests.Implementations
{
    public class InstructionSetDto : IInstructionSetDto
    {
        public UserLoginDto Login { get; set; }
        public IList<GlobalInstruction> Instructions { get; set; }
    }
}