using Ailurus.DTO;
using System;
using System.Collections.Generic;
using Ailurus.DTO.Interfaces;
using Ailurus.Model;

namespace Ailurus.Repository
{
    public class PlayerContextRepository<TCoordinate> : IPlayerContextRepository<TCoordinate> where TCoordinate : ICoordinate
    {
        private static IDictionary<string, IPlayerContext<TCoordinate>> PlayerContexts = new Dictionary<string, IPlayerContext<TCoordinate>>();

        public IPlayerContext<TCoordinate> GetPlayerContextByPlayerName(string playerName)
        {
            if (!PlayerContexts.ContainsKey(playerName))
            {
                throw new Exception("Player not found");
            }
            return PlayerContexts[playerName];
        }

        public void Save(IPlayerContext<TCoordinate> playerContext)
        {
            PlayerContexts[playerContext.PlayerName] = playerContext;
        }
    }
}
