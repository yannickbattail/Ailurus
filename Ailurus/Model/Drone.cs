using System;
using System.Collections.Generic;
using System.Linq;
using Ailurus.DTO.Interfaces;
using Ailurus.Model.Instructions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ailurus.Model
{
    public class Drone: IDrone
    {
        public string Name { get; set; }
        protected IList<IInstruction> Instructions { get; set; }
        public double Speed { get; set; }
        public int StorageSize { get; set; }
        public ICoordinate InitialPosition { get; set; }
        
        public ResourceQuantity Storage {
            get
            {
                var lastCollect = Instructions.LastOrDefault(
                    i => (i.GetType() == typeof(Collect)
                          || i.GetType() == typeof(Unload))
                         && !i.IsAborted
                );
                if (lastCollect == null || lastCollect.GetType() == typeof(Unload))
                {
                    return null;
                }
                var instructionCollect = lastCollect as Collect;
                return new ResourceQuantity()
                {
                    Resource = instructionCollect.Mine.ResourceType,
                    Quantity = StorageSize
                };
            }
        }

        public void AddInstruction(IInstruction instruction)
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

        public IEnumerable<IInstruction> GetInstructions()
        {
            return Instructions;
        }

        public IEnumerable<IInstruction> GetValidInstructions()
        {
            return Instructions.Where(i => !i.IsAborted);
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public DroneState State
        {
            get
            {
                return GetStateAt(DateTime.Now);
            }
        }
        
        public ICoordinate CurrentPosition
        {
            get
            {
                return GetPositionAt(DateTime.Now);
            }
        }

        public Drone(ICoordinate initialPosition)
        {
            if (initialPosition == null)
            {
                throw new ArgumentNullException();
            }
            InitialPosition = initialPosition;
            Instructions = new List<IInstruction>();
        }
        
        public IInstruction GetLastValidInstruction()
        {
            if (Instructions == null || !Instructions.Any())
            {
                return null;
            }

            return Instructions.LastOrDefault(i => !i.IsAborted);
        }

        public DroneState GetStateAt(DateTime time)
        {
            var lastInstruction = GetLastValidInstruction();
            if (lastInstruction == null
                || lastInstruction.EndAt < time)
            {
                return DroneState.WaitingForOrders;
            }

            return DroneState.ExecutionInstruction;
        }

        public ICoordinate GetPositionAt(DateTime time)
        {
            var lastMoveTo = GetValidInstructions().LastOrDefault(
                i => i.GetType() == typeof(MoveTo)
            );
            if (lastMoveTo == null)
            {
                return InitialPosition;
            }
            var instructionMoveTo = lastMoveTo as MoveTo;
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
