using Study.Arguments.Arguments;

namespace Study.Domain.Interface.Service
{
    public interface IEmployeeTaskService : IBaseService<InputCreateEmployeeTask, InputUpdateEmployeeTask, InputIdentityUpdateEmployeeTask, InputIdentityDeleteEmployeeTask, OutputEmployeeTask>
    {

    }
}
