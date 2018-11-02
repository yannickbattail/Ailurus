using System;
using System.Collections.Generic;
using Ailurus.DTO.Requests.Implementations;
using Ailurus.DTO.Responses.Interfaces;
using Ailurus.Mapper.Implementations;
using Ailurus.Repository;

namespace Ailurus.Service
{
    public abstract class AppService : IAppService
    {
        private static AppService App;

        public bool CheckLogin(UserLoginDto login)
        {
            var repo = GetPlayerContextRepository();
            return repo.PlayerExists(login.PlayerName, login.Pass);
        }
        
        public static AppService GetAppService()
        {
            if (App == null)
            {
                App = new AppServiceInt2D();
            }

            return App;
        }        
        
        public IPlayerContextRepository GetPlayerContextRepository()
        {
            return new PlayerContextRepository();
        }

        public abstract IMapInfo GetMap(int mapLevel);

        public IPlayerContextDto GetPlayerContext(string playerName)
        {
            var repo = GetPlayerContextRepository();
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

        public abstract IPlayerContextDto ChangeLevel(int level, string playerName);

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