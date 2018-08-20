using Ailurus.Model.Instructions;

namespace Ailurus.DTO.Interfaces
{
    public interface IDroneDto<TCoordinate> where TCoordinate : ICoordinate
    {
        string Name { get; set; }
        IInstruction<TCoordinate> LastInstruction { get; set; }
        TCoordinate CurrentPosition { get; set; }
        double Speed { get; set; }
        DroneState State { get; set; }

    }
}