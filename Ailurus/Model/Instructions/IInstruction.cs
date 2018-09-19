using System;
using Ailurus.DTO.Interfaces;
using Newtonsoft.Json;

namespace Ailurus.Model.Instructions
{
    public interface IInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        [JsonIgnore]
        IDrone<TCoordinate> Drone { get; }
        string Type { get; }
        DateTime StartedAt { get; }
        DateTime EndAt { get; }
        double Duration { get; }
        double Progression { get; }
        DateTime? AbortedAt { get; }
        bool IsAborted { get; }
        bool IsFinishedAt(DateTime time);
        double GetProgressionAt(DateTime time);
        void Abort();
    }
}