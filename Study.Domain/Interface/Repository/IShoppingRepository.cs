using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Models;

namespace Study.Domain.Interface.Repository
{
    public interface IShoppingRepository : IBaseRepository<Shopping, InputCreateShopping, InputUpdateShopping, OutputShopping, ShoppingDTO, ShoppingExternalPropertiesDTO, ShoppingInternalPropertiesDTO, ShoppingAuxiliaryPropertiesDTO>
    {
    }
}
