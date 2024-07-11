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

        [HttpPut("ShippingStatus/Cancel")]
        public IActionResult CancelShipping(InputIdentityUpdateShoppingShippingStatus inputIdentityUpdateShoppingShippingStatus)
        {
            try
            {
                return Ok(_service.UpdateShippingStatus(3, inputIdentityUpdateShoppingShippingStatus));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ShippingStatus/Approve")]
        public IActionResult ApproveShipping(InputIdentityUpdateShoppingShippingStatus inputIdentityUpdateShoppingShippingStatus)
        {
            try
            {
                return Ok(_service.UpdateShippingStatus(2, inputIdentityUpdateShoppingShippingStatus));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
