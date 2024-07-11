using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.Repositories;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;

namespace apiEstudo.Infraestrutura
{
    public class EmployeeTaskRepository : BaseRepository<EmployeeTask>, IEmployeeTaskRepository
    {
        public EmployeeTaskRepository(ConnectionContext context) : base(context) { }

    }
}
