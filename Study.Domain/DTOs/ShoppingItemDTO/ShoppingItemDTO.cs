using apiEstudo.Application.Arguments;

namespace apiEstudo.Domain.DTOs
{
    public class ShoppingItemDTO : BaseDTO<InputCreateShoppingItem, InputUpdateShoppingItem, OutputShoppingItem, ShoppingItemDTO, ShoppingItemExternalPropertiesDTO, ShoppingItemInternalPropertiesDTO, ShoppingItemAuxiliaryPropertiesDTO>
    {
        public ShoppingItemDTO() { }

        public static implicit operator OutputShoppingItem(ShoppingItemDTO dto)
        {
            return dto == null ? default : new OutputShoppingItem(dto.InternalPropertiesDTO.Id, dto.ExternalPropertiesDTO.Quantity, dto.ExternalPropertiesDTO.ProductId, dto.AuxiliaryPropertiesDTO.ProductDTO).LoadInternalData(dto.InternalPropertiesDTO.Id, dto.InternalPropertiesDTO.CreationDate, dto.InternalPropertiesDTO.ChangeDate);
        }

        public static implicit operator ShoppingItemDTO(OutputShoppingItem output)
        {
            return output == null ? default : new ShoppingItemDTO().Create(output.Id,
                new ShoppingItemExternalPropertiesDTO(output.ProductId, output.Quantity),
                new ShoppingItemInternalPropertiesDTO().LoadInternalData(output.Id, output.CreationDate, output.ChangeDate),
                new ShoppingItemAuxiliaryPropertiesDTO(output.Product, null));
        }

    }
}
