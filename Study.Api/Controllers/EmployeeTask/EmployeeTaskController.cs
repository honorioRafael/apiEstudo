using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Study.Api.Controllers.Base;
using Study.Arguments.Arguments;
using Study.Domain.Interface.Service;

namespace Study.Api.Controllers
{
    public class EmployeeTaskController : BaseController<IEmployeeTaskService, InputCreateEmployeeTask, InputUpdateEmployeeTask, InputIdentityUpdateEmployeeTask, InputIdentityDeleteEmployeeTask, OutputEmployeeTask>
    {
        public EmployeeTaskController(IEmployeeTaskService service) : base(service)
        { }
    }
}
