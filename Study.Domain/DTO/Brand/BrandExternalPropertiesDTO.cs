namespace Study.Domain.DTO
{
    public class BrandExternalPropertiesDTO : BaseExternalPropertiesDTO<BrandExternalPropertiesDTO>
    {
        public string Name { get; set; }

        public BrandExternalPropertiesDTO() { }

        public BrandExternalPropertiesDTO(string name)
        {
            Name = name;
        }
    }
}
