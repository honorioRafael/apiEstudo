using Study.Arguments.Arguments;
using Study.Domain.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Study.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/ShippingStatus")]
    public class ShippingStatusController : BaseController_1<IShippingStatusService, OutputShippingStatus>
    {
        public ShippingStatusController(IShippingStatusService service) : base(service) { }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Get(long id)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Update(BaseInputIdentityUpdate_0 inputIdentityUpdate)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Delete(BaseInputIdentityDelete_0 inputIdentityDelete)
        {
            throw new NotImplementedException();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Create(BaseInputCreate_0 inputCreate)
        {
            throw new NotImplementedException();
        }

        [HttpPost("Multiple")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult CreateMultiple(List<BaseInputCreate_0> listInputCreate)
        {
            throw new NotImplementedException();
        }

        [HttpPut("Multiple")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult UpdateMultiple(List<BaseInputIdentityUpdate_0> listInputIdentityUpdate)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("Multiple")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult DeleteMultiple(List<BaseInputIdentityDelete_0> listInputIdentityDelete)
        {
            throw new NotImplementedException();
        }
    }
}
