using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class ShippingStatusRepository : BaseRepository<ShippingStatus, BaseInputCreate_0, BaseInputUpdate_0>, IShippingStatusRepository
    {
        public ShippingStatusRepository(ConnectionContext connectionContext) : base(connectionContext)
        {
        }
    }
}
