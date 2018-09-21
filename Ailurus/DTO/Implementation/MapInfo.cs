using System;
using System.Collections.Generic;
using Ailurus.DTO.Interfaces;

namespace Ailurus.DTO.Implementation
{
    public class MapInfo : IMapInfo
    {
        public string Name { get; set; }
        public Tuple<ICoordinate, ICoordinate> Dimensions { get; set; }
        public ICoordinate DroneSpawnPoint { get; set; }
        public IEnumerable<IItem> Items { get; set; }
        
        public bool IsInside(ICoordinate coordinate)
        {
            return coordinate.IsInside(Dimensions);
        }

        public ICoordinate ForceInside(ICoordinate coordinate)
        {
            return coordinate.ForceInside(Dimensions);
        }
    }
}