using apiEstudo.Domain.Model;
using apiEstudo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntry<T>
    {
        protected readonly ConnectionContext _context;
        protected readonly DbSet<T> _dbset;

        public BaseRepository(ConnectionContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public virtual List<T>? GetAll()
        {
            return _dbset.ToList();
        }

        public virtual List<T>? GetListByListId(List<long> listId)
        {
            return _dbset.Where(x => listId.Contains(x.Id)).ToList();
        }

        public virtual T? Get(long id)
        {
            return _dbset.Find(id);
        }


        /*public virtual List<T>? Get(IEnumerable<T> table, Func<T, bool> filter) 
        {
            return (from employee in table
                    where filter(employee)
                    select employee).ToList();
        }
        */
    }
}
