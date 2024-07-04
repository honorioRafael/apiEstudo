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

        public bool Auth(UserViewModel view)
        {
            var UserEntity = _repository.GetByName(view.Name);
            if (UserEntity == null) return false;
            if (UserEntity.Password != view.Password) return false;

            return true;
        }

        public bool Create(UserViewModel view)
        {
            if (view == null) return false;
            var Entity = new User(view.Name, view.Password);
            _repository.Create(Entity);
            return true;
        }
    }
}
