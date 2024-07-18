using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Models;
using Study.Infrastructure.Repository;
using Study.Domain.Interface.Repository;
using Study.Infrastructure.Map;

namespace Study.Infraestrutura
{
    public class EmployeeTaskRepository : BaseRepository<EmployeeTask, InputCreateEmployeeTask, InputUpdateEmployeeTask, OutputEmployeeTask, EmployeeTaskDTO, EmployeeTaskExternalPropertiesDTO, EmployeeTaskInternalPropertiesDTO, EmployeeTaskAuxiliaryPropertiesDTO>, IEmployeeTaskRepository
    {
        public EmployeeTaskRepository(ConnectionContext context) : base(context) { }

    }
}
