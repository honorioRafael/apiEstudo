using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Study.Api.Controllers.Base;
using Study.Arguments.Arguments;
using Study.Domain.Interface.Service;

namespace Study.Api.Controllers
{
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
