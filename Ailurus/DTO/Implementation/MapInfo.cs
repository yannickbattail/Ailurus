using System;
using System.Collections.Generic;
using Ailurus.DTO.Interfaces;
using Ailurus.Service;
using Microsoft.VisualBasic.CompilerServices;

namespace Ailurus.DTO.Implementation
{
    public class MapInfo<TCoordinate> : IMapInfo<TCoordinate> where TCoordinate : ICoordinate, new()
    {
        public string Name { get; set; }
        public Tuple<TCoordinate, TCoordinate> Dimensions { get; set; }
        public IEnumerable<IItem<TCoordinate>> Items { get; set; }
        
        public bool IsInside(TCoordinate coordinate)
        {
            return DroneManagementService<TCoordinate>.GetCoordinateUtils<TCoordinate>().IsInside<TCoordinate>(coordinate, Dimensions);
        }

        public TCoordinate ForceInside(TCoordinate coordinate)
        {
            return DroneManagementService<TCoordinate>.GetCoordinateUtils<TCoordinate>().ForceInside<TCoordinate>(coordinate, Dimensions);
        }
    }
}