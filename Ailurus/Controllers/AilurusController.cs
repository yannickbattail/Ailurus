using Ailurus.DTO;
using Ailurus.DTO.Implementation;
using Ailurus.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Ailurus.DTO.Interfaces;
using Ailurus.Mapper.Implementation;
using Ailurus.Model;
using Ailurus.Model.Instructions;
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
