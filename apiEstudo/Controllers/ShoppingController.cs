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
        public ShoppingController(IShoppingService service) : base(service) { }

        [HttpPost("CancelShipping")]
        public IActionResult CancelShipping(InputCancelShippingStatus inputIdentityUpdateShoppingShippingStatus)
        {
            try
            {
                return Ok(_service.UpdateShippingStatusCancel(inputIdentityUpdateShoppingShippingStatus));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ApproveShipping")]
        public IActionResult ApproveShipping(InputApproveShippingStatus inputIdentityUpdateShoppingShippingStatus)
        {
            try
            {
                return Ok(_service.UpdateShippingStatusApprove(inputIdentityUpdateShoppingShippingStatus));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
