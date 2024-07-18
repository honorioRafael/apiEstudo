using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.DTOs.UserDTO;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public class UserService : BaseService_2<User, IUserRepository, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, OutputUser, UserDTO, UserExternalPropertiesDTO, UserInternalPropertiesDTO, UserAuxiliaryPropertiesDTO>, IUserService
    {
        public UserService(IUserRepository contextInterface, IIdControlRepository idControlRepository) : base(contextInterface, idControlRepository)
        { }

        public User? Auth(InputCreateUser view)
        {
            var UserEntity = _repository.GetByName(view.Name);
            if (UserEntity == null)
                throw new ArgumentNullException();
            if (UserEntity.ExternalPropertiesDTO.Password != view.Password)
                throw new WrongPasswordException("A senha informada é inválida");

            return UserEntity;
        }

        public long Create(InputCreateUser inputCreateUser)
        {
            if (inputCreateUser == null)
                throw new ArgumentNullException();
            var NameInUse = _repository.GetByName(inputCreateUser.Name);
            if (NameInUse != null)
                throw new NameInUseException("O nome de usuário ja está em uso!");
            var idRange = _idControlRepository.GetRangeId(TableName.GetNameId(nameof(User)), 1);
            var id = idRange.FirstId;

            var UserToCreate = new UserDTO().Create(id, inputCreateUser);
            return _repository.Create(UserToCreate);
        }

        public long Update(InputIdentityUpdateUser inputIdentityUpdateUser)
        {
            var originalUser = _repository.Get(inputIdentityUpdateUser.Id);
            if (originalUser == null) throw new NotFoundException();
            if (_repository.GetByName(inputIdentityUpdateUser.InputUpdate.Name) != null && inputIdentityUpdateUser.InputUpdate.Name != originalUser.ExternalPropertiesDTO.Name)
                throw new InvalidArgumentException("Esse nome ja está em uso!");

            return _repository.Update(originalUser.Update(inputIdentityUpdateUser.InputUpdate));
        }
    }
}
