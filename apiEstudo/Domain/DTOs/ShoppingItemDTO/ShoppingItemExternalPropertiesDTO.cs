namespace apiEstudo.Domain.DTOs
{
    public class ShoppingItemExternalPropertiesDTO : BaseExternalPropertiesDTO<ShoppingItemExternalPropertiesDTO>
    {
        public long ProductId { get; set; }
        public double Quantity { get; set; }

        public ShoppingItemExternalPropertiesDTO() { }

        public ShoppingItemExternalPropertiesDTO(long productId, double quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
