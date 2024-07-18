using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Interface.Repository;
using Study.Infrastructure.Context;
using Study.Infrastructure.Entry;

namespace Study.Infrastructure.Repository
{
    public class ShippingStatusRepository : BaseRepository_2<ShippingStatus, OutputShippingStatus, ShippingStatusDTO, ShippingStatusInternalPropertiesDTO, ShippingStatusAuxiliaryPropertiesDTO>, IShippingStatusRepository
    {
        public ShippingStatusRepository(AppDbContext connectionContext) : base(connectionContext)
        {
        }
    }
}
