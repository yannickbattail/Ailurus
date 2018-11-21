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
            
            var map = GetMap(1);
            var payerCtx = new PlayerContext()
            {
                PlayerName = login.PlayerName,
                Pass = login.Pass,
                Level = 1,
                Drones = map.InitialDrones
            };
            repo.Save(payerCtx);
            return mapper.Map(payerCtx);
        }

        public override IPlayerContextDto ChangeLevel(int level, string playerName)
        {
            var repo = GetPlayerContextRepository();
            var mapper = new PlayerContextMapper();
            try
            {
                var playerContext = repo.GetPlayerContextByPlayerName(playerName);
                // try load maps, throws exception if map does not exists
                var map = GetMap(level);
                playerContext.Level = level;
                playerContext.Drones = map.InitialDrones;
                repo.Save(playerContext);
                return mapper.Map(playerContext);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw ;
            }
        }
    }
}