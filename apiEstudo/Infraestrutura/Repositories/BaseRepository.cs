using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.Repositories
{
    public abstract class BaseRepository<TEntry> : IBaseRepository<TEntry>
        where TEntry : BaseEntry<TEntry>
    {
        protected readonly ConnectionContext _context;
        protected readonly DbSet<TEntry> _dbset;

        public BaseRepository(ConnectionContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntry>();
        }

        public virtual long Create(TEntry entry)
        {
            _context.Add(entry);
            _context.SaveChanges();

            return entry.Id;
        }

        public virtual List<int> CreateMultiple(List<TEntry> entry)
        {
            _context.AddRange(entry);
            _context.SaveChanges();

            return (from i in entry select i.Id).ToList();
        }


        public virtual List<TEntry>? GetAll()
        {
            return _dbset.ToList();
        }

        public virtual List<TEntry>? GetListByListId(List<int> listId)
        {
            return _dbset.Where(x => listId.Contains(x.Id)).ToList();
        }

        public virtual TEntry? Get(int id)
        {
            return _dbset.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
        }

        public virtual TEntry? GetByName(string name)
        {
            throw new NotImplementedException();
        }
        
        public virtual long Update(TEntry entry)
        {
            _context.Update(entry);
            _context.SaveChanges();

            return entry.Id;
        }

        public virtual bool Delete(TEntry classe)
        {
            _context.Remove(classe);
            _context.SaveChanges();

            return true;
        }
    }
}
