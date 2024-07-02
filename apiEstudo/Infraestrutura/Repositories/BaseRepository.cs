using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;
using apiEstudo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.Repositories
{
    public class BaseRepository<T> where T : Employee
    {
        public virtual List<T>? Get(ConnectionContext table)
        {
            return (from employee in table
                    select employee).ToList();
        }

        public virtual List<T>? Get(IEnumerable<T> table, Func<T, bool> filter) 
        {
            return (from employee in table
                    where filter(employee)
                    select employee).ToList();
        }
    }

}
