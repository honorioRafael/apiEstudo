using apiEstudo.Application.Arguments;

namespace apiEstudo.Domain.DTOs
{
    public class ShoppingItemDTO : BaseDTO<InputCreateShoppingItem, InputUpdateShoppingItem, OutputShoppingItem, ShoppingItemDTO, ShoppingItemExternalPropertiesDTO, ShoppingItemInternalPropertiesDTO, ShoppingItemAuxiliaryPropertiesDTO>
    {
        public ShoppingItemDTO() { }
    }
}
