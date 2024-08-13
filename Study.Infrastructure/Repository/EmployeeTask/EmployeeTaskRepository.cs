using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Interface.Repository;
using Study.Infrastructure.Context;
using Study.Infrastructure.Entry;
using Study.Infrastructure.Repository.Base;

namespace Study.Infraestrutura
{
    public class EmployeeTaskRepository : BaseRepository<EmployeeTask, InputCreateEmployeeTask, InputUpdateEmployeeTask, OutputEmployeeTask, EmployeeTaskDTO, EmployeeTaskExternalPropertiesDTO, EmployeeTaskInternalPropertiesDTO, EmployeeTaskAuxiliaryPropertiesDTO>, IEmployeeTaskRepository
    {
        public EmployeeTaskRepository(AppDbContext context) : base(context) { }

    }
}
