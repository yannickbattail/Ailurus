using System;
using System.Collections.Generic;
using System.Linq;
using Ailurus.DTO.Interfaces;
using Ailurus.Model.Instructions;

namespace Ailurus.Model
{
    public class PlayerContext : IPlayerContext
    {
        public IEnumerable<IDrone> Drones { get; set; }
        public string PlayerName { get; set; }
        public IEnumerable<ResourceQuantity> Resources {
            get { return GetStoredResourcesAt(DateTime.Now);}
        }

        public PlayerContext()
        {
            Drones = new List<IDrone>();
        }
        
        public IEnumerable<ResourceQuantity> GetStoredResourcesAt(DateTime time)
        {
            return Drones.SelectMany(
                drone => drone.GetValidInstructions()
                    .Where(
                        i => i.IsFinishedAt(time) && i.GetType() == typeof(Unload)
                    ).Select(
                        i => (i as Unload).Resource
                    )
                ).GroupBy(
                    rq => rq.Resource
                ).Select(
                    rqGroup => new ResourceQuantity()
                    {
                        Resource = rqGroup.Key,
                        Quantity = rqGroup.Sum(
                            rq => rq.Quantity
                            )
                    }
                );
        }
    }
}