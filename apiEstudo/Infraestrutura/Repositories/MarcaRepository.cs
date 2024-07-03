using apiEstudo.Domain.Models;
using apiEstudo.Mappings;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class MarcaRepository : BaseRepository<Marca>, IMarcaRepository
    {
        public MarcaRepository(ConnectionContext context) : base(context)
        {
        }
    }
}
