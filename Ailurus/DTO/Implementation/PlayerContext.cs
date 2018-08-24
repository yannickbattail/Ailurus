using System.Collections.Generic;
using System.Linq;
using Ailurus.DTO.Interfaces;
using Ailurus.Model;

namespace Ailurus.DTO.Implementation
{
    public class PlayerContext<TCoordinate> : IPlayerContext<TCoordinate> where TCoordinate : ICoordinate
    {
        public IEnumerable<IDrone<TCoordinate>> Drones { get; set; }
        public string PlayerName { get; set; }
        public IList<ResourceQuantity> Resources { get; set; }
        public void AddResource(ResourceQuantity resourceQuantity)
        {
            var res = Resources.FirstOrDefault(r => r.Resource == resourceQuantity.Resource);
            if (res == null)
            {
                Resources.Add(resourceQuantity);
            }
            else
            {
                res.Quantity += resourceQuantity.Quantity;
            }
        }
        
    }
}