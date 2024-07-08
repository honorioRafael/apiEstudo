using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/Shopping")]
    public class ShoppingController : BaseController<IShoppingService, InputCreateShopping, InputUpdateShopping, InputIdentityUpdateShopping, InputIdentityDeleteShopping, OutputShopping>
    {
        public ShoppingController(IShoppingService service) : base(service)
        {
        }
    }
}
