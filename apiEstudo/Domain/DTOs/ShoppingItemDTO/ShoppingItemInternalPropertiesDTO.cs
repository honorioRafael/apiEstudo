namespace apiEstudo.Domain.DTOs
{
    public class ShoppingItemInternalPropertiesDTO : BaseInternalPropertiesDTO<ShoppingItemInternalPropertiesDTO>
    {
        public long ShoppingId { get; set; }
        public ShoppingItemInternalPropertiesDTO() { }

        public ShoppingItemInternalPropertiesDTO(long shoppingId)
        {
            ShoppingId = shoppingId;
        }
    }
}
