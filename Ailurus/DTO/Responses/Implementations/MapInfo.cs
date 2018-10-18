using System;
using System.Collections.Generic;
using Ailurus.DTO.Requests.Interfaces;
using Ailurus.DTO.Responses.Interfaces;
using Ailurus.Model;

namespace Ailurus.DTO.Responses.Implementations
{
    public class MapInfo : IMapInfo
    {
        public string Name { get; set; }
        public Tuple<ICoordinate, ICoordinate> Dimensions { get; set; }
        public ICoordinate DroneSpawnPoint { get; set; }
        public IEnumerable<IItem> Items { get; set; }
        public IEnumerable<ResourceQuantity> ResourceGoal { get; set; }
        
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