using Study.Arguments.Arguments;
using Study.Domain.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Study.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/Shopping")]
    public class ShoppingController : BaseController<IShoppingService, InputCreateShopping, InputUpdateShopping, InputIdentityUpdateShopping, InputIdentityDeleteShopping, OutputShopping>
    {
        public ShoppingController(IShoppingService service) : base(service) { }

        [HttpPost("CancelShipping")]
        public IActionResult CancelShipping(InputCancelShippingStatus inputCancelShippingStatus)
        {
            try
            {
                return Ok(_service.UpdateShippingStatusCancel([inputCancelShippingStatus]));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ApproveShipping")]
        public IActionResult ApproveShipping(InputApproveShippingStatus inputApproveShippingStatus)
        {
            try
            {
                return Ok(_service.UpdateShippingStatusApprove([inputApproveShippingStatus]));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
