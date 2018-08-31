using System.Collections.Generic;
using Ailurus.DTO.Implementation;
using Ailurus.DTO.Interfaces;

namespace Ailurus.Service
{
    public interface IAppService<TCoordinate> where TCoordinate : ICoordinate
    {
        ICoordinateUtils<TCoordinate> GetCoordinateUtils();
        IMapInfo<TCoordinate> GetMap();
        IPlayerContextDto<TCoordinate> GetPlayerContext(string playerName);
        IEnumerable<string> SendInstructions(List<GlobalInstruction<CoordinateInt2D>> instructions, string playerName);
        IPlayerContext<TCoordinate> CreateNew(string playerName);
    }
}