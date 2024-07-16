using apiEstudo.Application.Arguments;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, InputCreateEmployee, InputUpdateEmployee, OutputEmployee, EmployeeDTO, EmployeeExternalPropertiesDTO, EmployeeInternalPropertiesDTO, EmployeeAuxiliaryPropertiesDTO>, IEmployeeRepository
    {
        public EmployeeRepository(ConnectionContext contexto) : base(contexto)
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
