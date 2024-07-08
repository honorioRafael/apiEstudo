using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class ShoppingRepository : BaseRepository<Shopping>, IShoppingRepository
    {
        public ShoppingRepository(ConnectionContext context) : base(context)
        {
        }

        public override List<Shopping>? GetAll()
        {
            return _dbset.Include(x => x.Products)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.Brand)
                .Include(x => x.Employee)
                .ThenInclude(x => x.EmployeeTask).ToList();
        }

        public override Shopping? Get(int id)
        {
            return _dbset.Where(x => x.Id == id).Include(x => x.Products)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.Brand)
                .Include(x => x.Employee)
                .ThenInclude(x => x.EmployeeTask).AsNoTracking().FirstOrDefault();
        }
    }
}
