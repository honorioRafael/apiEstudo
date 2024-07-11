using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class ShippingStatusRepository : BaseRepository<ShippingStatus>, IShippingStatusRepository
    {
        public ShippingStatusRepository(ConnectionContext connectionContext) : base(connectionContext)
        {
        }
    }
}
