using Ailurus.DTO.Interfaces;
using Ailurus.Model.Instructions;

namespace Ailurus.DTO.Implementation
{
    public class DroneDto<TCoordinate> : IDroneDto<TCoordinate> where TCoordinate : ICoordinate
    {
        public string Name { get; set; }
        public IInstruction<TCoordinate> LastInstruction { get; set; }
        public TCoordinate CurrentPosition { get; set; }
        public double Speed { get; set; }
        public DroneState State { get; set; }
    }
}