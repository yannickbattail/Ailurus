using System;
using System.Collections.Generic;
using System.Linq;
using Ailurus.DTO.Responses.Interfaces;
using Ailurus.Model.Instructions;
using Ailurus.Service;

namespace Ailurus.Model
{
    public class PlayerContext : IPlayerContext
    {
        public IEnumerable<IDrone> Drones { get; set; }
        public string PlayerName { get; set; }
        public string Pass { get; set; }
        public int Level { get; set; }

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

        public bool IsGoalAchieved()
        {
            return IsGoalAchieved(GetMap().ResourceGoal);
        }
        
        public bool IsGoalAchieved(IEnumerable<ResourceQuantity> goal)
        {
            var resourceList = Resources.ToList();
            return goal.All(
                res => resourceList.FirstOrDefault(g => g.Resource == res.Resource)?.Quantity >= res.Quantity
            );
        }

        public IMapInfo GetMap()
        {
            return AppService.GetAppService().GetMap(Level);
        }
    }
}