using apiEstudo.Application.Arguments;

namespace apiEstudo.Application.ServicesInterfaces
{
    public interface IEmployeeService : IBaseService<InputCreateEmployee, InputUpdateEmployee, InputIdentityUpdateEmployee, InputIdentityDeleteEmployee, OutputEmployee>
    {
    }
}
