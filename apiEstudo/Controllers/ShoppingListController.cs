using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/ShoppingList")]
    public class ShoppingListController : BaseController<IShoppingListService, InputCreateShoppingList, InputUpdateShoppingList, InputIdentityUpdateShoppingList, InputIdentityDeleteShoppingList, OutputShoppingList>
    {
        public ShoppingListController(IShoppingListService service) : base(service)
        {
        }
    }
}
