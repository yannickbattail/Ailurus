using Ailurus.DTO.Interfaces;
using Ailurus.Model;

namespace Ailurus.Repository
{
    public interface IPlayerContextRepository
    {
        IPlayerContext GetPlayerContextByPlayerName(string playerName);
        bool PlayerExists(string playerName, string pass);
        void Save(IPlayerContext playerContext);
    }
}