using System;
using System.Collections.Generic;
using System.Linq;
using Ailurus.DTO.Interfaces;
using Ailurus.Model;
using Ailurus.Model.Instructions;

namespace Ailurus.DTO.Implementation
{
    public class PlayerContext<TCoordinate> : IPlayerContext<TCoordinate> where TCoordinate : ICoordinate
    {
        public IEnumerable<IDrone<TCoordinate>> Drones { get; set; }
        public string PlayerName { get; set; }
        public IEnumerable<ResourceQuantity> Resources {
            get { return GetStoredResourcesAt(DateTime.Now);}
        }

        public IEnumerable<ResourceQuantity> GetStoredResourcesAt(DateTime time)
        {
            return Drones.SelectMany(
                drone => drone.GetValidInstructions()
                    .Where(
                        i => i.IsFinishedAt(time) && i.GetType() == typeof(Unload<TCoordinate>)
                    ).Select(
                        i => (i as Unload<TCoordinate>).Resource
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