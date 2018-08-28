using System;
using System.Threading.Tasks;
using Ailurus.DTO.Interfaces;
using Newtonsoft.Json;

namespace Ailurus.Model.Instructions
{
    public abstract class AbstractInstruction<TCoordinate> : IInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        [JsonIgnore]
        public IDrone<TCoordinate> Drone { get; protected set; }
        public DateTime StartedAt { get; protected set; }
        public abstract DateTime EndAt { get; protected set; }
        public abstract double Duration { get; protected set; }

        public async void DoIt(IPlayerContext<TCoordinate> playerContext)
        {
            await Task.Run(async () => //Task.Run automatically unwraps nested Task types!
            {
                Console.WriteLine("Schedule "+GetType().Name);
                await Task.Delay((int) (Duration * 1000));
                JustDoIt(playerContext.PlayerName);
                Console.WriteLine("Done "+GetType().Name);
            });
            Console.WriteLine("All done"+GetType().Name);
        }

        protected abstract void JustDoIt(string playerName);
    }
}