using System;
using Ailurus.DTO;

namespace Ailurus.Model.Instructions
{
    public class MoveTo<TCoordinate> : IInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        public static readonly int Duration = 1;
        public string TYPE
        {
            get { return this.GetType().Name; }
        }
        public string DroneName
        {
            get { return Drone.Name; }
        }

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
    
        public double GetDuration
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
    }
}
