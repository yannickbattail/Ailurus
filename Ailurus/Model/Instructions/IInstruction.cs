using System;
using Ailurus.DTO;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;

namespace Ailurus.Model.Instructions
{
    public interface IInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        string TYPE { get; }
        string DroneName { get; }
        [JsonIgnore]
        IDrone<TCoordinate> Drone { get; set; }
        DateTime StartedAt { get; set; }
        DateTime EndAt { get; }
    }
}