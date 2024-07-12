using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IUserRepository : IBaseRepository_2<User, InputCreateUser, InputUpdateUser>
    {
        public User? GetByName(string username);
    }
}
