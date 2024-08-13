namespace Study.Domain.DTO
{
    public class ProductExternalPropertiesDTO : BaseExternalPropertiesDTO<ProductExternalPropertiesDTO>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public long BrandId { get; set; }

        public ProductExternalPropertiesDTO() { }

        public ProductExternalPropertiesDTO(string name, int quantity, long brandId)
        {
            Name = name;
            Quantity = quantity;
            BrandId = brandId;
        }
    }
}
