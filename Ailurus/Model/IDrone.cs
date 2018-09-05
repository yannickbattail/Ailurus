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
        IList<IInstruction<TCoordinate>> Instructions { get; set; }
        TCoordinate CurrentPosition { get; }
        DroneState State { get; }
        DroneState GetStateAt(DateTime time);
        Double Speed { get; set; }
        int StorageSize { get; set; }
        ResourceQuantity Storage { get; }

        IInstruction<TCoordinate> GetLastValidInstruction();
        
    }
}