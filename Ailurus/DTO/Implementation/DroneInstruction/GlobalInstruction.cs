using System;
using Ailurus.Model.Instructions;

namespace Ailurus.DTO.Implementation.DroneInstruction
{
    public class GlobalInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        public string TYPE { get; set; }
        public string DroneName { get; set; }
        
        public TCoordinate Destination { get; set; }
        
        public IInstruction<TCoordinate> ToIInstruction(DateTime startedAt, IDrone<TCoordinate> drone)
        {
            return null;
        }

    }
}