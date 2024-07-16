using apiEstudo.Application.Arguments;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;

namespace apiEstudo.Infraestrutura.RepositoriesInterfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee, InputCreateEmployee, InputUpdateEmployee, OutputEmployee, EmployeeDTO, EmployeeExternalPropertiesDTO, EmployeeInternalPropertiesDTO, EmployeeAuxiliaryPropertiesDTO>
    {
    }
}
