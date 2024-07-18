using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Models;
using Study.Domain.Interface.Repository;
using Study.Infrastructure.Map;

namespace Study.Infrastructure.Repository
{
    public class ShoppingItemRepository : BaseRepository<ShoppingItem, InputCreateShoppingItem, InputUpdateShoppingItem, OutputShoppingItem, ShoppingItemDTO, ShoppingItemExternalPropertiesDTO, ShoppingItemInternalPropertiesDTO, ShoppingItemAuxiliaryPropertiesDTO>, IShoppingItemRepository
    {
        public ShoppingItemRepository(ConnectionContext context) : base(context)
        { }
    }
}
