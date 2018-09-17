using Ailurus.DTO;
using Ailurus.DTO.Interfaces;
using Ailurus.Model;

namespace Ailurus.Repository
{
    public interface IPlayerContextRepository<TCoordinate> where TCoordinate : ICoordinate
    {
        IPlayerContext<TCoordinate> GetPlayerContextByPlayerName(string playerName);
        void Save(IPlayerContext<TCoordinate> playerContext);
    }
}