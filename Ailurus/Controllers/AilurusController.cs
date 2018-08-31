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
        public static IMapInfo<CoordinateInt2D> Map = new MapInfo<CoordinateInt2D>()
        {
            Name = "lvl1",
            Dimensions = new Tuple<CoordinateInt2D, CoordinateInt2D>(
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
        
        // GET map
        [HttpGet]
        [Route("map")]
        public IMapInfo<CoordinateInt2D> GetMap()
        {
            return Map;
        }

        // GET playerContext
        [HttpGet]
        [Route("playerContext")]
        public IPlayerContextDto<CoordinateInt2D> GetPlayerContext()
        {
            //@TODO get playerName from authentication/session
            var playerName = "RedPanda";
            var repo = new PlayerContextRepository<CoordinateInt2D>();
            var mapper = new PlayerContextMapper<CoordinateInt2D>();
            try
            {
                return mapper.Map(repo.GetPlayerContextByPlayerName(playerName));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                var playerCtx = CreateNew(playerName);
                repo.Save(playerCtx);
                return mapper.Map(playerCtx);
            }
        }
        
        // POST instructions
        [HttpPost]
        [Route("instructions")]
        public IEnumerable<string> SendInstructions(
            [FromBody]
            [Required]
            List<GlobalInstruction<CoordinateInt2D>> instructions)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Model not valid");
                }

                //@TODO get playerName from authentication/session
                var playerName = "RedPanda";

                var service = new DroneManagementService<CoordinateInt2D>(playerName);
                return service.ProcessInstructions(instructions);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<string>()
                {
                    e.Message
                };
            }
        }
        
        public static IPlayerContext<CoordinateInt2D> CreateNew(string playerName)
        {
            return new PlayerContext<CoordinateInt2D>() {
                PlayerName = playerName,
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
                        Speed = 1
                    },
                    new Drone<CoordinateInt2D>()
                    {
                        Name = "Drone_2",
                        CurrentPosition = new CoordinateInt2D()
                        {
                            X = 3,
                            Y = 6
                        },
                        Speed = 1
                    }
                },
                Resources = new List<ResourceQuantity>()
                {
                    new ResourceQuantity()
                    {
                        Resource = ResourceType.Gold,
                        Quantity = 0
                    }
                }
            };
        }
    }
}
