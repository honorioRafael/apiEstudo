using Study.Arguments.Arguments;

namespace Study.Domain.Interface.Service
{
    public interface IUserService : IBaseService_2<InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, OutputUser>
    {
        public object? Auth(InputCreateUser view);
    }
}
