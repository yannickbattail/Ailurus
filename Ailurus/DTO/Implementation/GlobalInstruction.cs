using System;
using Ailurus.DTO.Interfaces;
using Ailurus.Model;
using Ailurus.Model.Instructions;

namespace Ailurus.DTO.Implementation
{
    public class GlobalInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        public string TYPE { get; set; }
        public string DroneName { get; set; }
        
        public TCoordinate Destination { get; set; }
        
    }
}