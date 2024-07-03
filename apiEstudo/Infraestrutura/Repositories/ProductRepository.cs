using apiEstudo.Domain.Models;
using apiEstudo.Domain.Model;
using Microsoft.EntityFrameworkCore;
using apiEstudo.Mappings;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
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
            return _dbset.Where(x => x.Id == id).Include(x => x.Brand).FirstOrDefault();
        }
    }
}
