using System;
using System.Linq;
using System.Threading.Tasks;
using Ailurus.DTO;
using Ailurus.DTO.Implementation;
using Ailurus.DTO.Interfaces;
using Ailurus.Repository;
using Ailurus.Service;
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
            var util = AppService<TCoordinate>.GetAppService().GetCoordinateUtils();
            var item = AppService<TCoordinate>.GetAppService().GetMap().Items.FirstOrDefault(
                itm => (itm.GetType() == typeof(MainBuilding<TCoordinate>))
                       && util.IsNear(drone.CurrentPosition, itm.Position)
            );
            if (item == null)
            {
                throw new InvalidInstructionException<TCoordinate>("No MainBuilding near the drone");
            }
            Drone = drone;
            StartedAt = startedAt;
            Resource = drone.Storage;
            AbortedAt = null;
        }
    }
}
