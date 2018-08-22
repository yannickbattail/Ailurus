using System;
using System.Threading.Tasks;
using Ailurus.DTO;
using Ailurus.DTO.Interfaces;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Ailurus.Model.Instructions
{
    public class Unload<TCoordinate> : IInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        public static readonly int Duration = 7;

        public IDrone<TCoordinate> Drone { get; set; }
        public DateTime StartedAt { get; set; }

        public DateTime EndAt
        {
            get
            {
                return StartedAt.AddSeconds(Duration);
            }
        }

        public Unload(IDrone<TCoordinate> drone, DateTime startedAt)
        {
            Drone = drone;
            StartedAt = startedAt;
        }
        
        public async void DoIt()
        {
            await Task.Run(async () => //Task.Run automatically unwraps nested Task types!
            {
                Console.WriteLine("Schedule "+this.GetType().Name);
                await Task.Delay(Duration * 1000);
                DoDo();
                Console.WriteLine("Done "+this.GetType().Name);
            });
            Console.WriteLine("All done "+this.GetType().Name);
        }

        private void DoDo()
        {
            
        }
    }
}
