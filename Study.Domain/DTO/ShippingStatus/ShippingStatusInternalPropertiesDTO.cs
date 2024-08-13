namespace Study.Domain.DTO
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
