using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public User? GetByName(string username);
    }
}
