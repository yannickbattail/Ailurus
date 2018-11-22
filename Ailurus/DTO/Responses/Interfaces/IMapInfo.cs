using Ailurus.DTO.Requests.Interfaces;
using Ailurus.DTO.Responses.Implementations;
using Ailurus.Model;
using System;
using System.Collections.Generic;

namespace Ailurus.DTO.Responses.Interfaces
{
    public interface IMapInfo
    {
        string Name { get; set; }
        string Description { get; set; }
        Tuple<ICoordinate, ICoordinate> Dimensions { get; set; }
        IEnumerable<Mine> Mines { get; set; }
        IEnumerable<Factory> Factories { get; set; }
        IEnumerable<ResourceQuantity> ResourceGoal { get; set; }
        TimeSpan TimeLimitGoal { get; set; }
        IEnumerable<Drone> InitialDrones { get; set; }

        bool IsInside(ICoordinate coordinate);
        ICoordinate ForceInside(ICoordinate coordinate);
    }
}