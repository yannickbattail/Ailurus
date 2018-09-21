using System;
using System.Collections.Generic;
using Ailurus.DTO.Implementation;
using Ailurus.DTO.Interfaces;
using Ailurus.Mapper.Implementation;
using Ailurus.Model;
using Ailurus.Repository;

namespace Ailurus.Service
{
    public abstract class AppService : IAppService
    {
        private static AppService App;
        
        public static AppService GetAppService()
        {
            if (App == null)
            {
                App = new AppServiceInt2D() as AppService;
            }

            return App;
        }

        protected IMapInfo Map;
        
        public IMapInfo GetMap()
        {
            return Map;
        }

        public IPlayerContextDto GetPlayerContext(string playerName)
        {
            var repo = new PlayerContextRepository();
            var mapper = new PlayerContextMapper();
            try
            {
                return mapper.Map(repo.GetPlayerContextByPlayerName(playerName));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                var playerCtx = CreateNew(playerName);
                repo.Save(playerCtx);
                return mapper.Map(playerCtx);
            }
        }

        public IEnumerable<string> SendInstructions(List<GlobalInstruction> instructions, string playerName)
        {
            try
            {
                var service = new DroneManagementService<CoordinateInt2D>(playerName);
                return service.ProcessInstructions(instructions);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<string>()
                {
                    e.Message
                };
            }
        }

        public abstract IPlayerContext CreateNew(string playerName);
    }
}