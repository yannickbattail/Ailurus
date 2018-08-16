using System;
using Ailurus.Model.Instructions;

namespace Ailurus.DTO
{
    public interface IDrone<TCoordinate> where TCoordinate : ICoordinate
    {
        string Name { get; set; }
        IInstruction<TCoordinate> LastInstruction { get; set; }
        TCoordinate CurrentPosition { get; set; }
        DroneState DroneState { get; }
        Double Speed { get; set; }
    }
}