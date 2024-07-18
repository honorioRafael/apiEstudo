using Study.Arguments.Arguments;
using Study.Arguments.Arguments.Product;
using Study.Domain.DTO;

namespace Study.Domain.Interface.Repository
{
    public interface IProductRepository : IBaseRepository<InputCreateProduct, InputUpdateProduct, OutputProduct, ProductDTO, ProductExternalPropertiesDTO, ProductInternalPropertiesDTO, ProductAuxiliaryPropertiesDTO>
    {
    }
}
