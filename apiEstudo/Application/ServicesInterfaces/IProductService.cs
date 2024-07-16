using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Product;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IProductService : IBaseService<InputCreateProduct, InputUpdateProduct, InputIdentityUpdateProduct, InputIdentityDeleteProduct, OutputProduct>
    {
    }
}
