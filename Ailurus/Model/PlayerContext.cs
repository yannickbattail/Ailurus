using Ailurus.DTO.Responses.Interfaces;
using Ailurus.Model.Instructions;
using Ailurus.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ailurus.Model
{
    public class PlayerContext : IPlayerContext
    {
        public IEnumerable<IDrone> Drones { get; set; }
        public string PlayerName { get; set; }
        public string Pass { get; set; }
        public int Level { get; set; }

        public IEnumerable<ResourceQuantity> Resources
        {
            get { return GetStoredResourcesAt(DateTime.Now); }
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

        public DateTime? GetStartTime()
        {
            return Drones.SelectMany(
                drone => drone.GetValidInstructions()
            ).OrderBy(
                i => i.EndAt
            ).Select(
                i => i.EndAt
            ).FirstOrDefault();
        }

        public TimeSpan? GetSpentTime()
        {
            var start = GetStartTime();
            if (!start.HasValue)
            {
                return null;
            }

            return DateTime.Now - start.Value;
        }

        public bool IsTimeGoalAchieved()
        {
            var timeSpent = GetSpentTime();

            if (!timeSpent.HasValue)
            {
                return false;
            }

            if (timeSpent > GetMap().TimeLimitGoal)
            {
                return false;
            }

            return true;
        }

        public DateTime? GetTimeWhenResoucesGoalIsAchieved()
        {
            var unloads = GetAllUnloadInstruction();
            foreach (var unload in unloads)
            {
                var resourcesCount = GetStoredResourcesAt(unload.EndAt);
                if (IsResourceGoalAchieved(GetMap().ResourceGoal, resourcesCount))
                {
                    return unload.EndAt;
                }
            }

            return null;
        }

        private IEnumerable<Unload> GetAllUnloadInstruction()
        {
            return Drones.SelectMany(
                drone => drone.GetValidInstructions()
                    .Where(
                        i => i.GetType() == typeof(Unload)
                    ).Select(
                        i => (i as Unload)
                    )
            ).OrderBy(
                u => u.EndAt
            );
        }

        public bool IsResourceGoalAchieved()
        {
            return IsResourceGoalAchieved(GetMap().ResourceGoal);
        }

        public bool IsResourceGoalAchieved(IEnumerable<ResourceQuantity> goal)
        {
            return IsResourceGoalAchieved(goal, Resources);
        }

        public bool IsResourceGoalAchieved(IEnumerable<ResourceQuantity> goal, IEnumerable<ResourceQuantity> resourceList)
        {
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