namespace Ailurus.DTO.Requests.Implementations
{
    public class GlobalInstruction
    {
        public string TYPE { get; set; }
        public string DroneName { get; set; }
        
        public CoordinateInt2D Destination { get; set; }

        public override string ToString()
        {
            return $"{nameof(TYPE)}: {TYPE}, {nameof(DroneName)}: {DroneName}, {nameof(Destination)}: {Destination}";
        }
    }
}