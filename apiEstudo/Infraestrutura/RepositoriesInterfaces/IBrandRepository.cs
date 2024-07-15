using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Brand;
using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IBrandRepository : IBaseRepository_2<Brand, InputCreateBrand, InputUpdateBrand, InputIdentityUpdateBrand>
    {
    }
}
