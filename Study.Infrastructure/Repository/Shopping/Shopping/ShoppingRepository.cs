using Microsoft.EntityFrameworkCore;
using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Interface.Repository;
using Study.Infrastructure.Context;
using Study.Infrastructure.Entry;
using Study.Infrastructure.Repository.Base;

namespace Study.Infrastructure.Repository
{
    public class ShoppingRepository : BaseRepository<Shopping, InputCreateShopping, InputUpdateShopping, OutputShopping, ShoppingDTO, ShoppingExternalPropertiesDTO, ShoppingInternalPropertiesDTO, ShoppingAuxiliaryPropertiesDTO>, IShoppingRepository
    {
        public ShoppingRepository(AppDbContext context) : base(context)
        {
        }

        public override List<ShoppingDTO>? GetAll()
        {
            return FromEntryToDTO(_dbset.Include(x => x.ListShoppingItem)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.Brand)
                .Include(x => x.Employee)
                .ThenInclude(x => x.EmployeeTask)
                .Include(x => x.ShippingStatus).ToList());
        }

        public override ShoppingDTO? Get(long id)
        {
            return FromEntryToDTO(_dbset.Where(x => x.Id == id).Include(x => x.ListShoppingItem)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.Brand)
                .Include(x => x.Employee)
                .ThenInclude(x => x.EmployeeTask)
                .Include(x => x.ShippingStatus).AsNoTracking().FirstOrDefault());
        }
    }
}
