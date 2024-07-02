using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;
using apiEstudo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ConnectionContext contexto) : base(contexto) 
        {
        }

        public override List<Employee>? GetAll()
        {
            return _dbset.Include(x => x.EmployeeTask).ToList(); ;
        }
    }  
}
