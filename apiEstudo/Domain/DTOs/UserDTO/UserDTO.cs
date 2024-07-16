using apiEstudo.Application.Arguments;

namespace apiEstudo.Domain.DTOs.UserDTO
{
    public class UserDTO : BaseDTO<InputCreateUser, InputUpdateUser, OutputUser, UserDTO, UserExternalPropertiesDTO, UserInternalPropertiesDTO, UserAuxiliaryPropertiesDTO>
    {
        public UserDTO() { }
    }
}
