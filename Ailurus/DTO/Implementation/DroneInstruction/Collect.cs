namespace Ailurus.DTO.Implementation.DroneInstruction
{
    public class Collect : IDroneInstruction
    {
        public string TYPE
        {
            get { return this.GetType().Name; }
        }
        public string DroneName { get; set; }
    }
}
