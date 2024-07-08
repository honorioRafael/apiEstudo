using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IUserService : IBaseService<InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, InputIdentityDelete_0, Output_0>
    {
        public User? Auth(InputCreateUser view);
    }
}
