using Microsoft.EntityFrameworkCore;
using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Interface.Repository;
using Study.Infrastructure.Context;
using Study.Infrastructure.Entry;
using Study.Infrastructure.Repository.Base;

namespace Study.Infrastructure.Repository
{
    public class ProductRepository : BaseRepository<Product, InputCreateProduct, InputUpdateProduct, OutputProduct, ProductDTO, ProductExternalPropertiesDTO, ProductInternalPropertiesDTO, ProductAuxiliaryPropertiesDTO>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
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
