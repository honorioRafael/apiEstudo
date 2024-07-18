using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Interface.Repository.Base;

namespace Study.Domain.Interface.Repository
{
    public interface IEmployeeTaskRepository : IBaseRepository<InputCreateEmployeeTask, InputUpdateEmployeeTask, OutputEmployeeTask, EmployeeTaskDTO, EmployeeTaskExternalPropertiesDTO, EmployeeTaskInternalPropertiesDTO, EmployeeTaskAuxiliaryPropertiesDTO>
    { }
}
