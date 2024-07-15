using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Product;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class ProductRepository : BaseRepository<Product, InputCreateProduct>, IProductRepository
    {
        public ProductRepository(ConnectionContext context) : base(context)
        {
        }

        public override List<Product>? GetAll()
        {
            return _dbset.Include(x => x.Brand).ToList();
        }

        public override Product? Get(int id)
        {
            return _dbset.Where(x => x.Id == id).Include(x => x.Brand).AsNoTracking().FirstOrDefault();
        }
    }
}
