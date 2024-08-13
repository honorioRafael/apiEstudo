using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Interface.Repository;
using Study.Infrastructure.Context;
using Study.Infrastructure.Entry;
using Study.Infrastructure.Repository.Base;

namespace Study.Infrastructure.Repository
{
    public class ShoppingItemRepository : BaseRepository<ShoppingItem, InputCreateShoppingItem, InputUpdateShoppingItem, OutputShoppingItem, ShoppingItemDTO, ShoppingItemExternalPropertiesDTO, ShoppingItemInternalPropertiesDTO, ShoppingItemAuxiliaryPropertiesDTO>, IShoppingItemRepository
    {
        public ShoppingItemRepository(AppDbContext context) : base(context)
        { }
    }
}
