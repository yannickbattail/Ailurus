using System;
using Ailurus.DTO;
using Ailurus.DTO.Interfaces;

namespace Ailurus.Model.Instructions
{
    public class MoveTo<TCoordinate> : IInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
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
    }
}
