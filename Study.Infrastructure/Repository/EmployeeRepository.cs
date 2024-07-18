using Microsoft.EntityFrameworkCore;
using Study.Arguments.Arguments;
using Study.Domain.DTO;
using Study.Domain.Interface.Repository;
using Study.Infrastructure.Context;
using Study.Infrastructure.Entry;

namespace Study.Infrastructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee, InputCreateEmployee, InputUpdateEmployee, OutputEmployee, EmployeeDTO, EmployeeExternalPropertiesDTO, EmployeeInternalPropertiesDTO, EmployeeAuxiliaryPropertiesDTO>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context): base(context)
        { }

        public override List<EmployeeDTO>? GetAll()
        {
            return FromEntryToDTO(_dbset.Include(x => x.EmployeeTask).ToList());
        }

        public override EmployeeDTO? Get(long id)
        {
            return FromEntryToDTO(_dbset.Include(x => x.EmployeeTask).Where(x => x.Id == id).AsNoTracking().FirstOrDefault());
        }
    }
}
