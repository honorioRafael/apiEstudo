using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.DTO.UserDTO;
using Study.Domain.Models;

namespace Study.Domain.Interface.Repository
{
    public interface IUserRepository : IBaseRepository<User, InputCreateUser, InputUpdateUser, OutputUser, UserDTO, UserExternalPropertiesDTO, UserInternalPropertiesDTO, UserAuxiliaryPropertiesDTO>
    {
        public UserDTO? GetByName(string username);
    }
}
