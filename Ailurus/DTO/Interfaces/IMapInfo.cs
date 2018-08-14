using System;
using System.Collections.Generic;

namespace Ailurus.DTO
{
    public interface IMapInfo<TCoordinate> where TCoordinate : ICoordinate
    {
        string Name { get; set; }
        Tuple<TCoordinate, TCoordinate> Dimentions { get; set; }
        IEnumerable<IItem<TCoordinate>> Items { get; set; }
    }
}