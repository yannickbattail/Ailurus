using System;
using System.Threading.Tasks;
using Ailurus.DTO;
using Ailurus.DTO.Interfaces;
using Ailurus.Repository;
using Newtonsoft.Json;

namespace Ailurus.Model.Instructions
{
    public class MoveTo<TCoordinate> : AbstractInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        [JsonIgnore]
        public TCoordinate StartPosition { get; set; }
        public TCoordinate Destination { get; set; }
        
        public double Distance
        {
            get {
                return StartPosition.GetDistanceTo(Destination);
            }
        }
    
        public override double Duration
        {
            get {
                return Distance / Drone.Speed;
            }
            protected set{}
        }

        public override DateTime EndAt
        {
            get
            {
                return StartedAt.AddSeconds(Duration);
            }
            protected set{}
        }

        public MoveTo(IDrone<TCoordinate> drone, DateTime startedAt, TCoordinate startPosition, TCoordinate destination)
        {
            Drone = drone;
            StartedAt = startedAt;
            StartPosition = startPosition;
            Destination = destination;
        }

        protected override void JustDoIt(string playerName)
        {
            //var repo = new PlayerContextRepository<TCoordinate>();
            //var playerContext = repo.GetPlayerContextByPlayerName(playerName);
            //
            //repo.Save(playerContext);
        }
    }
}
