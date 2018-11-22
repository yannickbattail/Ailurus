using Ailurus.DTO.Requests.Interfaces;
using Ailurus.DTO.Responses.Interfaces;
using Ailurus.Model;
using System;
using System.Collections.Generic;

namespace Ailurus.DTO.Responses.Implementations
{
    public class MapInfo : IMapInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Tuple<ICoordinate, ICoordinate> Dimensions { get; set; }
        public IEnumerable<Mine> Mines { get; set; }
        public IEnumerable<Factory> Factories { get; set; }
        public IEnumerable<ResourceQuantity> ResourceGoal { get; set; }
        public TimeSpan TimeLimitGoal { get; set; }
        public IEnumerable<Drone> InitialDrones { get; set; }

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