namespace Ailurus.DTO
{
    public interface ICoordinate
    {
        double GetDistanceTo(ICoordinate destination);
    }
}