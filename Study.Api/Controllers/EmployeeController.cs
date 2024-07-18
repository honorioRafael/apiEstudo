using Study.Arguments.Arguments;
using Study.Domain.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Study.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/Employee")]
    public class EmployeeController : BaseController<IEmployeeService, InputCreateEmployee, InputUpdateEmployee, InputIdentityUpdateEmployee, InputIdentityDeleteEmployee, OutputEmployee>
    {
        public EmployeeController(IEmployeeService service) : base(service)
        {
        }
    }

}