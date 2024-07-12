using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.Repositories;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;

namespace apiEstudo.Infraestrutura
{
    public class EmployeeTaskRepository : BaseRepository<EmployeeTask, InputCreateEmployeeTask, InputUpdateEmployeeTask>, IEmployeeTaskRepository
    {
        public EmployeeTaskRepository(ConnectionContext context) : base(context) { }

    }
}
