using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Models;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IShoppingService<TShoppingListService> : IBaseService<InputCreateShopping, InputUpdateShopping, InputIdentityUpdateShopping, InputIdentityDeleteShopping, OutputShopping>
        where TShoppingListService : IBaseService<InputCreateShoppingList, InputUpdateShoppingList, InputIdentityUpdateShoppingList, InputIdentityDeleteShoppingList, OutputShoppingList>
    {
    }
}
