using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/ShippingStatus")]
    public class ShippingStatusController : BaseController<IShippingStatusService, OutputShippingStatus>
    {
        public ShippingStatusController(IShippingStatusService service) : base(service) { }

        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Get(int id)
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
    }
}
