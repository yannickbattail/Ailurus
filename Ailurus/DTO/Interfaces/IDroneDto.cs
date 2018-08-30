using Ailurus.Model;
using Ailurus.Model.Instructions;

namespace Ailurus.DTO.Interfaces
{
    public interface IDroneDto<TCoordinate> where TCoordinate : ICoordinate
    {
        string Name { get; set; }
        IInstruction<TCoordinate> LastInstruction { get; set; }
        TCoordinate CurrentPosition { get; set; }
        DroneState State { get; set; }
        double Speed { get; set; }
        int StorageSize { get; set; }
        ResourceQuantity Storage { get; set; }
    }
}