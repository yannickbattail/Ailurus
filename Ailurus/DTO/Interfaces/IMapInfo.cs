using System;
using System.Collections.Generic;

namespace Ailurus.DTO.Interfaces
{
    public interface IMapInfo
    {
        string Name { get; set; }
        Tuple<ICoordinate, ICoordinate> Dimensions { get; set; }
        ICoordinate DroneSpawnPoint { get; set; }
        IEnumerable<IItem> Items { get; set; }
        bool IsInside(ICoordinate coordinate);
        ICoordinate ForceInside(ICoordinate coordinate);
    }
}