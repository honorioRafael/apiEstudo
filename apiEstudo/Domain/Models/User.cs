using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;

namespace apiEstudo.Domain.Models
{
    public class User : BaseEntry<User>, IBaseModel<User>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public User(UserViewModel view)
        {
            Name = view.Name;
            Password = view.Password;
        }

        public User()
        { }

        public static implicit operator UserDTO(User user)
        {
            return user == null ? default : new UserDTO { Id = user.Id, Name = user.Name };
        }
    }
}
