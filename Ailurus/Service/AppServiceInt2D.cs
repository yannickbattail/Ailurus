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
using Microsoft.AspNetCore.Rewrite.Internal.PatternSegments;
using Newtonsoft.Json;

namespace Ailurus.Service
{
    public class AppServiceInt2D: AppService
    {
        public AppServiceInt2D()
        {

        }
        
        public override IMapInfo GetMap(int mapLevel)
        {
            try
            {
                var json = File.ReadAllText("Resources/maps/level_"+mapLevel+".json");
                var map = JsonConvert.DeserializeObject<MapInfo>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                });
                return map;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new NoMapException("There is no map for level: "+mapLevel, e);
            }
        }
        
        public override IPlayerContextDto CreateNew(UserLoginDto login)
        {
            var repo = GetPlayerContextRepository();
            var mapper = new PlayerContextMapper();
            var payerCtx = new PlayerContext()
            {
                PlayerName = login.PlayerName,
                Pass = login.Pass,
                Level = 1,
                Drones = new List<IDrone>()
                {
                    CreateNewDrone("Drone_1", 1),
                    CreateNewDrone("Drone_2", 1)
                }
            };
            repo.Save(payerCtx);
            return mapper.Map(payerCtx);
        }

        private static IDrone CreateNewDrone(string name, int mapLevel)
        {
            var newDrone = new Drone(GetAppService().GetMap(mapLevel).DroneSpawnPoint)
            {
                Name = name,
                Speed = 1,
                StorageSize = 10
            };
            return newDrone;
        }
    }
}