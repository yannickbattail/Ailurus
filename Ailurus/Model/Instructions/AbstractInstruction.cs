using System;
using System.Threading;
using System.Threading.Tasks;
using Ailurus.DTO.Interfaces;
using Newtonsoft.Json;

namespace Ailurus.Model.Instructions
{
    public abstract class AbstractInstruction<TCoordinate> : IInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        [JsonIgnore]
        public IDrone<TCoordinate> Drone { get; protected set; }
        public DateTime StartedAt { get; protected set; }
        public abstract DateTime EndAt { get; protected set; }
        public abstract double Duration { get; protected set; }

        public double Progression
        {
            get { return GetProgressionAt(DateTime.Now); }
        }

        public DateTime? AbortedAt{ get; set; }

        public bool IsAborted
        {
            get { return !AbortedAt.HasValue; }
        }

        public bool IsFinishedAt(DateTime time)
        {
            return time >= EndAt;
        }

        public double GetProgressionAt(DateTime time){
            if (time <= StartedAt)
            {
                return 0;
            }
            if (time >= EndAt)
            {
                return 1;
            }
            return (time.Ticks - StartedAt.Ticks) / ((double)EndAt.Ticks - StartedAt.Ticks);
        }

        public void Abort()
        {
            AbortedAt = DateTime.Now;
        }
    }
}