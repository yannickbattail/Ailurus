using System;
using System.Threading.Tasks;
using Ailurus.DTO;
using Ailurus.DTO.Interfaces;
using Ailurus.Repository;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

namespace Ailurus.Model.Instructions
{
    public class Unload<TCoordinate> : IInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        public static readonly int Duration = 2;
        
        [JsonIgnore]
        public IDrone<TCoordinate> Drone { get; set; }
        public DateTime StartedAt { get; set; }

        public DateTime EndAt
        {
            get
            {
                return StartedAt.AddSeconds(Duration);
            }
        }

        public Unload(IDrone<TCoordinate> drone, DateTime startedAt)
        {
            Drone = drone;
            StartedAt = startedAt;
        }
        
        public async void DoIt(IPlayerContext<TCoordinate> playerContext)
        {
            await Task.Run(async () =>
            {
                Console.WriteLine("Schedule "+GetType().Name);
                await Task.Delay(Duration * 1000);
                JustDoIt(playerContext);
                Console.WriteLine("Done "+GetType().Name);
            });
            Console.WriteLine("All done "+GetType().Name);
        }

        private void JustDoIt(IPlayerContext<TCoordinate> playerContext)
        {
            if (Drone.Storage == null)
            {
                Console.WriteLine("Drone.Storage is null");
                return;
            }
            playerContext.AddResource(Drone.Storage);
            Drone.Storage = null;
            var repo = new PlayerContextRepository<TCoordinate>();
            repo.Save(playerContext);
        }
    }
}
