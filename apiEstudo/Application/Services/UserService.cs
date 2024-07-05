//using apiEstudo.Application.ServicesInterfaces;
//using apiEstudo.Domain.Models;
//using apiEstudo.Infraestrutura.RepositoriesInterfaces;

//namespace apiEstudo.Application.Services
//{
//    public class UserService : BaseService<User, IUserRepository, UserDTO>, IUserService
//    {

//        public UserService(IUserRepository contextInterface) : base(contextInterface)
//        {
//        }

//        public User? Auth(UserCreateViewModel view)
//        {
//            var UserEntity = _repository.GetByName(view.Name);
//            if (UserEntity == null) throw new ArgumentNullException();
//            if (UserEntity.Password != view.Password) throw new WrongPasswordException("A senha informada é inválida");

//            return UserEntity;
//        }

//        public void Create(UserCreateViewModel view)
//        {
//            if (view == null) throw new ArgumentNullException();
//            User? UserBeingUsed = _repository.GetByName(view.Name);
//            if (UserBeingUsed != null) throw new NameInUseException("O nome de usuário ja está em uso!");

//            var Entity = new User(view.Name, view.Password);
//            _repository.Create(Entity);
//        }
//    }

//    public class NameInUseException : Exception
//    {
//        public NameInUseException(string message) : base(message)
//        { }
//    }

//    public class WrongPasswordException : Exception
//    {
//        public WrongPasswordException(string message) : base(message)
//        { }
//    }
//}
