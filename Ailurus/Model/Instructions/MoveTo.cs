using System;
using System.Threading.Tasks;
using Ailurus.DTO;
using Ailurus.DTO.Interfaces;
using Ailurus.Repository;
using Ailurus.Service;
using Newtonsoft.Json;

namespace Ailurus.Model.Instructions
{
    public class MoveTo<TCoordinate> : AbstractInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        [JsonIgnore]
        public TCoordinate StartPosition { get; set; }
        public TCoordinate Destination { get; set; }
        private static ICoordinateUtils<TCoordinate> utils = AppService<TCoordinate>.GetAppService().GetCoordinateUtils();
        
        public double Distance
        {
            get {
                return utils.GetDistanceTo(StartPosition, Destination);
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
            if (destination == null)
            {
                throw new ArgumentException("missing destination for MoveTo instruction");
            }
            if (startPosition == null)
            {
                throw new ArgumentException("missing startPosition for MoveTo instruction");
            }
            Drone = drone;
            StartedAt = startedAt;
            StartPosition = startPosition;
            Destination = destination;
        }

        protected override void JustDoIt(string playerName)
        {
            var repo = new PlayerContextRepository<TCoordinate>();
            var playerContext = repo.GetPlayerContextByPlayerName(playerName);
            Drone.CurrentPosition = Destination;
            repo.Save(playerContext);
        }
    }
}
