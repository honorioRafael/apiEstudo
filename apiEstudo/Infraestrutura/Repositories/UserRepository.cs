using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class UserRepository : BaseRepository<User, UserDTO>, IUserRepository
    {
        public UserRepository(ConnectionContext context) : base(context)
        { }
    }
}
