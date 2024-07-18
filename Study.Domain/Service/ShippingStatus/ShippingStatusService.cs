using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Interface.Repository;
using Study.Domain.Interface.Service;
using Study.Domain.Service.Base;

namespace Study.Domain.Service
{
    public class ShippingStatusService : BaseService_1<IShippingStatusRepository, OutputShippingStatus, ShippingStatusDTO, ShippingStatusInternalPropertiesDTO, ShippingStatusAuxiliaryPropertiesDTO>, IShippingStatusService
    {
        public ShippingStatusService(IShippingStatusRepository contextInterface) : base(contextInterface, null) { }
    }
}
