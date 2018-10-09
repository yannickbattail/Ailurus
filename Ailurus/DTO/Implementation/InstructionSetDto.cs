using System.Collections.Generic;
using Ailurus.DTO.Interfaces;

namespace Ailurus.DTO.Implementation
{
    public class InstructionSetDto : IInstructionSetDto
    {
        public UserLoginDto Login { get; set; }
        public IList<GlobalInstruction> Instructions { get; set; }
    }
}