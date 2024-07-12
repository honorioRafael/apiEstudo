using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/Employee")]
    public class EmployeeController : BaseController_2<IEmployeeService, InputCreateEmployee, InputUpdateEmployee, InputIdentityUpdateEmployee, InputIdentityDeleteEmployee, OutputEmployee>
    {
        public EmployeeController(IEmployeeService service) : base(service)
        {
        }
    }

}