using Ailurus.DTO;
using Ailurus.DTO.Implementation;
using Ailurus.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Ailurus.Controllers
{
    public class AilurusController : Controller
    {
        // GET api/map
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

        // GET api/playerContext
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
                var playerCtx = new PlayerContext<CoordinateInt2D>();
                repo.SavePlayerContextByPlayerName(playerName, playerCtx);
                return playerCtx;
            }
        }

        // POST api/instructions
        [HttpPost]
        public string SendInstructions(IInstructions instructions)
        {
            return "Oki doki";
        }
    }
}