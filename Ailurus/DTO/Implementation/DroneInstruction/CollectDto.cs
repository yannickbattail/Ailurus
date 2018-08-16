using System;
using Ailurus.Model.Instructions;

namespace Ailurus.DTO.Implementation.DroneInstruction
{
    public class CollectDto<TCoordinate> : IDroneInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        public string TYPE
        {
            get { return this.GetType().Name; }
        }
        public string DroneName { get; set; }
        
        public IInstruction<TCoordinate> ToIInstruction(DateTime StartedAt, IDrone<TCoordinate> drone)
        {
            return new Collect<TCoordinate>(drone,StartedAt);
        }
    }
}
