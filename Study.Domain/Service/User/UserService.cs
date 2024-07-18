using Study.Arguments.Arguments;
using Study.Arguments.CustomException;
using Study.Arguments.CustomFunction;
using Study.Domain.DTO;
using Study.Domain.DTO.UserDTO;
using Study.Domain.Interface.Repository;
using Study.Domain.Interface.Service;
using Study.Domain.Service.Base;
using Study.Domain.Service.Token;

namespace Study.Domain.Service
{
    public class UserService : BaseService_2<IUserRepository, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, OutputUser, UserDTO, UserExternalPropertiesDTO, UserInternalPropertiesDTO, UserAuxiliaryPropertiesDTO>, IUserService
    {
        public UserService(IUserRepository contextInterface, IIdControlRepository idControlRepository) : base(contextInterface, idControlRepository)
        { }

        public object? Auth(InputCreateUser view)
        {
            var UserEntity = _repository.GetByName(view.Name);
            if (UserEntity == null)
                throw new ArgumentNullException();
            if (UserEntity.ExternalPropertiesDTO.Password != view.Password)
                throw new WrongPasswordException("A senha informada é inválida");

            return new
            {
                Token = TokenService.GenerateToken(UserEntity),
                User = (OutputUser)UserEntity
            };
        }

        public long Create(InputCreateUser inputCreateUser)
        {
            if (inputCreateUser == null)
                throw new ArgumentNullException();
            var NameInUse = _repository.GetByName(inputCreateUser.Name);
            if (NameInUse != null)
                throw new NameInUseException("O nome de usuário ja está em uso!");
            var idRange = _idControlRepository.GetRangeId(TableName.GetNameId("User"), 1);
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
