using Study.Arguments.Arguments;
using Study.Domain.Models;

namespace Study.Domain.Interface.Service
{
    public interface IUserService : IBaseService_2<InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, OutputUser>
    {
        public User? Auth(InputCreateUser view);
    }
}
