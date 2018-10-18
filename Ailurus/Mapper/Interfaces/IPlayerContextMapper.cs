using Ailurus.DTO.Responses.Interfaces;
using Ailurus.Model;

namespace Ailurus.Mapper.Interfaces
{
    public interface IPlayerContextMapper
    {
        IPlayerContextDto Map(IPlayerContext playerContext);
        IDroneDto Map(IDrone drone);
    }
}