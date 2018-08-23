using Ailurus.DTO;
using Ailurus.DTO.Interfaces;

namespace Ailurus.Repository
{
    public interface IPlayerContextRepository<TCoordinate> where TCoordinate : ICoordinate
    {
        IPlayerContext<TCoordinate> GetPlayerContextByPlayerName(string playerName);
        void Save(string playerName, IPlayerContext<TCoordinate> playerContext);
    }
}