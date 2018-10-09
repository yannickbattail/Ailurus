using System.Collections.Generic;
using Ailurus.DTO.Implementation;
using Ailurus.DTO.Interfaces;
using Ailurus.Model;

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