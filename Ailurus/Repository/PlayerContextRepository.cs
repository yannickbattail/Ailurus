using Ailurus.DTO;
using System;
using System.Collections.Generic;
using Ailurus.DTO.Interfaces;

namespace Ailurus.Repository
{
    public class PlayerContextRepository<TCoordinate> : IPlayerContextRepository<TCoordinate> where TCoordinate : ICoordinate
    {
        private static IDictionary<string, IPlayerContext<TCoordinate>> PlayerContexts = new Dictionary<string, IPlayerContext<TCoordinate>>();


        public IPlayerContext<TCoordinate> GetPlayerContextByPlayerName(string playerName)
        {
            if (PlayerContexts.ContainsKey(playerName))
            {
                return PlayerContexts[playerName];
            }
            else
            {
                throw new Exception("Player not found");
            }
        }

        public void SavePlayerContextByPlayerName(string playerName, IPlayerContext<TCoordinate> playerContext)
        {
            PlayerContexts[playerName] = playerContext;
        }

    }
}
