using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Study.Api.Controllers.Base;
using Study.Arguments.Arguments;
using Study.Domain.Interface.Service;

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