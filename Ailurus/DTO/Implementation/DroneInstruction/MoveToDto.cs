using System;
using Ailurus.Model.Instructions;

namespace Ailurus.DTO.Implementation.DroneInstruction
{
    public class MoveToDto<TCoordinate> : IDroneInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        public string TYPE
        {
            get { return this.GetType().Name; }
        }
        public string DroneName { get; set; }
        
        public TCoordinate Destination { get; set; }
        
        public IInstruction<TCoordinate> ToIInstruction(DateTime startedAt, IDrone<TCoordinate> drone)
        {
            return new MoveTo<TCoordinate>(drone,startedAt,Destination,drone.CurrentPosition);
        }

    }
}
