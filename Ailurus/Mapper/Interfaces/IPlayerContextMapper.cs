using Ailurus.DTO.Interfaces;
using Ailurus.Model;

namespace Ailurus.Mapper.Interfaces
{
    public interface IPlayerContextMapper<TCoordinate> where TCoordinate : ICoordinate
    {
        IPlayerContextDto<TCoordinate> Map(IPlayerContext<TCoordinate> playerContext);
        IDroneDto<TCoordinate> Map(IDrone<TCoordinate> drone);
    }
}