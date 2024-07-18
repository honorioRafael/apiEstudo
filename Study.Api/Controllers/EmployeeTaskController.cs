using Study.Arguments.Arguments;
using Study.Domain.Interface.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Study.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/Task")]
    public class EmployeeTaskController : BaseController<IEmployeeTaskService, InputCreateEmployeeTask, InputUpdateEmployeeTask, InputIdentityUpdateEmployeeTask, InputIdentityDeleteEmployeeTask, OutputEmployeeTask>
    {
        public EmployeeTaskController(IEmployeeTaskService service) : base(service)
        { }
    }
}
