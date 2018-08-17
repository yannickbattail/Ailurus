using System;
using Ailurus.Model.Instructions;

namespace Ailurus.DTO.Implementation
{
    public class Drone<TCoordinate> : IDrone<TCoordinate> where TCoordinate : ICoordinate
    {
        public string Name { get; set; }
        public IInstruction<TCoordinate> LastInstruction { get; set; }
        public TCoordinate CurrentPosition { get; set; }

        public DroneState GetStateAt(DateTime Time)
        {
            if (LastInstruction == null
                || LastInstruction.EndAt < Time)
            {
                return DroneState.WaitingForOrders;
            }

            return DroneState.ExecutionInstruction;
        }

        public double Speed { get; set; }
        
        public DroneState State
        {
            get
            {
                return GetStateAt(DateTime.Now);
            }
        }

    }
}
