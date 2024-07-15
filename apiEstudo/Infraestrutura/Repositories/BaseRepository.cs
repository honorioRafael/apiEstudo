using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Base;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.Repositories
{
    public abstract class BaseRepository<TEntry, TInputCreate, TInputCreateComplete, TInputInternalCreate, TInputUpdate, TInputIdentityUpdate> : IBaseRepository<TEntry, TInputCreate, TInputCreateComplete, TInputInternalCreate, TInputUpdate, TInputIdentityUpdate>
        where TEntry : BaseEntry<TEntry>, new()
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputInternalCreate : BaseInputInternalCreate<TInputInternalCreate>
        where TInputCreateComplete : BaseInputCreateComplete<TInputCreate, TInputInternalCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
    {
        protected readonly ConnectionContext _context;
        protected readonly DbSet<TEntry> _dbset;

        public BaseRepository(ConnectionContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntry>();
        }

        #region Create
        public virtual int Create(TEntry entry)
        {
            return CreateMultiple([entry]).First();
        }

        public virtual List<int> CreateMultiple(List<TEntry> listInputCreate)
        {
            _context.AddRange(listInputCreate);
            _context.SaveChanges();

            return (from i in listInputCreate select i.Id).ToList();
        }

        #endregion

        #region Get
        public virtual List<TEntry>? GetAll()
        {
            return _dbset.ToList();
        }

        public virtual List<TEntry>? GetListByListId(List<int> listId)
        {
            return _dbset.Where(x => listId.Contains(x.Id)).AsNoTracking().ToList();
        }

        public virtual TEntry? Get(int id)
        {
            return _dbset.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
        }

        #endregion

        #region Update
        public virtual int Update(TEntry inputUpdate)
        {
            return UpdateMultiple([inputUpdate]).FirstOrDefault();
        }

        public List<int> UpdateMultiple(List<TEntry> listInputUpdate)
        {
            _context.UpdateRange(listInputUpdate);
            _context.SaveChanges();

            return (from i in listInputUpdate select i.Id).ToList();
        }

        #endregion

        #region Delete
        public virtual void Delete(TEntry entry)
        {
            DeleteMultiple([entry]);
        }

        public void DeleteMultiple(List<TEntry> entry)
        {
            _context.RemoveRange(entry);
            _context.SaveChanges();
        }

        #endregion
    }

    public abstract class BaseRepository_1<TEntry> : BaseRepository<TEntry, BaseInputCreate_0, BaseInputCreateComplete_0, BaseInputInternalCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0>, IBaseRepository_1<TEntry>
        where TEntry : BaseEntry<TEntry>, new()
    {
        protected BaseRepository_1(ConnectionContext context) : base(context)
        { }
    }

    public abstract class BaseRepository_2<TEntry, TInputCreate, TInputUpdate, TInputIdentityUpdate> : BaseRepository<TEntry, TInputCreate, BaseInputCreateComplete<TInputCreate, BaseInputInternalCreate_0>, BaseInputInternalCreate_0, TInputUpdate, TInputIdentityUpdate>, IBaseRepository_2<TEntry, TInputCreate, TInputUpdate, TInputIdentityUpdate>
        where TEntry : BaseEntry<TEntry>, new()
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
    {
        protected BaseRepository_2(ConnectionContext context) : base(context)
        { }
    }
}
