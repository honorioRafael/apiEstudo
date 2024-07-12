using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class BrandRepository : BaseRepository_2<Brand, InputCreateBrand, InputUpdateBrand>, IBrandRepository
    {
        public BrandRepository(ConnectionContext context) : base(context)
        {
        }
    }
}
