using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Models;

namespace Study.Domain.Interface.Repository
{
    public interface IShoppingItemRepository : IBaseRepository<ShoppingItem, InputCreateShoppingItem, InputUpdateShoppingItem, OutputShoppingItem, ShoppingItemDTO, ShoppingItemExternalPropertiesDTO, ShoppingItemInternalPropertiesDTO, ShoppingItemAuxiliaryPropertiesDTO>
    { }
}
