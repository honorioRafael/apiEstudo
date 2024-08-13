using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Interface.Repository.Base;

namespace Study.Domain.Interface.Repository
{
    public interface IShoppingItemRepository : IBaseRepository<InputCreateShoppingItem, InputUpdateShoppingItem, OutputShoppingItem, ShoppingItemDTO, ShoppingItemExternalPropertiesDTO, ShoppingItemInternalPropertiesDTO, ShoppingItemAuxiliaryPropertiesDTO>
    { }
}
