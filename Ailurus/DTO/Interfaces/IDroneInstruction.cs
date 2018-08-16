namespace Ailurus.DTO
{
    public interface IDroneInstruction<TCoordinate> where TCoordinate : ICoordinate
    {
        string TYPE { get; }
        string DroneName { get; set; }
    }
}