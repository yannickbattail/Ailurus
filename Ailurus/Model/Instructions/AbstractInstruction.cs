using System;
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

        public async void ScheduleEndInstructionAction(IPlayerContext<TCoordinate> playerContext)
        {
            await Task.Run(async () => //Task.Run automatically unwraps nested Task types!
            {
                Console.WriteLine("Schedule "+GetType().Name);
                await Task.Delay((int) (Duration * 1000));
                EndInstructionAction(playerContext.PlayerName);
                Console.WriteLine("Done "+GetType().Name);
            });
            Console.WriteLine("All done"+GetType().Name);
        }

        protected abstract void EndInstructionAction(string playerName);
    }
}