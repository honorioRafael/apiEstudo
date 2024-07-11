using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class ShippingStatusService : BaseService<ShippingStatus, IShippingStatusRepository, BaseInputIdentityUpdate_0, OutputShippingStatus>, IShippingStatusService
    {
        public ShippingStatusService(IShippingStatusRepository contextInterface) : base(contextInterface) { }
    }
}
