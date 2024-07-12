using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Model;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, InputCreateEmployee, InputUpdateEmployee>, IEmployeeRepository
    {
        public EmployeeRepository(ConnectionContext contexto) : base(contexto)
        { }

        public override List<Employee>? GetAll()
        {
            return _dbset.Include(x => x.EmployeeTask).ToList();
        }

        public override Employee? Get(int id)
        {
            return _dbset.Include(x => x.EmployeeTask).Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
        }
    }
}
