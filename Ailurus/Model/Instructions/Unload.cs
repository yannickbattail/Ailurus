using System;
using System.Threading.Tasks;
using Ailurus.DTO;
using Ailurus.DTO.Interfaces;
using Ailurus.Repository;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

namespace Ailurus.Model.Instructions
{
    public class Unload<TCoordinate> : AbstractInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        public ResourceQuantity Resource { get; protected set; }
        
        public override DateTime EndAt
        {
            get
            {
                return StartedAt.AddSeconds(Duration);
            }
            protected set{}
        }

        public override double Duration
        {
            get
            {
                return 5;
            }
            protected set{}
        }

        public Unload(IDrone<TCoordinate> drone, DateTime startedAt)
        {
            Drone = drone;
            StartedAt = startedAt;
            Resource = drone.Storage;
        }
    }
}
