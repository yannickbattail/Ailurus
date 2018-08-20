using System;
using Ailurus.DTO;
using Ailurus.DTO.Interfaces;
using Ailurus.Model.Instructions;

namespace Ailurus.Model
{
    public class Drone<TCoordinate> : IDrone<TCoordinate> where TCoordinate : ICoordinate
    {
        public string Name { get; set; }
        public IInstruction<TCoordinate> LastInstruction { get; set; }
        public TCoordinate CurrentPosition { get; set; }

        public double Speed { get; set; }
        
        public DroneState State
        {
            get
            {
                return GetStateAt(DateTime.Now);
            }
        }

        public DroneState GetStateAt(DateTime Time)
        {
            if (LastInstruction == null
                || LastInstruction.EndAt < Time)
            {
                return DroneState.WaitingForOrders;
            }

            return DroneState.ExecutionInstruction;
        }

    }
}
