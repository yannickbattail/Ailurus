using System;
using Ailurus.Model.Instructions;

namespace Ailurus.DTO
{
    public interface IDroneInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        string TYPE { get; }
        string DroneName { get; set; }

        IInstruction<TCoordinate> ToIInstruction(DateTime startedAt, IDrone<TCoordinate> drone);
    }
}