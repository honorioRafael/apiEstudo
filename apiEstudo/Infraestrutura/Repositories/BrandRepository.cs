using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class BrandRepository : BaseRepository<Brand, BrandDTO>, IBrandRepository
    {
        public BrandRepository(ConnectionContext context) : base(context)
        {
        }
    }
}
