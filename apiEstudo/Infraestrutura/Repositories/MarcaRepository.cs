using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class MarcaRepository : BaseRepository<Marca, MarcaDTO>, IMarcaRepository
    {
        public MarcaRepository(ConnectionContext context) : base(context)
        {
        }
    }
}
