namespace Ailurus.DTO.Interfaces
{
    public interface ICoordinate
    {
        double GetDistanceTo(ICoordinate destination);
    }
}