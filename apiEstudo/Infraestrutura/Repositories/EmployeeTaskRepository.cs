using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Mappings;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class EmployeeTaskRepository : BaseRepository<EmployeeTask>, IEmployeeTaskRepository
    {
        public EmployeeTaskRepository(ConnectionContext context) : base(context) { }
    }
}
