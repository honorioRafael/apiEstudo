using Study.Domain.DTO;
using Study.Infrastructure.Entry.Base;

namespace Study.Infrastructure.Entry
{
    public class Brand : BaseEntry<Brand>
    {
        public string Name { get; set; }
        public virtual List<Product> ListProduct { get; set; }

        public Brand(string name)
        {
            Name = name;
        }

        public Brand() { }


        public static implicit operator BrandDTO(Brand brand)
        {
            return brand == null ? default : new BrandDTO().Create(
                brand.Id,
                new BrandExternalPropertiesDTO(brand.Name),
                new BrandInternalPropertiesDTO().LoadInternalData(brand.Id, brand.CreationDate, brand.ChangeDate));
        }

        public static implicit operator Brand(BrandDTO dto)
        {
            return dto == null ? default : new Brand(dto.ExternalPropertiesDTO.Name).LoadInternalData(dto.InternalPropertiesDTO.Id, dto.InternalPropertiesDTO.CreationDate, dto.InternalPropertiesDTO.ChangeDate);
        }
    }
}