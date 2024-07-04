using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;
using apiEstudo.Infraestrutura.Repositories;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee, EmployeeDTO>
    {
    }
}
