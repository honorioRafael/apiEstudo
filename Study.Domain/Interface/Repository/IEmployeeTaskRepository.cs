using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Models;

namespace Study.Domain.Interface.Repository
{
    public interface IEmployeeTaskRepository : IBaseRepository<EmployeeTask, InputCreateEmployeeTask, InputUpdateEmployeeTask, OutputEmployeeTask, EmployeeTaskDTO, EmployeeTaskExternalPropertiesDTO, EmployeeTaskInternalPropertiesDTO, EmployeeTaskAuxiliaryPropertiesDTO>
    {
    }
}
