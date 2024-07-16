using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IUserService : IBaseService<InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, BaseInputIdentityDelete_0, OutputUser>
    {
        public User? Auth(InputCreateUser view);
    }
}
