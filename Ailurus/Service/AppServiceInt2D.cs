using System;
using System.Collections.Generic;
using Ailurus.DTO.Implementation;
using Ailurus.DTO.Interfaces;
using Ailurus.Model;
using Ailurus.Model.Instructions;

namespace Ailurus.Service
{
    public class AppServiceInt2D: AppService<CoordinateInt2D>
    {
        public AppServiceInt2D()
        {
            Map = new MapInfo<CoordinateInt2D>()
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
                        Name = "Gold Mine",
                        ResourceType = ResourceType.Gold,
                        Position = new CoordinateInt2D()
                        {
                            X = 98,
                            Y = 98
                        }
                    }
                }
            };
        }
        
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
                    CreateNewDrone("Drone_1"),
                    CreateNewDrone("Drone_2")
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

        private static IDrone<CoordinateInt2D> CreateNewDrone(string name)
        {
            var newDrone = new Drone<CoordinateInt2D>(GetAppService().GetMap().DroneSpawnPoint)
            {
                Name = name,
                Speed = 1
            };
            return newDrone;
        }
    }
}