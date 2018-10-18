using System;
using System.Linq;
using Ailurus.DTO.Responses.Implementations;
using Ailurus.Service;

namespace Ailurus.Model.Instructions
{
    public class Collect : AbstractInstruction
    {
        public Mine Mine { get; set; }
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

        public Collect(IDrone drone, DateTime startedAt)
        {
            var item = AppService.GetAppService().GetMap().Mines.FirstOrDefault(
                    itm => drone.CurrentPosition.IsNear(itm.Position)
                );
            if (item == null)
            {
                throw new InvalidInstructionException("No mine near the drone");
            }
            var mine = item as Mine;
            Drone = drone;
            StartedAt = startedAt;
            Mine = mine;
        }
    }
}
