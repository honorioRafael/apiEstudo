using Study.Domain.DTO;
using Study.Domain.DTO.UserDTO;
using Study.Infrastructure.Entry.Base;

namespace Study.Infrastructure.Entry
{
    public class User : BaseEntry<User>
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public User()
        { }

        public static implicit operator UserDTO(User user)
        {
            return user == null ? default : new UserDTO().Create(user.Id, new UserExternalPropertiesDTO(user.Name, user.Password), new UserInternalPropertiesDTO().LoadInternalData(user.Id, user.CreationDate, user.ChangeDate));
        }

        public static implicit operator User(UserDTO dto)
        {
            return dto == null ? default : new User(dto.ExternalPropertiesDTO.Name, dto.ExternalPropertiesDTO.Password).LoadInternalData(dto.InternalPropertiesDTO.Id, dto.InternalPropertiesDTO.CreationDate, dto.InternalPropertiesDTO.ChangeDate);
        }
    }
}
