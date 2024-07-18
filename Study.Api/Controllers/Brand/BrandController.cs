using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Study.Api.Controllers.Base;
using Study.Arguments.Arguments;
using Study.Domain.Interface.Service;

namespace Study.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/Brand")]
    public class BrandController : BaseController<IBrandService, InputCreateBrand, InputUpdateBrand, InputIdentityUpdateBrand, InputIdentityDeleteBrand, OutputBrand>
    {
        public BrandController(IBrandService service) : base(service) { }
    }
}
