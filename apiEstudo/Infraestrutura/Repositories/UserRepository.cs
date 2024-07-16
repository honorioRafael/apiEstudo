using apiEstudo.Application.Arguments;
using apiEstudo.Domain.DTOs.UserDTO;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class UserRepository : BaseRepository<User, InputCreateUser, InputUpdateUser, OutputUser, UserDTO, UserExternalPropertiesDTO, UserInternalPropertiesDTO, UserAuxiliaryPropertiesDTO>, IUserRepository
    {
        public UserRepository(ConnectionContext context) : base(context)
        { }

        public User? GetByName(string name)
        {
            return _dbset.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
