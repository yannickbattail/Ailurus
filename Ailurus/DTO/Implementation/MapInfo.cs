using System;
using System.Collections.Generic;

namespace Ailurus.DTO
{
    public class MapInfo<TCoordinate> : IMapInfo<TCoordinate> where TCoordinate : ICoordinate
    {
        public string Name { get; set; }
        public Tuple<TCoordinate, TCoordinate> Dimentions { get; set; }
        public IEnumerable<IItem<TCoordinate>> Items { get; set; }
    }
}