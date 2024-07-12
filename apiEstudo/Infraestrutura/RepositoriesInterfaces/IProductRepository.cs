using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Product;
using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IProductRepository : IBaseRepository<Product, InputCreateProduct, InputUpdateProduct>
    {
    }
}
