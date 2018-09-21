using Ailurus.DTO.Implementation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ailurus.DTO.Interfaces;
using Ailurus.Service;

namespace Ailurus.Controllers
{
    public class AilurusController : Controller
    {
        private AppService App = AppService.GetAppService();

        // GET map
        [HttpGet]
        [Route("map")]
        public IMapInfo GetMap()
        {
            return App.GetMap();
        }

        // GET playerContext
        [HttpGet]
        [Route("playerContext")]
        public IPlayerContextDto GetPlayerContext()
        {
            //@TODO get playerName from authentication/session
            var playerName = "RedPanda";
            return App.GetPlayerContext(playerName);;
        }
        
        // POST instructions
        [HttpPost]
        [Route("instructions")]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public IEnumerable<string> SendInstructions(
            [FromBody]
            [Required]
            List<GlobalInstruction> instructions)
        {
            //@TODO get playerName from authentication/session
            var playerName = "RedPanda";
            return App.SendInstructions(instructions, playerName);
        }
    }
}
