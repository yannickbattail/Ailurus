using System;
using Ailurus.DTO.Interfaces;
using Ailurus.Model.Instructions;

namespace Ailurus.Service
{
    public class InvalidInstructionException<TCoordinate> : Exception where TCoordinate : ICoordinate
    {
        public IInstruction<TCoordinate> Instruction { get; set; }

        public InvalidInstructionException(string message) : base(message)
        {
            
        }
    }
}