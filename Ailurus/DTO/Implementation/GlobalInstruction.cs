using Ailurus.DTO.Interfaces;

namespace Ailurus.DTO.Implementation
{
    public class GlobalInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        public string TYPE { get; set; }
        public string DroneName { get; set; }
        
        public TCoordinate Destination { get; set; }

        public override string ToString()
        {
            return $"{nameof(TYPE)}: {TYPE}, {nameof(DroneName)}: {DroneName}, {nameof(Destination)}: {Destination}";
        }
    }
}