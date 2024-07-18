using Study.Arguments.Arguments;
using Study.Arguments.Arguments.Brand;
using Study.Domain.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
