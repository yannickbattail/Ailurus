using System;
using System.Collections.Generic;
using Ailurus.DTO.Implementation;
using Ailurus.DTO.Interfaces;
using Ailurus.Model;

namespace Ailurus.Service
{
    public class AppServiceInt2D: AppService
    {
        public AppServiceInt2D()
        {
            Map = new MapInfo()
            {
                Name = "lvl1",
                Dimensions = new Tuple<ICoordinate, ICoordinate>(
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
                DroneSpawnPoint = new CoordinateInt2D()
                {
                    X = 1,
                    Y = 1
                },
                Items = new List<IItem>()
                {
                    new MainBuilding()
                    {
                        Name = "Home",
                        Position = new CoordinateInt2D()
                        {
                            X = 2,
                            Y = 2
                        }
                    },
                    new Mine()
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
        
        public override IPlayerContext CreateNew(string playerName)
        {
            return new PlayerContext()
            {
                PlayerName = playerName,
                Drones = new List<IDrone>()
                {
                    CreateNewDrone("Drone_1"),
                    CreateNewDrone("Drone_2")
                }
            };
        }

        private static IDrone CreateNewDrone(string name)
        {
            var newDrone = new Drone(GetAppService().GetMap().DroneSpawnPoint)
            {
                Name = name,
                Speed = 1,
                StorageSize = 10
            };
            return newDrone;
        }
    }
}