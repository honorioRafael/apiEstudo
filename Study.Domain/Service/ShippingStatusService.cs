using Study.Arguments.Arguments;
using Study.Domain.Interface.Service;
using Study.Domain.DTO;
using Study.Domain.Models;
using Study.Domain.Interface.Repository;

namespace Study.Domain.Service
{
    public class ShippingStatusService : BaseService_1<ShippingStatus, IShippingStatusRepository, OutputShippingStatus, ShippingStatusDTO, ShippingStatusInternalPropertiesDTO, ShippingStatusAuxiliaryPropertiesDTO>, IShippingStatusService
    {
        public ShippingStatusService(IShippingStatusRepository contextInterface) : base(contextInterface, null) { }
    }
}
