using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Interface.Repository.Base;

namespace Study.Domain.Interface.Repository
{
    public interface IBrandRepository : IBaseRepository<InputCreateBrand, InputUpdateBrand, OutputBrand, BrandDTO, BrandExternalPropertiesDTO, BrandInternalPropertiesDTO, BrandAuxiliaryPropertiesDTO>
    { }
}
