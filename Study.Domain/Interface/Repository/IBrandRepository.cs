using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Models;

namespace Study.Domain.Interface.Repository
{
    public interface IBrandRepository : IBaseRepository<Brand, InputCreateBrand, InputUpdateBrand, OutputBrand, BrandDTO, BrandExternalPropertiesDTO, BrandInternalPropertiesDTO, BrandAuxiliaryPropertiesDTO>
    {
    }
}
