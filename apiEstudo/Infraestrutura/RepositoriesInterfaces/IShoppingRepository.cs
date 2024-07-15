using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IShoppingRepository : IBaseRepository<Shopping, InputCreateShopping>
    {
    }
}
