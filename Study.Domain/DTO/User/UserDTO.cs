using Study.Arguments.Arguments;

namespace Study.Domain.DTO.UserDTO
{
    public class UserDTO : BaseDTO<InputCreateUser, InputUpdateUser, OutputUser, UserDTO, UserExternalPropertiesDTO, UserInternalPropertiesDTO, UserAuxiliaryPropertiesDTO>
    {
        public UserDTO() { }

        public static implicit operator OutputUser(UserDTO dto)
        {
            return dto == null ? default : new OutputUser(dto.ExternalPropertiesDTO.Name, dto.ExternalPropertiesDTO.Password).LoadInternalData(dto.InternalPropertiesDTO.Id, dto.InternalPropertiesDTO.CreationDate, dto.InternalPropertiesDTO.ChangeDate);
        }

        public static implicit operator UserDTO(OutputUser output)
        {
            return output == null ? default : new UserDTO().Create(output.Id, new UserExternalPropertiesDTO(output.Name, output.Password), new UserInternalPropertiesDTO().LoadInternalData(output.Id, output.CreationDate, output.ChangeDate));
        }
    }
}
