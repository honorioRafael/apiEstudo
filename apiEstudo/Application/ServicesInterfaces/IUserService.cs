using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IUserService : IBaseService<User, UserDTO>
    {
        public void Create(UserViewModel view);
        public User? Auth(UserViewModel view);
    }
}
