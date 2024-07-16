using apiEstudo.Application.Arguments;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.DTOs.UserDTO;
using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IUserRepository : IBaseRepository<User, InputCreateUser, InputUpdateUser, OutputUser, UserDTO, UserExternalPropertiesDTO, UserInternalPropertiesDTO, UserAuxiliaryPropertiesDTO>
    {
        public User? GetByName(string username);
    }
}
