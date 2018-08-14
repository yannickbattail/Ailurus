namespace Ailurus.DTO
{
    public interface IDrone<TCoordinate> where TCoordinate : ICoordinate
    {
        string Name { get; set; }
        IDroneInstruction LastInstruction { get; set; }
        TCoordinate CurrentPosition { get; set; }
        DroneState DroneState { get; set; }
    }
}