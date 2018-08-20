using System;
using Ailurus.DTO;
using Ailurus.DTO.Interfaces;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Ailurus.Model.Instructions
{
    public class Unload<TCoordinate> : IInstruction<TCoordinate> where TCoordinate : ICoordinate
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

        public Unload(IDrone<TCoordinate> drone, DateTime startedAt)
        {
            Drone = drone;
            StartedAt = startedAt;
        }
    }
}
