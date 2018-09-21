using Ailurus.Model;
using Ailurus.Model.Instructions;

namespace Ailurus.DTO.Interfaces
{
    public interface IDroneDto
    {
        string Name { get; set; }
        IInstruction LastInstruction { get; set; }
        ICoordinate CurrentPosition { get; set; }
        DroneState State { get; set; }
        double Speed { get; set; }
        int StorageSize { get; set; }
        ResourceQuantity Storage { get; set; }
    }
}