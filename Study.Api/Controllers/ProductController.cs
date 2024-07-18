using Study.Arguments.Arguments;
using Study.Arguments.Arguments.Product;
using Study.Domain.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
