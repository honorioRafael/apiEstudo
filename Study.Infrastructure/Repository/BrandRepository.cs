using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Models;
using Study.Domain.Interface.Repository;
using Study.Infrastructure.Map;

namespace Study.Infrastructure.Repository
{
    public class BrandRepository : BaseRepository<Brand, InputCreateBrand, InputUpdateBrand, OutputBrand, BrandDTO, BrandExternalPropertiesDTO, BrandInternalPropertiesDTO, BrandAuxiliaryPropertiesDTO>, IBrandRepository
    {
        public BrandRepository(ConnectionContext context) : base(context)
        {
        }
    }
}
