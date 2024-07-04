using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.Repositories
{
    public abstract class BaseRepository<T, TDTO> : IBaseRepository<T, TDTO> 
        where T : BaseEntry<T>, IBaseModel<T> 
        where TDTO : IBaseDTO<TDTO>
    {
        protected readonly ConnectionContext _context;
        protected readonly DbSet<T> _dbset;

        public BaseRepository(ConnectionContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public virtual void Create(T classe)
        {
            _context.Add(classe);
            _context.SaveChanges();
        }

        public virtual List<T>? GetAll()
        {
            return _dbset.ToList();
        }

        public virtual List<T>? GetListByListId(List<int> listId)
        {
            return _dbset.Where(x => listId.Contains(x.Id)).ToList();
        }

        public virtual T? Get(int id)
        {
            return _dbset.Find(id);
        }

        public virtual T? GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T classe)
        {
            _context.Update(classe);
            _context.SaveChanges();
        }

        public virtual void Delete(T classe)
        {
            _context.Remove(classe);
            _context.SaveChanges();
        }

        /*public virtual List<T>? Get(IEnumerable<T> table, Func<T, bool> filter) 
        {
            return (from employee in table
                    where filter(employee)
                    select employee).ToList();
        }
        */

        internal TDTO OutputToDTO(T entrada)
        {
            return (TDTO)(dynamic)entrada;
        }

        internal List<TDTO> OutputToDTO(List<T> entrada)
        {
            return (from item in entrada select (TDTO)(dynamic)item).ToList();
        }

        internal T DTOToOutput(TDTO dto)
        {
            return (T)(dynamic)dto;
        }

        internal List<T> DTOToOutput(List<T> entrada)
        {
            return (from item in entrada select (T)(dynamic)item).ToList();
        }

    }
}
