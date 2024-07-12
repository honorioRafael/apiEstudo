using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Models;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IEmployeeTaskRepository : IBaseRepository<EmployeeTask, InputCreateEmployeeTask, InputUpdateEmployeeTask>
    {
    }
}
