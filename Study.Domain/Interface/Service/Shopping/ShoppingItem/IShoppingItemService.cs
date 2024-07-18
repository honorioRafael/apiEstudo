using Study.Arguments.Arguments;
using Study.Domain.Interface.Service;

namespace Study.Domain.Service
{
    public interface IShoppingItemService : IBaseService<InputCreateShoppingItem, InputUpdateShoppingItem, InputIdentityUpdateShoppingItem, InputIdentityDeleteShoppingItem, OutputShoppingItem>
    { }
}
