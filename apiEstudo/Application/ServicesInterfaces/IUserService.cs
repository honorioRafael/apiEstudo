using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IUserService : IBaseService<InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, BaseInputIdentityDelete_0, BaseOutput_0>
    {
        public User? Auth(InputCreateUser view);
    }
}
