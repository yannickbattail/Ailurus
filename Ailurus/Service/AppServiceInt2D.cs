using System;
using System.Collections.Generic;
using Ailurus.DTO.Requests.Implementations;
using Ailurus.DTO.Requests.Interfaces;
using Ailurus.DTO.Responses.Implementations;
using Ailurus.DTO.Responses.Interfaces;
using Ailurus.Mapper.Implementations;
using Ailurus.Model;
using Ailurus.Repository;

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
                Mines = new List<Mine>()
                {
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
                },
                Factories = new List<Factory>()
                {
                    new Factory()
                    {
                        Name = "Home",
                        Position = new CoordinateInt2D()
                        {
                            X = 2,
                            Y = 2
                        }
                    },
                },
                ResourceGoal = new List<ResourceQuantity>()
                {
                    new ResourceQuantity(){Resource = ResourceType.Gold, Quantity = 30}
                }
            };
        }
        
        public override IPlayerContextDto CreateNew(UserLoginDto login)
        {
            var repo = new PlayerContextRepository();
            var mapper = new PlayerContextMapper();
            var payerCtx = new PlayerContext()
            {
                PlayerName = login.PlayerName,
                Pass = login.Pass,
                Drones = new List<IDrone>()
                {
                    CreateNewDrone("Drone_1"),
                    CreateNewDrone("Drone_2")
                }
            };
            repo.Save(payerCtx);
            return mapper.Map(payerCtx);
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