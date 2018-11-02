using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ailurus.DTO.Requests.Implementations;
using Ailurus.DTO.Responses.Interfaces;
using Ailurus.Service;

namespace Ailurus.Controllers
{
    public class AilurusController : Controller
    {
        private AppService App = AppService.GetAppService();

        // POST map
        [HttpPost]
        [Route("map")]
        public ActionResult<IMapInfo> GetMap(
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

            var playerContext = App.GetPlayerContext(login.PlayerName);
            return Ok(App.GetMap(playerContext.Level));
        }
        
        // POST map
        [HttpPost]
        [Route("changeLevel")]
        public ActionResult<IPlayerContextDto> ChangeLevel(
            [FromBody]
            [Required]
            ChangeLevelDto changeLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            if (!App.CheckLogin(changeLevel.Login))
            {
                return Forbid();
            }

            var playerContext = App.ChangeLevel(changeLevel.Level, changeLevel.Login.PlayerName);
            return Ok(playerContext);
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
