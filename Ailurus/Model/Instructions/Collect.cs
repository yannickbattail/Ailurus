using System;
using System.Linq;
using Ailurus.DTO.Implementation;
using Ailurus.DTO.Interfaces;
using Ailurus.Service;

namespace Ailurus.Model.Instructions
{
    public class Collect<TCoordinate> : AbstractInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        public Mine<TCoordinate> Mine { get; set; }
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

        public Collect(IDrone<TCoordinate> drone, DateTime startedAt)
        {
            var util = AppService<TCoordinate>.GetAppService().GetCoordinateUtils();
            var item = AppService<TCoordinate>.GetAppService().GetMap().Items.FirstOrDefault(
                    itm => (itm.GetType() == typeof(Mine<TCoordinate>))
                        && util.IsNear(drone.CurrentPosition, itm.Position)
                );
            if (item == null)
            {
                throw new InvalidInstructionException<TCoordinate>("No mine near the drone");
            }
            var mine = item as Mine<TCoordinate>;
            Drone = drone;
            StartedAt = startedAt;
            Mine = mine;
        }
    }
}
