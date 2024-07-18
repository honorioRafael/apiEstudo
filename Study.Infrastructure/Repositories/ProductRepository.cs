using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Product;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class ProductRepository : BaseRepository<Product, InputCreateProduct, InputUpdateProduct, OutputProduct, ProductDTO, ProductExternalPropertiesDTO, ProductInternalPropertiesDTO, ProductAuxiliaryPropertiesDTO>, IProductRepository
    {
        public ProductRepository(ConnectionContext context) : base(context)
        {
        }

        public override List<ProductDTO>? GetAll()
        {
            return FromEntryToDTO(_dbset.Include(x => x.Brand).ToList());
        }

        public override ProductDTO? Get(long id)
        {
            return FromEntryToDTO(_dbset.Where(x => x.Id == id).Include(x => x.Brand).AsNoTracking().FirstOrDefault());
        }
    }
}
