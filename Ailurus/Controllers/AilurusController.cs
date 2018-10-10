using Ailurus.DTO.Implementation;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ailurus.DTO.Interfaces;
using Ailurus.Service;
using Microsoft.AspNetCore.Authorization;

namespace Ailurus.Controllers
{
    public class AilurusController : Controller
    {
        private AppService App = AppService.GetAppService();

        // GET map
        [HttpGet]
        [Route("map")]
        public ActionResult<IMapInfo> GetMap()
        {
            return Ok(App.GetMap());
        }

        // POST createPlayer
        [HttpPost]
        [Route("createPlayer")]
        public ActionResult<IPlayerContextDto>  CreatePlayer(
            [FromBody]
            [Required]
            UserLoginDto login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            return Ok(App.CreateNew(login));
        }
        
        // POST playerContext
        [HttpPost]
        [Route("playerContext")]
        public ActionResult<IPlayerContextDto> GetPlayerContext(
            [FromBody]
            [Required]
            UserLoginDto login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            if (!App.CheckLogin(login))
            {
                return Forbid();
            }
            return Ok(App.GetPlayerContext(login.PlayerName));
        }
        
        // POST instructions
        [HttpPost]
        [Route("instructions")]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        [ProducesResponseType(typeof(void), 400)]
        public ActionResult<IEnumerable<string>> SendInstructions(
            [FromBody]
            [Required]
            InstructionSetDto instructionSet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            if (!App.CheckLogin(instructionSet.Login))
            {
                return Forbid();
            }
            return Ok(App.SendInstructions(instructionSet.Instructions, instructionSet.Login.PlayerName));
        }
    }
}
