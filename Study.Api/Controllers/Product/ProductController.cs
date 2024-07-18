using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Study.Api.Controllers.Base;
using Study.Arguments.Arguments;
using Study.Domain.Interface.Service;

namespace Study.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/Product")]
    public class ProductController : BaseController<IProductService, InputCreateProduct, InputUpdateProduct, InputIdentityUpdateProduct, InputIdentityDeleteProduct, OutputProduct>
    {
        public ProductController(IProductService service) : base(service)
        {
        }
    }
}
