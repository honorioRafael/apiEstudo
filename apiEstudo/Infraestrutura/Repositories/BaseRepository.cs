using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Base;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;
using Microsoft.EntityFrameworkCore;

namespace apiEstudo.Infraestrutura.Repositories
{
    public abstract class BaseRepository<TEntry, TInputCreate, TInputUpdate, TInputCreateComplete, TInputInternalCreate> : IBaseRepository<TEntry, TInputCreate, TInputUpdate, TInputCreateComplete, TInputInternalCreate>
        where TEntry : BaseEntry<TEntry>, new()
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputInternalCreate : BaseInputInternalCreate<TInputInternalCreate>
        where TInputCreateComplete : BaseInputCreateComplete<TInputCreate, TInputInternalCreate>
    {
        protected readonly ConnectionContext _context;
        protected readonly DbSet<TEntry> _dbset;

        public BaseRepository(ConnectionContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntry>();
        }

        #region Create
        public virtual int Create(TInputCreate entry)
        {
            return CreateMultiple([entry]).First();
        }

        public virtual List<int> CreateMultiple(List<TInputCreate> listInputCreate)
        {
            var inputCreateProperties = typeof(TInputCreate).GetProperties();
            var entitiesToBeCreated = new List<TEntry>();

            foreach (var inputCreate in listInputCreate)
            {
                TEntry createdObject = (TEntry)Activator.CreateInstance(typeof(TEntry));

                foreach (var propertyCreate in inputCreateProperties)
                {
                    var entryProperty = typeof(TEntry).GetProperty(propertyCreate.Name);
                    var propertyCreateValue = propertyCreate.GetValue(inputCreate);

                    if (entryProperty == null) continue;
                    entryProperty.SetValue(createdObject, propertyCreateValue);
                }

                entitiesToBeCreated.Add(createdObject.SetCreationDate());
            }

            _context.AddRange(entitiesToBeCreated);
            _context.SaveChanges();

            return (from i in entitiesToBeCreated select i.Id).ToList();
        }

        public virtual List<int> CreateMultiple(List<TInputCreateComplete> listInputCreateComplete)
        {
            var entitiesToBeCreated = new List<TEntry>();

            foreach (var inputCreateComplete in listInputCreateComplete)
            {
                TEntry createdObject = (TEntry)Activator.CreateInstance(typeof(TEntry));
                var inputCreate = inputCreateComplete.GetType().GetProperty(nameof(BaseInputCreateComplete_0.InputCreate));
                var inputInternalCreate = inputCreateComplete.GetType().GetProperty(nameof(BaseInputCreateComplete_0.InputInternalCreate));
                if (inputCreate != null)
                {
                    foreach (var propertyCreate in inputCreate.PropertyType.GetProperties())
                    {
                        var entryProperty = typeof(TEntry).GetProperty(propertyCreate.Name);
                        var propertyCreateValue = propertyCreate.GetValue(inputCreateComplete.InputCreate);

                        if (entryProperty == null) continue;
                        entryProperty.SetValue(createdObject, propertyCreateValue);
                    }
                }
                if (inputInternalCreate != null)
                {
                    foreach (var propertyCreate in inputInternalCreate.PropertyType.GetProperties())
                    {
                        var entryProperty = typeof(TEntry).GetProperty(propertyCreate.Name);
                        var propertyCreateValue = propertyCreate.GetValue(inputCreateComplete.InputInternalCreate);

                        if (entryProperty == null) continue;
                        entryProperty.SetValue(createdObject, propertyCreateValue);
                    }
                }

                entitiesToBeCreated.Add(createdObject.SetCreationDate());
            }

            _context.AddRange(entitiesToBeCreated);
            _context.SaveChanges();

            return (from i in entitiesToBeCreated select i.Id).ToList();
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
        /*public virtual int Update(TInputUpdate inputUpdate)
        {
            return UpdateMultiple([inputUpdate]).FirstOrDefault();
        }

        public List<int> UpdateMultiple(List<TInputUpdate> listInputUpdate)
        {
            var inputUpdateProperties = typeof(TInputUpdate).GetProperties();
            var entitiesToBeUpdated = new List<TEntry>();

            foreach (var inputUpdate in listInputUpdate)
            {
                TEntry createdObject = Get(inputUpdate);

                foreach (var propertyCreate in inputCreateProperties)
                {
                    var entryProperty = typeof(TEntry).GetProperty(propertyCreate.Name);
                    var propertyCreateValue = propertyCreate.GetValue(inputCreate);

                    if (entryProperty == null) continue;
                    entryProperty.SetValue(createdObject, propertyCreateValue);
                }

                entitiesToBeCreated.Add(createdObject.SetCreationDate());
            }
            _context.UpdateRange(entry);
            _context.SaveChanges();

            return (from i in entry select i.Id).ToList();
        }*/


        public virtual int Update(TEntry entry)
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


        #endregion

        #region Delete
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

        #endregion
    }

    public abstract class BaseRepository_1<TEntry> : BaseRepository<TEntry, BaseInputCreate_0, BaseInputUpdate_0, BaseInputCreateComplete_0, BaseInputInternalCreate_0>, IBaseRepository_1<TEntry>
        where TEntry : BaseEntry<TEntry>, new()
    {
        protected BaseRepository_1(ConnectionContext context) : base(context)
        { }
    }

    public abstract class BaseRepository_2<TEntry, TInputCreate, TInputUpdate> : BaseRepository<TEntry, TInputCreate, TInputUpdate, BaseInputCreateComplete<TInputCreate, BaseInputInternalCreate_0>, BaseInputInternalCreate_0>, IBaseRepository_2<TEntry, TInputCreate, TInputUpdate>
        where TEntry : BaseEntry<TEntry>, new()
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
    {
        protected BaseRepository_2(ConnectionContext context) : base(context)
        { }
    }
}
