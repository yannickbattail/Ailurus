using System;
using System.Collections.Generic;
using Ailurus.DTO.Requests.Interfaces;
using Ailurus.Model;

namespace Ailurus.DTO.Responses.Interfaces
{
    public interface IMapInfo
    {
        string Name { get; set; }
        Tuple<ICoordinate, ICoordinate> Dimensions { get; set; }
        ICoordinate DroneSpawnPoint { get; set; }
        IEnumerable<IItem> Items { get; set; }
        IEnumerable<ResourceQuantity> ResourceGoal { get; set; }
        
        bool IsInside(ICoordinate coordinate);
        ICoordinate ForceInside(ICoordinate coordinate);
    }
}