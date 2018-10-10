using System;
using System.Collections.Generic;
using Ailurus.DTO.Implementation;
using Ailurus.DTO.Interfaces;
using Ailurus.Mapper.Implementation;
using Ailurus.Repository;

namespace Ailurus.Service
{
    public abstract class AppService : IAppService
    {
        private static AppService App;

        public bool CheckLogin(UserLoginDto login)
        {
            var repo = new PlayerContextRepository();
            return repo.PlayerExists(login.PlayerName, login.Pass);
        }
        
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
                throw e;
            }
        }

        public IEnumerable<string> SendInstructions(IList<GlobalInstruction> instructions, string playerName)
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

        public abstract IPlayerContextDto CreateNew(UserLoginDto login);
    }
}