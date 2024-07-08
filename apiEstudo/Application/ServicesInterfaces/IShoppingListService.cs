using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IShoppingListService : IBaseService<InputCreateShoppingList, InputUpdateShoppingList, InputIdentityUpdateShoppingList, InputIdentityDeleteShoppingList, OutputShoppingList>
    {
        public List<int> CreateMultiple(int shopId, List<InputCreateShoppingList> listInputCreate);
    }
}
