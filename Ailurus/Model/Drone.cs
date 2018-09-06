using System;
using System.Collections.Generic;
using System.Linq;
using Ailurus.DTO.Interfaces;
using Ailurus.Model.Instructions;
using Ailurus.Service;

namespace Ailurus.Model
{
    public class Drone<TCoordinate> : IDrone<TCoordinate> where TCoordinate : ICoordinate
    {
        public string Name { get; set; }
        protected IList<IInstruction<TCoordinate>> Instructions { get; set; }
        public double Speed { get; set; }
        public int StorageSize { get; set; }
        
        public ResourceQuantity Storage {
            get
            {
                var lastCollect = Instructions.Last(
                    i => (i.GetType() == typeof(Collect<TCoordinate>)
                          || i.GetType() == typeof(Unload<TCoordinate>))
                         && !i.IsAborted
                );
                if (lastCollect.GetType() == typeof(Unload<TCoordinate>))
                {
                    return null;
                }
                var instructionCollect = lastCollect as Collect<TCoordinate>;
                return new ResourceQuantity()
                {
                    Resource = instructionCollect.Mine.ResourceType,
                    Quantity = StorageSize
                };
            }
        }

        public void AddInstruction(IInstruction<TCoordinate> instruction)
        {
            Instructions.Add(instruction);
        }

        public void AbortLastInstruction()
        {
            var lastInstr = Instructions.Last();
            if (lastInstr.IsAborted)
            {
                throw new InvalidOperationException("");
            }

            lastInstr.Abort();
        }

        public IEnumerable<IInstruction<TCoordinate>> GetInstructions()
        {
            return Instructions;
        }

        public IEnumerable<IInstruction<TCoordinate>> GetValidInstructions()
        {
            return Instructions.Where(i => !i.IsAborted);
        }

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
        }

        public Drone()
        {
            var startCoord = AppService<TCoordinate>.GetAppService().GetMap().Dimensions.Item1;
            Instructions = new List<IInstruction<TCoordinate>>()
            {
                new MoveTo<TCoordinate>(this, DateTime.Now, startCoord, startCoord)
            };
        }
        
        public IInstruction<TCoordinate> GetLastValidInstruction()
        {
            if (Instructions == null || !Instructions.Any())
            {
                return null;
            }

            return Instructions.Last(i => !i.IsAborted);
        }

        public DroneState GetStateAt(DateTime time)
        {
            if (GetLastValidInstruction() == null
                || GetLastValidInstruction().EndAt < time)
            {
                return DroneState.WaitingForOrders;
            }

            return DroneState.ExecutionInstruction;
        }

        public TCoordinate GetPositionAt(DateTime time)
        {
            var lastMoveTo = Instructions.Last(
                i => i.GetType() == typeof(MoveTo<TCoordinate>) && !i.IsAborted
            );
            var instructionMoveTo = lastMoveTo as MoveTo<TCoordinate>;
            return instructionMoveTo.GetPositionAt(time);
        }
        
        
        /// <summary>
        /// https://xkcd.com/221/
        /// </summary>
        /// <returns></returns>
        int getRandomNumber()
        {
            return 4; // chosen by fair dice roll.
            // guaranteed to be random.
        }
    }
}
