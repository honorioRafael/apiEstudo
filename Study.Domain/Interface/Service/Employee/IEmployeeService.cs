using Study.Arguments.Arguments;

namespace Study.Domain.Interface.Service
{
    public interface IEmployeeService : IBaseService<InputCreateEmployee, InputUpdateEmployee, InputIdentityUpdateEmployee, InputIdentityDeleteEmployee, OutputEmployee>
    { }
}
