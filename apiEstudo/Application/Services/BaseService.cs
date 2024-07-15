using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Base;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;

namespace apiEstudo.Application.Services
{
    public abstract class BaseService<TEntry, TRepository, TInputCreate, TInputCreateComplete, TInputInternalCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput> : IBaseService<TInputCreate, TInputCreateComplete, TInputInternalCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput>
        where TEntry : BaseEntry<TEntry>, new()
        where TRepository : IBaseRepository<TEntry, TInputCreate, TInputCreateComplete, TInputInternalCreate, TInputUpdate, TInputIdentityUpdate>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputInternalCreate : BaseInputInternalCreate<TInputInternalCreate>
        where TInputCreateComplete : BaseInputCreateComplete<TInputCreate, TInputInternalCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
        where TOutput : BaseOutput<TOutput>
    {
        protected readonly TRepository _repository;

        public BaseService(TRepository contextInterface)
        {
            _repository = contextInterface;
        }

        #region Get
        public virtual TOutput? Get(int id)
        {
            return EntryToOutput(_repository.Get(id));
        }

        public virtual List<TOutput>? GetAll()
        {
            return EntryToOutput(_repository.GetAll());
        }

        public List<TEntry>? GetListByListId(List<int> listId)
        {
            return _repository.GetListByListId(listId);
        }

        #endregion

        #region Update
        public int Update(TInputIdentityUpdate inputIdentityUpdate)
        {
            return UpdateMultiple([inputIdentityUpdate]).First();
        }

        public virtual List<int> UpdateMultiple(List<TInputIdentityUpdate> listInputIdentityUpdate)
        {
            throw new NotImplementedException();
        }

        internal List<TEntry> InternalUpdate(List<TInputIdentityUpdate> listInputIdentityUpdate, List<TEntry> listEntitiesToBeUpdated)
        {
            var inputUpdateProperties = typeof(TInputUpdate).GetProperties();
            //var entitiesToBeUpdated = GetListByListId((from i in listInputIdentityUpdate select i.Id).ToList());
            var listUpdatedEntities = new List<TEntry>();

            foreach (var inputUpdate in listInputIdentityUpdate)
            {
                TEntry originalObject = (from i in listEntitiesToBeUpdated
                                         where i.Id == inputUpdate.Id
                                         select i).First();

                foreach (var propertyUpdate in inputUpdateProperties)
                {
                    var entryProperty = typeof(TEntry).GetProperty(propertyUpdate.Name);
                    var propertyUpdateValue = propertyUpdate.GetValue(inputUpdate.InputUpdate);

                    if (entryProperty == null) continue;
                    entryProperty.SetValue(originalObject, propertyUpdateValue);
                }

                listUpdatedEntities.Add(originalObject.SetChangeDate());
            }

            return listUpdatedEntities;
        }

        #endregion

        #region Create
        public int Create(TInputCreate inputCreate)
        {
            return CreateMultiple([inputCreate]).FirstOrDefault();
        }

        public virtual List<int> CreateMultiple(List<TInputCreate> listInputCreate)
        {
            throw new NotImplementedException();
        }

        public virtual List<int> CreateMultiple(List<TInputCreateComplete> listInputCreateComplete)
        {
            throw new NotImplementedException();
        }

        internal List<TEntry> InternalCreate(List<TInputCreate> listInputCreate)
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
            return entitiesToBeCreated;
        }

        internal List<TEntry> InternalCreate(List<TInputCreateComplete> listInputCreateComplete)
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

            return entitiesToBeCreated;
        }

        #endregion

        #region Delete
        public virtual void Delete(TInputIdentityDelete inputIdentityDelete)
        {
            var ToBeDeleted = _repository.Get(inputIdentityDelete.Id);
            if (ToBeDeleted == null)
                throw new NotFoundException("Não foi encontrado nenhum registro com o ID informado.");
            _repository.Delete(ToBeDeleted);
        }

        public virtual void DeleteMultiple(List<TInputIdentityDelete> listInputIdentityDelete)
        {
            var ToBeDeleted = _repository.GetListByListId((from i in listInputIdentityDelete select i.Id).ToList());
            if (ToBeDeleted == null)
                throw new NotFoundException("Não foi encontrado nenhum registro com o ID informado.");

            _repository.DeleteMultiple(ToBeDeleted);
        }

        #endregion

        #region Internal Functions

        internal TOutput EntryToOutput(TEntry entrada)
        {
            return (TOutput)(dynamic)entrada;
        }

        internal List<TOutput> EntryToOutput(List<TEntry> entrada)
        {
            return (from item in entrada select (TOutput)(dynamic)item).ToList();
        }

        #endregion        
    }

    public abstract class BaseService_1<TEntry, TRepository, TOutput> : BaseService<TEntry, TRepository, BaseInputCreate_0, BaseInputCreateComplete_0, BaseInputInternalCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0, TOutput>, IBaseService_1<TOutput>
        where TOutput : BaseOutput<TOutput>
        where TEntry : BaseEntry<TEntry>, new()
        where TRepository : IBaseRepository_1<TEntry>
    {
        protected BaseService_1(TRepository contextInterface) : base(contextInterface) { }
    }

    public abstract class BaseService_2<TEntry, TRepository, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput> : BaseService<TEntry, TRepository, TInputCreate, BaseInputCreateComplete<TInputCreate, BaseInputInternalCreate_0>, BaseInputInternalCreate_0, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput>, IBaseService_2<TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput>
        where TEntry : BaseEntry<TEntry>, new()
        where TRepository : IBaseRepository_2<TEntry, TInputCreate, TInputUpdate, TInputIdentityUpdate>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
        where TOutput : BaseOutput<TOutput>
    {
        protected BaseService_2(TRepository contextInterface) : base(contextInterface)
        { }
    }
}
