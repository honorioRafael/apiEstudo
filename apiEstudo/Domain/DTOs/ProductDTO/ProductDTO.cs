using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Product;

namespace apiEstudo.Domain.DTOs
{
    public class ProductDTO : BaseDTO<InputCreateProduct, InputUpdateProduct, OutputProduct, ProductDTO, ProductExternalPropertiesDTO, ProductInternalPropertiesDTO, ProductAuxiliaryPropertiesDTO>
    {
        public ProductDTO() { }
    }
}
