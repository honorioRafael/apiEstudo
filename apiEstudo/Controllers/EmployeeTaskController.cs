using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/Task")]
    public class EmployeeTaskController : BaseController_2<IEmployeeTaskService, InputCreateEmployeeTask, InputUpdateEmployeeTask, InputIdentityUpdateEmployeeTask, InputIdentityDeleteEmployeeTask, OutputEmployeeTask>
    {
        public EmployeeTaskController(IEmployeeTaskService service) : base(service)
        { }
    }
}
