using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Interface.Repository.Base;

namespace Study.Domain.Interface.Repository
{
    public interface IShippingStatusRepository : IBaseRepository_2<OutputShippingStatus, ShippingStatusDTO, ShippingStatusInternalPropertiesDTO, ShippingStatusAuxiliaryPropertiesDTO>
    {

    }
}
