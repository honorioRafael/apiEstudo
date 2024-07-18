namespace apiEstudo.Domain.DTOs
{
    public class ShippingStatusInternalPropertiesDTO : BaseInternalPropertiesDTO<ShippingStatusInternalPropertiesDTO>
    {
        public string Description { get; set; }

        public ShippingStatusInternalPropertiesDTO() { }

        public ShippingStatusInternalPropertiesDTO(string description)
        {
            Description = description;
        }
    }
}
