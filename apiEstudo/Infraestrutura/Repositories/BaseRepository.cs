using apiEstudo.Application.Arguments;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using apiEstudo.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace apiEstudo.Infraestrutura.Repositories
{
    public abstract class BaseRepository<TEntry, TInputCreate, TInputUpdate> : IBaseRepository<TEntry, TInputCreate, TInputUpdate>
        where TEntry : BaseEntry<TEntry>, new()
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
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
            var constructorParameters = typeof(TEntry).GetConstructors()[0].GetParameters();

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
                //object[] ListConstructorParameterValues = new object[ConstructorParameters.Length];
                //for (int i = 0; i < ConstructorParameters.Length; i++)
                //{
                //    if (i < InputCreateProperties.Length) 
                //        ListConstructorParameterValues[i] = IsEqual(ConstructorParameters[i], InputCreateProperties[i]) ? InputCreateProperties[i].GetValue(inputCreate) : ConstructorParameters[i].DefaultValue;                                                                
                //    else
                //        ListConstructorParameterValues[i] = ConstructorParameters[i].DefaultValue;
                //}

                //TEntry CreatedObject = (TEntry)Activator.CreateInstance(typeof(TEntry), ListConstructorParameterValues);
                //EntitiesToBeCreated.Add(CreatedObject.SetCreationDate());
            }

            _context.AddRange(entitiesToBeCreated);
            _context.SaveChanges();

            return (from i in entitiesToBeCreated select i.Id).ToList();
        }

        private bool IsEqual(ParameterInfo param, PropertyInfo prop)
        {
            if (param.ParameterType == prop.PropertyType) return true;
            return false;
        }

        #endregion

        #region Get
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

        #endregion

        #region Update
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
}
