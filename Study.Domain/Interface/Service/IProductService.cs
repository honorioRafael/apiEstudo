using Study.Arguments.Arguments;
using Study.Arguments.Arguments.Product;

namespace Study.Domain.Interface.Service
{
    public interface IProductService : IBaseService<InputCreateProduct, InputUpdateProduct, InputIdentityUpdateProduct, InputIdentityDeleteProduct, OutputProduct>
    {
    }
}
