using Ailurus.Model;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Ailurus.Repository
{
    public class PlayerContextFileRepository : IPlayerContextRepository
    {
        const string RootData = "data/v1/";

        public IPlayerContext GetPlayerContextByPlayerName(string playerName)
        {
            try
            {
                var json = File.ReadAllText(GetFileName(playerName));
                return JsonConvert.DeserializeObject<IPlayerContext>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("player not found", e);
            }

        }

        public bool PlayerExists(string playerName, string pass)
        {
            try
            {
                var playerContext = GetPlayerContextByPlayerName(playerName);
                return playerContext.Pass == pass;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public void Save(IPlayerContext playerContext)
        {
            var json = JsonConvert.SerializeObject(playerContext);
            File.WriteAllText(GetFileName(playerContext.PlayerName), json);
        }

        protected string GetFileName(string playerName)
        {
            return RootData + playerName + ".json";
        }
    }
}
