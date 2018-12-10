using System;
using Ailurus.DTO.Requests.Interfaces;
using Ailurus.Service;
using Newtonsoft.Json;

namespace Ailurus.Model.Instructions
{
    public class MoveTo : AbstractInstruction
    {
        public ICoordinate StartPosition { get; set; }
        public ICoordinate Destination { get; set; }
        
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

        public ICoordinate GetPositionAt(DateTime time)
        {
            if (time <= StartedAt)
            {
                return StartPosition;
            }
            if (time >= EndAt)
            {
                return Destination;
            }
            return StartPosition.PathProgression(Destination, GetProgressionAt(time));
        }

        public MoveTo() {}
        
        public MoveTo(IPlayerContext playerContext, IDrone drone, DateTime startedAt, ICoordinate source, ICoordinate destination)
        {
            if (destination == null)
            {
                throw new ArgumentException("missing destination for MoveTo instruction");
            }
            if (source == null)
            {
                throw new ArgumentException("missing destination for MoveTo instruction");
            }
            if (source.IsNear(destination))
            {
                throw new InvalidInstructionException("The drone is already at destination");    
            }
            if (!playerContext.GetMap().IsInside(destination))
            {
                throw new InvalidInstructionException("Destination is outside of the map.");
            }
            Drone = drone;
            StartedAt = startedAt;
            StartPosition = source;
            Destination = destination;
        }
    }
}
