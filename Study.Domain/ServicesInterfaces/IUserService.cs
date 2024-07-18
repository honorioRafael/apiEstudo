using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IUserService : IBaseService_2<InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, OutputUser>
    {
        public User? Auth(InputCreateUser view);
    }
}
