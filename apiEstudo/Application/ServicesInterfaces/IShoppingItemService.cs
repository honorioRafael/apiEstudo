using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;

namespace apiEstudo.Application.Services
{
    public interface IShoppingItemService : IBaseService<InputCreateShoppingItem, InputCreateShoppingItemComplete, InputInternalCreateShoppingItem, InputUpdateShoppingItem, InputIdentityUpdateShoppingItem, InputIdentityDeleteShoppingItem, OutputShoppingItem>
    {
    }
}
