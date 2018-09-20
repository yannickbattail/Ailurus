using System;
using Ailurus.DTO.Interfaces;
using Ailurus.Service;
using Ailurus.Util.Interfaces;
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

        public TCoordinate GetPositionAt(DateTime time)
        {
            if (time <= StartedAt)
            {
                return StartPosition;
            }
            if (time >= EndAt)
            {
                return Destination;
            }
            return utils.PathProgression(StartPosition, Destination, GetProgressionAt(time));
        }
        
        public MoveTo(IDrone<TCoordinate> drone, DateTime startedAt, TCoordinate source, TCoordinate destination)
        {
            if (destination == null)
            {
                throw new ArgumentException("missing destination for MoveTo instruction");
            }
            if (source == null)
            {
                throw new ArgumentException("missing destination for MoveTo instruction");
            }
            if (utils.IsNear(source, destination))
            {
                throw new InvalidInstructionException<TCoordinate>("The drone is already at destination");    
            }
            Drone = drone;
            StartedAt = startedAt;
            StartPosition = source;
            Destination = destination;
        }
    }
}
