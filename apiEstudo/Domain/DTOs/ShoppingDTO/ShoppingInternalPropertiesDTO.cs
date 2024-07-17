namespace apiEstudo.Domain.DTOs
{
    public class ShoppingInternalPropertiesDTO : BaseInternalPropertiesDTO<ShoppingInternalPropertiesDTO>
    {
        public long ShippingStatusId { get; set; }
        public ShoppingInternalPropertiesDTO() { }

        public ShoppingInternalPropertiesDTO(long shippingStatusId)
        {
            ShippingStatusId = shippingStatusId;
        }
    }
}
