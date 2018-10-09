using System;
using System.Collections.Generic;
using Ailurus.DTO.Interfaces;
using Ailurus.Model;

namespace Ailurus.Repository
{
    public class PlayerContextRepository : IPlayerContextRepository
    {
        private static IDictionary<string, IPlayerContext> PlayerContexts = new Dictionary<string, IPlayerContext>();

        public IPlayerContext GetPlayerContextByPlayerName(string playerName)
        {
            if (!PlayerContexts.ContainsKey(playerName))
            {
                throw new Exception("Player not found");
            }

            return PlayerContexts[playerName];
        }

        public bool PlayerExists(string playerName, string pass)
        {
            if (!PlayerContexts.ContainsKey(playerName))
            {
                return false;
            }

            return PlayerContexts[playerName].Pass == pass;
        }

        public void Save(IPlayerContext playerContext)
        {
            PlayerContexts[playerContext.PlayerName] = playerContext;
        }
    }
}
