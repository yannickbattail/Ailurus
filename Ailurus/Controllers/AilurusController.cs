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
        private AppService<CoordinateInt2D> App = AppService<CoordinateInt2D>.GetAppService();

        // GET map
        [HttpGet]
        [Route("map")]
        public IMapInfo<CoordinateInt2D> GetMap()
        {
            return App.GetMap();
        }

        // GET playerContext
        [HttpGet]
        [Route("playerContext")]
        public IPlayerContextDto<CoordinateInt2D> GetPlayerContext()
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
            List<GlobalInstruction<CoordinateInt2D>> instructions)
        {
            //@TODO get playerName from authentication/session
            var playerName = "RedPanda";
            return App.SendInstructions(instructions, playerName);
        }
    }
}
