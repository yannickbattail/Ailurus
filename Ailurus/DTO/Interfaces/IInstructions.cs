using System.Collections.Generic;

namespace Ailurus.DTO
{
    public interface IInstructions<TCoordinate> where TCoordinate : ICoordinate
    {
        IEnumerable<IDroneInstruction<TCoordinate>> DroneInstruction { get; set; }
    }
}