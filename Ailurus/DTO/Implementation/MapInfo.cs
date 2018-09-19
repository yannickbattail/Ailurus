﻿using System;
using System.Collections.Generic;
using Ailurus.DTO.Interfaces;
using Ailurus.Service;

namespace Ailurus.DTO.Implementation
{
    public class MapInfo<TCoordinate> : IMapInfo<TCoordinate> where TCoordinate : ICoordinate
    {
        public string Name { get; set; }
        public Tuple<TCoordinate, TCoordinate> Dimensions { get; set; }
        public TCoordinate DroneSpawnPoint { get; set; }
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