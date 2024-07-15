using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class ShoppingItemRepository : BaseRepository<ShoppingItem, InputCreateShoppingItem>, IShoppingItemRepository
    {
        public ShoppingItemRepository(ConnectionContext context) : base(context)
        { }
    }
}
