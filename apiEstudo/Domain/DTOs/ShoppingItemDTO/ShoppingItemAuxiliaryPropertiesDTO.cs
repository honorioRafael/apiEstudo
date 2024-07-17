namespace apiEstudo.Domain.DTOs
{
    public class ShoppingItemAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<ShoppingItemAuxiliaryPropertiesDTO>
    {
        public ProductDTO ProductDTO { get; set; }
        public ShoppingDTO ShoppingDTO { get; set; }

        public ShoppingItemAuxiliaryPropertiesDTO() { }

        public ShoppingItemAuxiliaryPropertiesDTO(ProductDTO productDTO, ShoppingDTO shoppingDTO)
        {
            ProductDTO = productDTO;
            ShoppingDTO = shoppingDTO;
        }
    }
}
