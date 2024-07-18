using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;

namespace apiEstudo.Application.Services
{
    public interface IShoppingItemService : IBaseService<InputCreateShoppingItem, InputUpdateShoppingItem, InputIdentityUpdateShoppingItem, InputIdentityDeleteShoppingItem, OutputShoppingItem>
    { }
}
