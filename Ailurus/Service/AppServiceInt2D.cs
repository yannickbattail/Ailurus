using System;
using System.Collections.Generic;
using Ailurus.DTO.Implementation;
using Ailurus.DTO.Interfaces;
using Ailurus.Model;

namespace Ailurus.Service
{
    public class AppServiceInt2D: AppService<CoordinateInt2D>
    {
        public IMapInfo<CoordinateInt2D> Map = new MapInfo<CoordinateInt2D>()
        {
            Name = "lvl1",
            Dimensions = new Tuple<CoordinateInt2D, CoordinateInt2D>(
                new CoordinateInt2D()
                {
                    X = 0,
                    Y = 0
                },
                new CoordinateInt2D()
                {
                    X = 100,
                    Y = 100
                }
            ),
            Items = new List<IItem<CoordinateInt2D>>()
            {
                new MainBuilding<CoordinateInt2D>()
                {
                    Name = "Home",
                    Position = new CoordinateInt2D()
                    {
                        X = 2,
                        Y = 2
                    }
                },
                new Mine<CoordinateInt2D>()
                {
                    Name = "Gold Mine",/*
                    Position = new CoordinateInt2D()
                    {
                        X = 98,
                        Y = 98
                    }*/
                }
            }
        };

        public override ICoordinateUtils<CoordinateInt2D> GetCoordinateUtils()
        {
            return new CoordinateInt2DUtils();
        }
        
        public override IPlayerContext<CoordinateInt2D> CreateNew(string playerName)
        {
            return new PlayerContext<CoordinateInt2D>()
            {
                PlayerName = playerName,
                Drones = new List<IDrone<CoordinateInt2D>>()
                {
                    new Drone<CoordinateInt2D>()
                    {
                        Name = "Drone_1",
                        CurrentPosition = new CoordinateInt2D()
                        {
                            X = 1,
                            Y = 1
                        },
                        Speed = 1
                    },
                    new Drone<CoordinateInt2D>()
                    {
                        Name = "Drone_2",
                        CurrentPosition = new CoordinateInt2D()
                        {
                            X = 3,
                            Y = 6
                        },
                        Speed = 1
                    }
                },
                Resources = new List<ResourceQuantity>()
                {
                    new ResourceQuantity()
                    {
                        Resource = ResourceType.Gold,
                        Quantity = 0
                    }
                }
            };
        }
    }
}