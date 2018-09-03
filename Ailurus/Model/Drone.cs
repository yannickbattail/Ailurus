using System;
using System.Collections.Generic;
using Ailurus.DTO;
using Ailurus.DTO.Interfaces;
using Ailurus.Model.Instructions;

namespace Ailurus.Model
{
    public class Drone<TCoordinate> : IDrone<TCoordinate> where TCoordinate : ICoordinate
    {
        public string Name { get; set; }
        public IInstruction<TCoordinate> LastInstruction { get; set; }
        public double Speed { get; set; }
        public int StorageSize { get; set; }
        public ResourceQuantity Storage { get; set; }
        
        protected TCoordinate _currentPosition;
        
        public DroneState State
        {
            get
            {
                return GetStateAt(DateTime.Now);
            }
        }
        
        public TCoordinate CurrentPosition
        {
            get
            {
                return GetPositionAt(DateTime.Now);
            }
            set { _currentPosition = value; }
        }

        public DroneState GetStateAt(DateTime time)
        {
            if (LastInstruction == null
                || LastInstruction.EndAt < time)
            {
                return DroneState.WaitingForOrders;
            }

            return DroneState.ExecutionInstruction;
        }

        public TCoordinate GetPositionAt(DateTime time)
        {
            if (LastInstruction.GetType() != typeof(MoveTo<TCoordinate>))
            {
                return _currentPosition;
            }
            var instructionMoveTo = LastInstruction as MoveTo<TCoordinate>;
            return instructionMoveTo.GetPositionAt(time);
        }
    }
}
