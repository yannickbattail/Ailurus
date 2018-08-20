using System;
using Ailurus.DTO;
using Ailurus.DTO.Interfaces;

namespace Ailurus.Model.Instructions
{
    public class Collect<TCoordinate> : IInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        public static readonly int Duration = 1;

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
    }
}
