using System;
using System.Collections.Generic;
using Ailurus.DTO.Interfaces;

namespace Ailurus.DTO.Implementation
{
    public class MapInfo<TCoordinate> : IMapInfo<TCoordinate> where TCoordinate : ICoordinate
    {
        public string Name { get; set; }
        public Tuple<TCoordinate, TCoordinate> Dimentions { get; set; }
        public IEnumerable<IItem<TCoordinate>> Items { get; set; }
    }
}