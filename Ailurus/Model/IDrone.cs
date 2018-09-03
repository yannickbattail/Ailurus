using System;
using System.Collections.Generic;
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
        DroneState GetStateAt(DateTime time);
        Double Speed { get; set; }
        int StorageSize { get; set; }
        ResourceQuantity Storage { get; set; }
    }
}