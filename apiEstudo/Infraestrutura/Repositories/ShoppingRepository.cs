using apiEstudo.Application.Arguments;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class ShoppingRepository : BaseRepository<Shopping, InputCreateShopping, InputUpdateShopping, OutputShopping, ShoppingDTO, ShoppingExternalPropertiesDTO, ShoppingInternalPropertiesDTO, ShoppingAuxiliaryPropertiesDTO>, IShoppingRepository
    {
        public ShoppingRepository(ConnectionContext context) : base(context)
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
