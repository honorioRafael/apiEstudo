namespace Study.Domain.DTO
{
    public class UserExternalPropertiesDTO : BaseExternalPropertiesDTO<UserExternalPropertiesDTO>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public UserExternalPropertiesDTO() { }

        public UserExternalPropertiesDTO(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
