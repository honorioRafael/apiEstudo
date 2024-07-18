using Study.Arguments.Arguments;

namespace Study.Domain.Interface.Service
{
    public interface IProductService : IBaseService<InputCreateProduct, InputUpdateProduct, InputIdentityUpdateProduct, InputIdentityDeleteProduct, OutputProduct>
    { }
}
