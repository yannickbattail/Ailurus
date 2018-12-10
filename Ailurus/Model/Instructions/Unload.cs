using System;
using System.Linq;
using Ailurus.Service;

namespace Ailurus.Model.Instructions
{
    public class Unload : AbstractInstruction
    {
        public ResourceQuantity Resource { get; set; }
        
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
        
        public Unload(){}
            
        public Unload(IPlayerContext playerContext, IDrone drone, DateTime startedAt)
        {
            var item = playerContext.GetMap().Factories.FirstOrDefault(
                itm => drone.CurrentPosition.IsNear(itm.Position)
            );
            if (item == null)
            {
                throw new InvalidInstructionException("No factory near the drone");
            }
            Drone = drone;
            StartedAt = startedAt;
            Resource = drone.Storage;
            AbortedAt = null;
        }
    }
}
