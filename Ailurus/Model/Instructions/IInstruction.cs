using System;
using Ailurus.DTO;
using Ailurus.DTO.Interfaces;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;

namespace Ailurus.Model.Instructions
{
    public interface IInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        [JsonIgnore]
        IDrone<TCoordinate> Drone { get; }
        DateTime StartedAt { get; }
        DateTime EndAt { get; }
        double Duration { get; }
        double Progression { get; }
        double GetProgressionAt(DateTime time);
        void ScheduleEndInstructionAction(IPlayerContext<TCoordinate> PlayerContext);
    }
}