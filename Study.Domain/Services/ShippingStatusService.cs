using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class ShippingStatusService : BaseService_1<ShippingStatus, IShippingStatusRepository, OutputShippingStatus, ShippingStatusDTO, ShippingStatusInternalPropertiesDTO, ShippingStatusAuxiliaryPropertiesDTO>, IShippingStatusService
    {
        public ShippingStatusService(IShippingStatusRepository contextInterface) : base(contextInterface, null) { }
    }
}
