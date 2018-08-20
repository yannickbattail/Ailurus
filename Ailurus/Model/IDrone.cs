using System;
using Ailurus.DTO;
using Ailurus.DTO.Interfaces;
using Ailurus.Model.Instructions;

namespace Ailurus.Model
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