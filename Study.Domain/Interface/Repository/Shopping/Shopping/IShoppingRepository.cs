using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Interface.Repository.Base;

namespace Study.Domain.Interface.Repository
{
    public interface IShoppingRepository : IBaseRepository<InputCreateShopping, InputUpdateShopping, OutputShopping, ShoppingDTO, ShoppingExternalPropertiesDTO, ShoppingInternalPropertiesDTO, ShoppingAuxiliaryPropertiesDTO>
    {
    }
}
