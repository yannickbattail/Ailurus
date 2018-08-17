using System;
using Ailurus.Model.Instructions;

namespace Ailurus.DTO
{
    public interface IDrone<TCoordinate> where TCoordinate : ICoordinate
    {
        string Name { get; set; }
        IInstruction<TCoordinate> LastInstruction { get; set; }
        TCoordinate CurrentPosition { get; set; }
        DroneState State { get; }
        DroneState GetStateAt(DateTime Time);
        Double Speed { get; set; }
    }
}