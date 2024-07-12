using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Brand;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IBrandService : IBaseService_2<InputCreateBrand, InputUpdateBrand, InputIdentityUpdateBrand, InputIdentityDeleteBrand, OutputBrand> { }
}
