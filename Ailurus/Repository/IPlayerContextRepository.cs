using Ailurus.DTO.Interfaces;
using Ailurus.Model;

namespace Ailurus.Repository
{
    public interface IPlayerContextRepository
    {
        IPlayerContext GetPlayerContextByPlayerName(string playerName);
        void Save(IPlayerContext playerContext);
    }
}