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
        TCoordinate CurrentPosition { get; }
        DroneState State { get; }
        DroneState GetStateAt(DateTime time);
        Double Speed { get; set; }
        int StorageSize { get; set; }
        ResourceQuantity Storage { get; }
        
        void AddInstruction(IInstruction<TCoordinate> instruction);
        void AbortLastInstruction();
        IEnumerable<IInstruction<TCoordinate>> GetInstructions();
        IEnumerable<IInstruction<TCoordinate>> GetValidInstructions();
        IInstruction<TCoordinate> GetLastValidInstruction();
    }
}