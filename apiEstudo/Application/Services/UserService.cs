using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.Repositories;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class UserService : BaseService<User, IUserRepository, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, InputIdentityDelete_0, Output_0>, IUserService
    {
        public UserService(IUserRepository contextInterface) : base(contextInterface)
        {
        }

        public User? Auth(InputCreateUser view)
        {
            var UserEntity = _repository.GetByName(view.Name);
            if (UserEntity == null) throw new ArgumentNullException();
            if (UserEntity.Password != view.Password) throw new WrongPasswordException("A senha informada é inválida");

            return UserEntity;
        }

        public void Create(InputCreateUser view)
        {
            if (view == null) throw new ArgumentNullException();
            User? UserBeingUsed = _repository.GetByName(view.Name);
            if (UserBeingUsed != null) throw new NameInUseException("O nome de usuário ja está em uso!");

            var Entity = new User(view.Name, view.Password);
            _repository.Create(Entity);
        }

        public override long Update(InputIdentityUpdateUser inputIdentityUpdate)
        {
            var OriginalItem = _repository.Get(inputIdentityUpdate.Id);
            if (OriginalItem == null) throw new NotFoundException();

            return _repository.Update(new User(inputIdentityUpdate.InputUpdate.Name, inputIdentityUpdate.InputUpdate.Password).LoadInternalData(OriginalItem.Id, OriginalItem.CreationDate, OriginalItem.ChangeDate).SetChangeDate());
        }
    }

    public class NameInUseException : Exception
    {
        public NameInUseException(string message) : base(message)
        { }
    }

    public class WrongPasswordException : Exception
    {
        public WrongPasswordException(string message) : base(message)
        { }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message = "Id não localizado") : base(message)
        {
        }
    }
}
