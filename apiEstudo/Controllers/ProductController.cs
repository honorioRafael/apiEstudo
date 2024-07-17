using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Product;
using apiEstudo.Application.ServicesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
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
