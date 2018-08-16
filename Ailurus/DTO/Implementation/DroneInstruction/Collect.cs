namespace Ailurus.DTO.Implementation.DroneInstruction
{
    public class Collect<TCoordinate> : IDroneInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        public string TYPE
        {
            get { return this.GetType().Name; }
        }
        public string DroneName { get; set; }
    }
}
