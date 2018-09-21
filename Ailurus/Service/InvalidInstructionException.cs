using System;
using Ailurus.DTO.Interfaces;
using Ailurus.Model.Instructions;

namespace Ailurus.Service
{
    public class InvalidInstructionException : Exception
    {
        public IInstruction Instruction { get; set; }

        public InvalidInstructionException(string message) : base(message)
        {
            
        }
    }
}