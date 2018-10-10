using System;
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