using apiEstudo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class ComprasRepository : BaseRepository<Compras>, ICompraRepository
    {
        public ComprasRepository(ConnectionContext context) : base(context)
        {
        }

        public override List<Compras>? GetAll()
        {
            return _dbset.Include(x => x.Produto).Include(x => x.Employee).ToList();
        }

        public override Compras? Get(int id)
        {
            return _dbset.Where(x => x.Id == id).Include(x => x.Produto).Include(x => x.Employee).FirstOrDefault();
        }
    }
}
