using System;
using System.Collections.Generic;

namespace Ailurus.DTO.Interfaces
{
    public interface IMapInfo<TCoordinate> where TCoordinate : ICoordinate
    {
        string Name { get; set; }
        Tuple<TCoordinate, TCoordinate> Dimensions { get; set; }
        IEnumerable<IItem<TCoordinate>> Items { get; set; }
        bool IsInside(TCoordinate coordinate);
        TCoordinate ForceInside(TCoordinate coordinate);
    }
}