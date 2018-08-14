using System.Collections.Generic;

namespace Ailurus.DTO
{
    public interface IInstructions
    {
        IEnumerable<IDroneInstruction> DroneInstruction { get; set; }
    }
}