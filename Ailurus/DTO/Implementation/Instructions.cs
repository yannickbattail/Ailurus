using System.Collections.Generic;

namespace Ailurus.DTO
{
    public class Instructions : IInstructions
    {
        public IEnumerable<IDroneInstruction> DroneInstruction { get; set; }
    }
}