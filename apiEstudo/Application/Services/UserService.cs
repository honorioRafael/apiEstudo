using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class UserService : BaseService<User, IUserRepository, UserDTO>, IUserService
    {

        public UserService(IUserRepository contextInterface) : base(contextInterface)
        {
        }

        public bool Create(UserViewModel view)
        {
            throw new NotImplementedException();
        }
    }
}
