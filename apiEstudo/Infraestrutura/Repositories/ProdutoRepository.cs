using apiEstudo.Domain.Models;
using apiEstudo.Domain.Model;
using Microsoft.EntityFrameworkCore;
using apiEstudo.Mappings;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ConnectionContext context) : base(context)
        {
        }

        public override List<Produto>? GetAll()
        {
            return _dbset.Include(x => x.Marca).ToList();
        }

        public override Produto? Get(int id)
        {
            return _dbset.Where(x => x.Id == id).Include(x => x.Marca).FirstOrDefault();
        }
    }
}
