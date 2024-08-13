using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Interface.Repository.Base;

namespace Study.Domain.Interface.Repository
{
    public interface IEmployeeRepository : IBaseRepository<InputCreateEmployee, InputUpdateEmployee, OutputEmployee, EmployeeDTO, EmployeeExternalPropertiesDTO, EmployeeInternalPropertiesDTO, EmployeeAuxiliaryPropertiesDTO>
    { }
}
