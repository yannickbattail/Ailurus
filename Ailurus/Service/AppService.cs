using System;
using System.Collections.Generic;
using Ailurus.DTO.Implementation;
using Ailurus.DTO.Interfaces;
using Ailurus.Mapper.Implementation;
using Ailurus.Repository;

namespace Ailurus.Service
{
    public abstract class AppService<TCoordinate> where TCoordinate : ICoordinate, new()
    {
        public IMapInfo<TCoordinate> Map;

        public abstract ICoordinateUtils<TCoordinate> GetCoordinateUtils();
        
        public IMapInfo<TCoordinate> GetMap()
        {
            return Map;
        }

        public IPlayerContextDto<TCoordinate> GetPlayerContext(string playerName)
        {
            var repo = new PlayerContextRepository<TCoordinate>();
            var mapper = new PlayerContextMapper<TCoordinate>();
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

        public IEnumerable<string> SendInstructions(List<GlobalInstruction<CoordinateInt2D>> instructions, string playerName)
        {
            try
            {
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

        public abstract IPlayerContext<TCoordinate> CreateNew(string playerName);
    }
}