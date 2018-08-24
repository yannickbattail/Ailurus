using System;
using System.Threading.Tasks;
using Ailurus.DTO;
using Ailurus.DTO.Interfaces;
using Newtonsoft.Json;

namespace Ailurus.Model.Instructions
{
    public class MoveTo<TCoordinate> : IInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        [JsonIgnore]
        public IDrone<TCoordinate> Drone { get; set; }
        public DateTime StartedAt { get; set; }
        public TCoordinate StartPosition { get; set; }
        public TCoordinate Destination { get; set; }
        
        public double Distance
        {
            get {
                return StartPosition.GetDistanceTo(Destination);
            }
        }
    
        public double Duration
        {
            get {
                return Distance / Drone.Speed;
            }
        }

        public DateTime EndAt
        {
            get
            {
                return StartedAt.AddSeconds(Duration);
            }
        }

        public MoveTo(IDrone<TCoordinate> drone, DateTime startedAt, TCoordinate startPosition, TCoordinate destination)
        {
            Drone = drone;
            StartedAt = startedAt;
            StartPosition = startPosition;
            Destination = destination;
        }
        
        public async void DoIt(IPlayerContext<TCoordinate> playerContext)
        {
            await Task.Run(async () => //Task.Run automatically unwraps nested Task types!
            {
                Console.WriteLine("Schedule "+GetType().Name);
                await Task.Delay((int)Duration * 1000);
                JustDoIt(playerContext);
                Console.WriteLine("Done "+GetType().Name);
            });
            Console.WriteLine("All done "+GetType().Name);
        }

        private void JustDoIt(IPlayerContext<TCoordinate> playerContext)
        {
            
        }
    }
}
