using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Model;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IEmployeeRepository : IBaseRepository_2<Employee, InputCreateEmployee, InputUpdateEmployee>
    {
    }
}
