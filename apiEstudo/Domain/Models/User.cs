using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;

namespace apiEstudo.Domain.Models
{
    public class User : BaseEntry<User>, IBaseModel<User>
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
            return user == null ? default : new UserDTO { Id = user.Id, Name = user.Name };
        }
    }
}
