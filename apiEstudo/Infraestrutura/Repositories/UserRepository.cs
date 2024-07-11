using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class UserRepository : BaseRepository_2<User>, IUserRepository
    {
        public UserRepository(ConnectionContext context) : base(context)
        { }

        public override User? GetByName(string name)
        {
            Console.WriteLine(name.GetType());
            return _dbset.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
