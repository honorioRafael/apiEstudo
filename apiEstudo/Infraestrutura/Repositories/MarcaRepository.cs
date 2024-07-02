using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class MarcaRepository : BaseRepository<Marca>, IMarcaRepository
    {
        public MarcaRepository(ConnectionContext context) : base(context)
        {
        }
    }
}
