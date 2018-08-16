using System;
using Ailurus.Model.Instructions;

namespace Ailurus.DTO.Implementation
{
    public class Drone<TCoordinate> : IDrone<TCoordinate> where TCoordinate : ICoordinate
    {
        public string Name { get; set; }
        public IInstruction<TCoordinate> LastInstruction { get; set; }
        public TCoordinate CurrentPosition { get; set; }

        public double Speed { get; set; }
        
        public DroneState DroneState
        {
            get
            {
                if (LastInstruction == null
                    || LastInstruction.EndAt < DateTime.Now)
                {
                    return DroneState.WaitingForOrders;
                }

                return DroneState.ExecutionInstruction;
            }
        }

    }
}
