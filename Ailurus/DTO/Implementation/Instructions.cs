using System.Collections.Generic;

namespace Ailurus.DTO
{
    public class Instructions<TCoordinate> : IInstructions<TCoordinate> where TCoordinate : ICoordinate
    {
        public IEnumerable<IDroneInstruction<TCoordinate>> DroneInstruction { get; set; }
    }
}