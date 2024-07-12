using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Product;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IProductService : IBaseService_2<InputCreateProduct, InputUpdateProduct, InputIdentityUpdateProduct, InputIdentityDeleteProduct, OutputProduct>
    {
    }
}
