namespace Ailurus.DTO.Implementation
{
    public class Drone<TCoordinate> : IDrone<TCoordinate> where TCoordinate : ICoordinate
    {
        public string Name { get; set; }
        public IDroneInstruction LastInstruction { get; set; }
        public TCoordinate CurrentPosition { get; set; }
        public DroneState DroneState { get; set; }
    }
}
