namespace Study.Domain.DTO
{
    public class ProductAuxiliaryPropertiesDTO : BaseAuxiliaryPropertiesDTO<ProductAuxiliaryPropertiesDTO>
    {
        public BrandDTO BrandDTO { get; set; }
        public ProductAuxiliaryPropertiesDTO() { }

        public ProductAuxiliaryPropertiesDTO(BrandDTO brand)
        {
            BrandDTO = brand;
        }
    }
}
