using System;
using System.Collections.Generic;
using Ailurus.DTO.Interfaces;
using Ailurus.Service;
using Microsoft.VisualBasic.CompilerServices;

namespace Ailurus.DTO.Implementation
{
    public class MapInfo<TCoordinate> : IMapInfo<TCoordinate> where TCoordinate : ICoordinate
    {
        public string Name { get; set; }
        public Tuple<TCoordinate, TCoordinate> Dimensions { get; set; }
        public IEnumerable<IItem<TCoordinate>> Items { get; set; }
        private static readonly ICoordinateUtils<TCoordinate> utils = AppService<TCoordinate>.GetAppService().GetCoordinateUtils();
        
        public bool IsInside(TCoordinate coordinate)
        {
            return utils.IsInside(coordinate, Dimensions);
        }

        public TCoordinate ForceInside(TCoordinate coordinate)
        {
            return utils.ForceInside(coordinate, Dimensions);
        }
    }
}