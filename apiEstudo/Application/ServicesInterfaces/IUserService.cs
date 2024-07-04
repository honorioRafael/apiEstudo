using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IUserService : IBaseService<User, UserDTO>
    {
        public bool Create(UserViewModel view);
    }
}
