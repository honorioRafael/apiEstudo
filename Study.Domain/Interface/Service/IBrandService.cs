using Study.Arguments.Arguments;
using Study.Arguments.Arguments.Brand;

namespace Study.Domain.Interface.Service
{
    public interface IBrandService : IBaseService<InputCreateBrand, InputUpdateBrand, InputIdentityUpdateBrand, InputIdentityDeleteBrand, OutputBrand> { }
}
