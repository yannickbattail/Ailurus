using Ailurus.DTO;
using Ailurus.DTO.Implementation;
using Ailurus.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Ailurus.DTO.Implementation.DroneInstruction;
using Ailurus.Model.Instructions;
using Ailurus.Service;

namespace Ailurus.Controllers
{
    public class AilurusController : Controller
    {
        // GET map
        [Route("map")]
        [HttpGet]
        public IMapInfo<CoordinateInt2D> GetMap()
        {
            return new MapInfo<CoordinateInt2D>()
            {
                Name = "lvl1",
                Dimentions = new Tuple<CoordinateInt2D, CoordinateInt2D>(
                    new CoordinateInt2D()
                    {
                        X = 0,
                        Y = 0
                    },
                    new CoordinateInt2D()
                    {
                        X = 100,
                        Y = 100
                    }
                ),
                Items = new List<IItem<CoordinateInt2D>>()
                {
                    new MainBuilding<CoordinateInt2D>()
                    {
                        Name = "Home",
                        Position = new CoordinateInt2D()
                        {
                            X = 2,
                            Y = 2
                        }
                    },
                    new Mine<CoordinateInt2D>()
                    {
                        Name = "Gold Mine",
                        Position = new CoordinateInt2D()
                        {
                            X = 98,
                            Y = 98
                        }
                    }
                }
            };
        }

        // GET playerContext
        [Route("playerContext")]
        [HttpGet]
        public IPlayerContext<CoordinateInt2D> GetPlayerContext()
        {
            //@TODO get playerName from authentication
            var playerName = "RedPanda";
            var repo = new PlayerContextRepository<CoordinateInt2D>();
            try
            {
                return repo.GetPlayerContextByPlayerName(playerName);
            }
            catch (Exception e)
            {
                var playerCtx = new PlayerContext<CoordinateInt2D>()
                    {
                        Drones = new List<IDrone<CoordinateInt2D>>()
                        {
                            new Drone<CoordinateInt2D>()
                            {
                                Name = "Drone_1",
                                CurrentPosition = new CoordinateInt2D()
                                {
                                    X = 1,
                                    Y = 1
                                },
                                Speed = 10
                            },
                            new Drone<CoordinateInt2D>()
                            {
                                Name = "Drone_2",
                                CurrentPosition = new CoordinateInt2D()
                                {
                                    X = 3,
                                    Y = 6
                                },
                                Speed = 10
                            }
                        }
                    };
                repo.SavePlayerContextByPlayerName(playerName, playerCtx);
                return playerCtx;
            }
        }

        // POST instructions
        [Route("instructions")]
        [HttpPost]
        public IEnumerable<string> SendInstructions(
        [Required] List<GlobalInstruction<CoordinateInt2D>> instructions)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Model not valid");
            }
            //@TODO get playerName from authentication
            var mapper = new InstructionMapper<CoordinateInt2D>();
            var context = GetPlayerContext();
            var service = new DroneManagmentService<CoordinateInt2D>(context);
            return service.ProcessInstructions(instructions.Select(
                    globInstr => mapper.ToSpecificInstruction(globInstr)
                ));
        }
    }
}
