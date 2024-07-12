using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class UserService : BaseService_2<User, IUserRepository, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, BaseInputIdentityDelete_0, BaseOutput_0>, IUserService
    {
        public UserService(IUserRepository contextInterface) : base(contextInterface)
        {
        }

        public User? Auth(InputCreateUser view)
        {
            var UserEntity = _repository.GetByName(view.Name);
            if (UserEntity == null)
                throw new ArgumentNullException();
            if (UserEntity.Password != view.Password)
                throw new WrongPasswordException("A senha informada é inválida");

            return UserEntity;
        }

        public int Create(InputCreateUser inputCreateUser)
        {
            if (inputCreateUser == null)
                throw new ArgumentNullException();
            var NameInUse = _repository.GetByName(inputCreateUser.Name);
            if (NameInUse != null)
                throw new NameInUseException("O nome de usuário ja está em uso!");

            return _repository.Create(inputCreateUser);
        }

        public override int Update(InputIdentityUpdateUser inputIdentityUpdateUser)
        {
            var OriginalItem = _repository.Get(inputIdentityUpdateUser.Id);
            if (OriginalItem == null) throw new NotFoundException();
            if (_repository.GetByName(inputIdentityUpdateUser.InputUpdate.Name) != null && inputIdentityUpdateUser.InputUpdate.Name != OriginalItem.Name)
                throw new InvalidArgumentException("Esse nome ja está em uso!");

            return _repository.Update(new User(inputIdentityUpdateUser.InputUpdate.Name, inputIdentityUpdateUser.InputUpdate.Password).LoadInternalData(OriginalItem.Id, OriginalItem.CreationDate, OriginalItem.ChangeDate).SetChangeDate());
        }
    }
}
