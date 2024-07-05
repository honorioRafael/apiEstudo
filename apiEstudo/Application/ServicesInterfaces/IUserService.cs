using apiEstudo.Application.ViewModel.UserViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IUserService : IBaseService<User, UserDTO>
    {
        public void Create(UserCreateViewModel view);
        public User? Auth(UserCreateViewModel view);
    }
}
