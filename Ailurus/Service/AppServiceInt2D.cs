using System;
using System.Collections.Generic;
using System.IO;
using Ailurus.DTO.Requests.Implementations;
using Ailurus.DTO.Requests.Interfaces;
using Ailurus.DTO.Responses.Implementations;
using Ailurus.DTO.Responses.Interfaces;
using Ailurus.Mapper.Implementations;
using Ailurus.Model;
using Ailurus.Repository;
using Newtonsoft.Json;

namespace Ailurus.Service
{
    public class AppServiceInt2D: AppService
    {
        public AppServiceInt2D()
        {
            try
            {
                var json = File.ReadAllText("Resources/maps/level_1.json");
                Map = JsonConvert.DeserializeObject<MapInfo>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                });
                Console.WriteLine("Map loaded from file: Resources/maps/level_1.json");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Will use default map.");
                
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
                        new ResourceQuantity() {Resource = ResourceType.Gold, Quantity = 30}
                    }
                };
            }
            /*
            var jsonO = JsonConvert.SerializeObject(Map, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            });
            File.WriteAllText("Resources/maps/level_0.json", jsonO);
            */
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