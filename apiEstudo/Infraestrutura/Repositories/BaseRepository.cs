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

        // Create
        public virtual long Create(TEntry entry)
        {
            CreateMultiple([entry]);

            return entry.Id;
        }

        public virtual List<int> CreateMultiple(List<TEntry> entry)
        {
            _context.AddRange(entry);
            _context.SaveChanges();

            return (from i in entry select i.Id).ToList();
        }

        // Getters
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

        // Update
        public virtual long Update(TEntry entry)
        {
            UpdateMultiple([entry]);

            return entry.Id;
        }

        public List<int> UpdateMultiple(List<TEntry> entry)
        {
            _context.UpdateRange(entry);
            _context.SaveChanges();

            return (from i in entry select i.Id).ToList();
        }

        // Delete
        public virtual bool Delete(TEntry entry)
        {
            DeleteMultiple([entry]);

            return true;
        }

        public void DeleteMultiple(List<TEntry> entry)
        {
            _context.RemoveRange(entry);
            _context.SaveChanges();
        }
    }
}
