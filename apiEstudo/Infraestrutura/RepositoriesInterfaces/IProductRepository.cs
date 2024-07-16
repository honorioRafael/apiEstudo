using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Product;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IProductRepository : IBaseRepository<Product, InputCreateProduct, InputUpdateProduct, OutputProduct, ProductDTO, ProductExternalPropertiesDTO, ProductInternalPropertiesDTO, ProductAuxiliaryPropertiesDTO>
    {
    }
}
