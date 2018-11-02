using System.Collections.Generic;
using Ailurus.DTO.Requests.Implementations;
using Ailurus.DTO.Responses.Interfaces;

namespace Ailurus.Service
{
    public interface IAppService
    {
        IMapInfo GetMap(int mapLevel);
        IPlayerContextDto GetPlayerContext(string playerName);
        IEnumerable<string> SendInstructions(IList<GlobalInstruction> instructions, string playerName);
        IPlayerContextDto CreateNew(UserLoginDto login);
    }
}