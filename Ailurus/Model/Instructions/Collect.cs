using System;
using System.Threading.Tasks;
using Ailurus.DTO;
using Ailurus.DTO.Implementation;
using Ailurus.DTO.Interfaces;
using Ailurus.Repository;
using Newtonsoft.Json;

namespace Ailurus.Model.Instructions
{
    public class Collect<TCoordinate> : IInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        public static readonly int Duration = 5;
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

        public Collect(IDrone<TCoordinate> drone, DateTime startedAt)
        {
            Drone = drone;
            StartedAt = startedAt;
        }

        public async void DoIt(IPlayerContext<TCoordinate> playerContext)
        {
            await Task.Run(async () => //Task.Run automatically unwraps nested Task types!
            {
                Console.WriteLine("Schedule "+GetType().Name);
                await Task.Delay(Duration * 1000);
                JustDoIt(playerContext);
                Console.WriteLine("Done "+GetType().Name);
            });
            Console.WriteLine("All done"+GetType().Name);
        }

        private void JustDoIt(IPlayerContext<TCoordinate> playerContext)
        {
            Drone.Storage = new ResourceQuantity()
            {
                Resource = ResourceType.Gold,
                Quantity = Drone.StorageSize
            };
            var repo = new PlayerContextRepository<TCoordinate>();
            repo.Save(playerContext.PlayerName, playerContext);
        }
    }
}
