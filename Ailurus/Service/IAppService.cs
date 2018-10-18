using System.Collections.Generic;
using Ailurus.DTO.Requests.Implementations;
using Ailurus.DTO.Requests.Interfaces;
using Ailurus.DTO.Responses.Interfaces;

namespace Ailurus.Service
{
    public interface IAppService
    {
        IMapInfo GetMap();
        IPlayerContextDto GetPlayerContext(string playerName);
        IEnumerable<string> SendInstructions(IList<GlobalInstruction> instructions, string playerName);
        IPlayerContextDto CreateNew(UserLoginDto login);
    }
}