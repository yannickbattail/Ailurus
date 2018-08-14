namespace Ailurus.DTO.Implementation.DroneInstruction
{
    public class Unload : IDroneInstruction
    {
        public string TYPE
        {
            get { return this.GetType().Name; }
        }
        public string DroneName { get; set; }
    }
}
