using Ailurus.DTO;

namespace Ailurus.Repository
{
    public interface IPlayerContextRepository<TCoordinate> where TCoordinate : ICoordinate
    {
        IPlayerContext<TCoordinate> GetPlayerContextByPlayerName(string playerName);
        void SavePlayerContextByPlayerName(string playerName, IPlayerContext<TCoordinate> playerContext);
    }
}